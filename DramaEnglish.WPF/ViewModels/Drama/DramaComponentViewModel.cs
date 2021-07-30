﻿using CommonService.DB;
using DramaEnglish.UserInterface.ViewModels.Header;
using DramaEnglish.WPF.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DramaEnglish.UserInterface.ViewModels.Drama
{
    public class DramaComponentViewModel : ViewModelBase
    {

        #region 属性字段
        private MediaElement MediaPlayer;
        private WORD currentWord;
        public WORD CurrentWord { get { return currentWord; } set { SetProperty(ref currentWord, value); } }



        private int Index = 0;
        private List<WORD> words;
        #endregion

        #region 构造函数
        public DramaComponentViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
          : base(regionManager, dialogService, ea)
        {
            words = WordDBService.GetIDontKnowWORD();

            EventAggregator.GetEvent<PubSubEvent<EnumPlayStatus>>().Subscribe((status) => {
                if (status == EnumPlayStatus.next)
                {
                    next(this.MediaPlayer);
                }
                else if (status == EnumPlayStatus.iknow)
                {
                    iknowit(this.MediaPlayer);
                }
            });

            
        }
        #endregion

        #region 命令
        public DelegateCommand<MediaElement> StartCommand => new((MediaPlayer) =>
        {
            this.MediaPlayer = MediaPlayer;
            Play(CurrentWord);
            //foreach (var item in GetWords())
            //{
            //    this.MediaPlayer.Source = new Uri($@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{item}\{item}.ts");

            //    this.MediaPlayer.Play();
            //}

        });


        public DelegateCommand<MediaElement> GetFreshCommand => new((MediaPlayer) =>
        {
            Index = 0;
            words = WordDBService.GetFreshWrod();
        });

        public DelegateCommand<MediaElement> GetHardCommand => new((MediaPlayer) =>
        {
            Index = 0;
            words = WordDBService.GetIDontKnowWORD();
        });

        public DelegateCommand<Window> DragMoveCommand => new((Window) =>
        {
            Window.DragMove();

        });

        public DelegateCommand<MediaElement> NextCommand => new((MediaPlayer) =>
        {
            next(MediaPlayer);
        });

        private void next(MediaElement m) {
            CurrentWord = words[Index];
            Index++;
            Index = Index % words.Count;
            Play(CurrentWord);
            WordDBService.WatcheWord(CurrentWord);
           //var KnowWordCount = WordDBService.IKnowWordCount();
        }

        public DelegateCommand<MediaElement> IKnowCommand => new((MediaPlayer) =>
        {
            iknowit(MediaPlayer);
        });

        private void iknowit(MediaElement m) {
            CurrentWord = words[Index];
            Index++;
            Index = Index % words.Count;
            Play(CurrentWord);
            WordDBService.IKnowWord(CurrentWord);
            EventAggregator.GetEvent<PubSubEvent<RefreshWordCount>>().Publish( RefreshWordCount.KonwnWordCount);
        }

        public DelegateCommand<MediaElement> StopCommand => new((MediaPlayer) => { this.MediaPlayer = MediaPlayer; MediaPlayer.Stop(); });

        public DelegateCommand<MediaElement> LoadingCommand => new((MediaPlayer) =>
        {
            this.MediaPlayer = MediaPlayer;
        });


        #endregion

        #region 函数方法

        public void Play(WORD word)
        {
            MediaPlayer.Source = new Uri($@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{currentWord.EN}\{currentWord.EN}.ts");

            MediaPlayer.Play();
        }


        #endregion
    }
}

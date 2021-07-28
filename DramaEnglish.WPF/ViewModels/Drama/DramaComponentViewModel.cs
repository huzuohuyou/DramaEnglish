using DramaEnglish.WPF.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DramaEnglish.UserInterface.ViewModels.Drama
{
    public class DramaComponentViewModel : ViewModelBase
    {

        #region 属性字段
        private MediaElement MediaPlayer;
        private string videoPath=$@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words";
        private string currentWord= "applause";
        public string CurrentWord { get { return currentWord; } set { SetProperty(ref currentWord, value); } }
        private int Index = 0;
        private List<string> words ;
        private string currentWordDetail = "";
        public string CurrentWordDetail { get { return currentWordDetail; } set { SetProperty(ref currentWordDetail, value); } }


        private string currentWordLine = "";
        public string CurrentWordLine { get { return currentWordLine; } set { SetProperty(ref currentWordLine, value); } }
        #endregion

        #region 构造函数
        public DramaComponentViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
          : base(regionManager, dialogService, ea)
        {
            words = GetWords();
        }
        #endregion

        #region 命令
        public DelegateCommand<MediaElement> StartCommand => new((MediaPlayer) => {
            this.MediaPlayer = MediaPlayer;
            Play(CurrentWord);
            //foreach (var item in GetWords())
            //{
            //    this.MediaPlayer.Source = new Uri($@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{item}\{item}.ts");

            //    this.MediaPlayer.Play();
            //}

        });

        public DelegateCommand<Window> DragMoveCommand => new((Window) => {
            Window.DragMove();

        });

        

        public DelegateCommand<MediaElement> NextCommand => new((MediaPlayer) =>
        {
            this.MediaPlayer = MediaPlayer;
            CurrentWord = words[Index];
            CurrentWordDetail = GetWordDetail(CurrentWord);
            CurrentWordLine= GetWordLine(CurrentWord);
            Index++;
            Index = Index % words.Count;
            Play(CurrentWord);
        });


        public DelegateCommand<MediaElement> StopCommand => new((MediaPlayer) => { this.MediaPlayer = MediaPlayer; MediaPlayer.Stop(); });

        public DelegateCommand<MediaElement> LoadingCommand => new((MediaPlayer) => {
            this.MediaPlayer = MediaPlayer;
        });


        #endregion

        #region 函数方法

        public void Play(string word) {
            this.MediaPlayer.Source = new Uri($@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{currentWord}\{currentWord}.ts");

            this.MediaPlayer.Play();
        }
        

            private string GetWordLine(string word)
        {
            try
            {
                using (StreamReader sr = new StreamReader($@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{word}\台词.txt"))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return word;
        }
        private string GetWordDetail(string word) {
            try
            {
                using (StreamReader sr = new StreamReader($@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{word}\{word}.txt"))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return word;
        }

        public List<string> GetWords()
        {
            var words = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader($@"D:\Github\DramaEnglish\DramaEnglish.WPF\Words\B_贝壳今日单词_纯单词.txt"))
                {
                    while (sr.ReadLine() != null)
                    {
                        words.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return words;
        }

        #endregion
    }
}

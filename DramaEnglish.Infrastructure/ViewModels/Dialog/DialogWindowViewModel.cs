using DramaEnglish.WPF.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows;

namespace DramaEnglish.Infrastructure.ViewModels.Dialog
{
    public class DialogWindowViewModel : ViewModelBase
    {
        #region 字段属性

        private Window window;
        public enum EnumFormStatus
        {
            mini,
            close,
        }
        #endregion

        #region 构造方法

        public DialogWindowViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
           : base(regionManager, dialogService, ea)
        {

            EventAggregator.GetEvent<PubSubEvent<EnumFormStatus>>().Subscribe((status) => {
                if (status == EnumFormStatus.mini)
                {
                    window.WindowState = WindowState.Minimized;
                }
                else if (status == EnumFormStatus.close)
                {
                    window.Close();
                }
            });
        }

        #endregion

        #region 命令

        public DelegateCommand<Window> LoginLoadingCommand => new((obj) => {
            if (obj == null)
            {
                throw new Exception("请设置窗体Name 并 传CommandParameter Binding ElementName=Name");
            }
            window = obj;
        });

        public string Title => "";



        #endregion

        #region 方法函数

        #endregion
    }
}


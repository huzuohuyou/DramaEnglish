using DramaEnglish.Styling.EventAggregator;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows;

namespace DramaEnglish.WPF.ViewModels.Login
{
    public class LoginWindowViewModel : ViewModelBase
    {
        #region 字段属性

        private Window window;
        #endregion

        #region 构造方法

        public LoginWindowViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
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

        public DelegateCommand<Window> LoginLoadingCommand => new ((obj) => {
            if (obj==null)
            {
                throw new Exception("请设置窗体Name 并 传CommandParameter Binding ElementName=Name");
            }
            window = obj; });


        #endregion

        #region 方法函数
        private void FormOperation(EnumFormStatus status)
        {
            if (status == EnumFormStatus.mini)
            {
                window.WindowState = WindowState.Minimized;
            }
            else if (status == EnumFormStatus.close)
            {
                window.Close();
            }
        }
        #endregion
    }
}

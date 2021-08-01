using DramaEnglish.Styling.EventAggregator;
using DramaEnglish.WPF.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows;

namespace DramaEnglish.UserInterface.ViewModels.Login
{
    public class LoginDialogViewModel :ViewModelBase, IDialogAware
    {

        #region 字段属性
        private Window window;
        #endregion

        #region 构造函数
        public LoginDialogViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
          : base(regionManager, dialogService, ea)
        {

            EventAggregator.GetEvent<PubSubEvent<EnumFormStatus>>().Subscribe((status) => {
                if (status == EnumFormStatus.mini)
                {
                    RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
                }
                else if (status == EnumFormStatus.close)
                {
                    RequestClose?.Invoke(new DialogResult(ButtonResult.Abort));
                }
                else if (status == EnumFormStatus.success)
                {
                    RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                }
            });
        }
        #endregion

        #region 命令
        public DelegateCommand<Window> LoginLoadingCommand => new((obj) => {
            if (obj == null)
            {
                //throw new Exception("请设置窗体Name 并 传CommandParameter Binding ElementName=Name");
            }
            window = obj;
        });

        #endregion

        #region 方法函数

        #endregion

        public string Title => "";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            //throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            //throw new NotImplementedException();
        }
    }
}

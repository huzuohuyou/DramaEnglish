using DramaEnglish.UserInterface.ViewModels.Drama;
using DramaEnglish.WPF.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Windows;

namespace DramaEnglish.UserInterface.ViewModels
{
    public class MainShellWindowViewModel : ViewModelBase
    {


        #region Fields
        private Visibility isLogined = Visibility.Hidden;
        public Visibility IsLogined { get { return isLogined; } set { SetProperty(ref isLogined, value); } }
        private Window window;
        #endregion

        #region Properties
        public DelegateCommand NextCommand => new(() =>
        {
            EventAggregator.GetEvent<PubSubEvent<EnumPlayStatus>>().Publish(EnumPlayStatus.next);
        });

        public DelegateCommand<Window> LoadedCommand => new((w) =>
        {
            window = w;
            window.Visibility = Visibility.Hidden;
            DialogService.ShowDialog("LoginDialog", (d) => {
                if (d.Result.Equals(ButtonResult.Abort))
                {
                    window.Close();
                }
                else if (d.Result.Equals(ButtonResult.Cancel))
                {
                    window.WindowState=WindowState.Minimized;
                }
                else if (d.Result.Equals(ButtonResult.OK))
                {
                    window.Visibility = Visibility.Visible;
                    IsLogined = Visibility.Visible;
                }
            });
        });
        
        public DelegateCommand IKnowCommand => new(() =>
        {
            EventAggregator.GetEvent<PubSubEvent<EnumPlayStatus>>().Publish(EnumPlayStatus.iknow);
        });
        #endregion

        #region Constructors
        public MainShellWindowViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
           : base(regionManager, dialogService, ea)
        {
            //弹出登录窗口
           
        }
        #endregion

        #region Overrides
        #endregion

        #region Private Methods

        #endregion

    }
}

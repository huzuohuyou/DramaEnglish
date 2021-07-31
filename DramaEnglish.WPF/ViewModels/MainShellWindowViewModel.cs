using DramaEnglish.UserInterface.ViewModels.Drama;
using DramaEnglish.WPF.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace DramaEnglish.UserInterface.ViewModels
{
    public class MainShellWindowViewModel : ViewModelBase
    {
        public MainShellWindowViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
           : base(regionManager, dialogService, ea)
        {
        }

        #region Fields

        #endregion

        #region Properties
        public DelegateCommand NextCommand => new(() =>
        {
            EventAggregator.GetEvent<PubSubEvent<EnumPlayStatus>>().Publish(EnumPlayStatus.next);
        });

        public DelegateCommand IKnowCommand => new(() =>
        {
            EventAggregator.GetEvent<PubSubEvent<EnumPlayStatus>>().Publish(EnumPlayStatus.iknow);
        });
        #endregion

        #region Constructors

        #endregion

        #region Overrides
        #endregion

        #region Private Methods

        #endregion

    }
}

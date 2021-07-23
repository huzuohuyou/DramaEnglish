using DramaEnglish.WPF.ViewModels;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace DramaEnglish.UserInterface.ViewModels.Drama
{
    public class LinesComponentViewModel : ViewModelBase
    {
        public LinesComponentViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
           : base(regionManager, dialogService, ea)
        {
        }
    }
}

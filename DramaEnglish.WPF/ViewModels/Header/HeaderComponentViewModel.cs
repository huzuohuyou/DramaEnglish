using CommonService.DB;
using DramaEnglish.WPF.ViewModels;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace DramaEnglish.UserInterface.ViewModels.Header
{
    public class HeaderComponentViewModel : ViewModelBase
    {

        #region Fields&Properties
        private int alltWordCount;
        public int AlltWordCount { get { return alltWordCount; } set { SetProperty(ref alltWordCount, value); } }

        private int knowWordCount;
        public int KnowWordCount { get { return knowWordCount; } set { SetProperty(ref knowWordCount, value); } }

        private int hasMP4Count;
        public int HasMP4Count { get { return hasMP4Count; } set { SetProperty(ref hasMP4Count, value); } }

        #endregion

        #region Properties

        #endregion

        #region Constructors
        public HeaderComponentViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
          : base(regionManager, dialogService, ea)
        {
            RefreshCount(RefreshWordCount.AllWordCount);
            EventAggregator.GetEvent<PubSubEvent<RefreshWordCount>>().Subscribe((x) => RefreshCount(x));
        }
        #endregion

        #region Overrides

        #endregion

        #region Private Methods
        private void RefreshCount(RefreshWordCount en)
        {
            if (en == RefreshWordCount.KonwnWordCount)
                KnowWordCount = WordDBService.IKnowWordCount();
            if (en == RefreshWordCount.AllWordCount)
            {
                AlltWordCount = WordDBService.AllWordCount();
                KnowWordCount = WordDBService.IKnowWordCount();
                HasMP4Count = WordDBService.HasMP4Count();
            }


        }
        #endregion



    }
}

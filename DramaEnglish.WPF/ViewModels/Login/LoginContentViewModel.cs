using DramaEnglish.Styling.EventAggregator;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace DramaEnglish.WPF.ViewModels.Login
{
    public class LoginContentViewModel : ViewModelBase
    {
        #region 字段属性

        public override string SetMyRegion { get { return "LoginRegion"; } }

        #endregion

        #region 构造方法

        public LoginContentViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
           : base(regionManager, dialogService, ea)
        {
        }

        #endregion

        #region 命令

        public DelegateCommand CloseCommand => new(() => EventAggregator.GetEvent<PubSubEvent<EnumFormStatus>>().Publish(EnumFormStatus.close));

        public DelegateCommand MiniCommand => new(() => EventAggregator.GetEvent<PubSubEvent<EnumFormStatus>>().Publish(EnumFormStatus.mini));

        #endregion

        #region 方法函数

        #endregion




    }
}

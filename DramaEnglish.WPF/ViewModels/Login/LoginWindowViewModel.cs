using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace DramaEnglish.WPF.ViewModels.Login
{
    public class LoginWindowViewModel : ViewModelBase
    {
        #region 字段属性

        public override string SetMyRegion { get { return "LoginRegion"; } }

        #endregion

        #region 构造方法

        public LoginWindowViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
           : base(regionManager, dialogService, ea)
        {
        }

        #endregion

        #region 命令

       

        #endregion

        #region 方法函数

        #endregion
    }
}

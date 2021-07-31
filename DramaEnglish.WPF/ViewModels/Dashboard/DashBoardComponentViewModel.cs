using DramaEnglish.WPF.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Regions; 
using Prism.Services.Dialogs;

namespace DramaEnglish.UserInterface.ViewModels.Dashboard
{
    public class DashBoardComponentViewModel : ViewModelBase
    {

        #region 字段属性

        #endregion

        #region 构造函数
        public DashBoardComponentViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
         : base(regionManager, dialogService, ea)
        {
        }
        #endregion

        #region 命令
        public DelegateCommand GoHHCommand =>  new (() => {

            var a = 1;
        });
        #endregion

        #region 方法函数

        #endregion

    }
}

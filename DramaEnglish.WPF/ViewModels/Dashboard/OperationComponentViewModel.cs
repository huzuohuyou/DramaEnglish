using DramaEnglish.WPF.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace DramaEnglish.UserInterface.ViewModels.Dashboard
{
    public class OperationComponentViewModel : ViewModelBase
    {

        #region 字段属性

        #endregion

        #region 构造函数
        public OperationComponentViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
         : base(regionManager, dialogService, ea)
        {
            GoHHCommand = new DelegateCommand(()=> {

                var a = 1;
            });
        }
        #endregion

        #region 命令

        public DelegateCommand GoHHCommand { get; set; }


        public DelegateCommand GoDramaCommand => new(()=> {
            RegionManager.RequestNavigate("DashBoardComponent", "DramaComponent");
        });
        #endregion

        #region 方法函数


        
        #endregion

    }
}

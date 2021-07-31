using DramaEnglish.UserInterface.Views.Drama;
using DramaEnglish.WPF.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace DramaEnglish.UserInterface.ViewModels.Dashboard
{
    public class OperationComponentViewModel : ViewModelBase
    {

        #region 字段属性

        #endregion

        #region 构造函数
        public OperationComponentViewModel(IContainerExtension container,IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
         : base(container,regionManager, dialogService, ea)
        {
            
        }
        #endregion

        #region 命令



        public DelegateCommand GoDramaCommand => new(()=> {
            //RegionManager.RegisterViewWithRegion("DashBoardComponent", typeof(DramaComponent));
            RegionManager.RegisterViewWithRegion("SwitchView", typeof(DramaComponent));
        });
        #endregion

        #region 方法函数


        
        #endregion

    }
}

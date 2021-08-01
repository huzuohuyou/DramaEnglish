using DramaEnglish.UserInterface.Views.Dashboard;
using DramaEnglish.UserInterface.Views.Dictnory;
using DramaEnglish.UserInterface.Views.Drama;
using DramaEnglish.UserInterface.Views.LearningLog;
using DramaEnglish.WPF.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;

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



        public DelegateCommand<string> SwitchComponentCommand => new((path)=> {

            var assemblyString = Assembly.GetExecutingAssembly().GetName().Name;
            Assembly serviceAss = Assembly.Load(assemblyString);
            Type[] serviceTypes = serviceAss.GetTypes();

            var type = serviceTypes.ToList().FirstOrDefault(r => r.Name.EndsWith($@"{path}"));
            if (type != null)
            {
                RegionManager.RegisterViewWithRegion("SwitchViewComponent", type);
                var view = RegionManager.Regions["SwitchViewComponent"].Views.FirstOrDefault(r => (r as UserControl).ToString().EndsWith(type.Name));
                RegionManager.Regions["SwitchViewComponent"].Activate(view);
            }
            //RegionManager.RegisterViewWithRegion("SwitchViewComponent", type);
        });
        #endregion

        #region 方法函数


        
        #endregion

    }
}

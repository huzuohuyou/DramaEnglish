using DramaEnglish.WPF.ViewModels.Dialog;
using DramaEnglish.WPF.Views.Dialog;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Linq;
using System.Reflection;

namespace DramaEnglish.Infrastructure.Register
{
    public static class PrismRegister
    {
        #region 注册入口

        private static bool registered = false;

        public static void ExecureRegister(IContainerRegistry containerRegistry, string assemblyString)
        {
            RegisterTypes(containerRegistry, assemblyString);
            RegisterViewWithRegion(containerRegistry, assemblyString);
        }


        private static void RegisterTypes(IContainerRegistry containerRegistry, string assemblyString)
        {

            Assembly serviceAss = Assembly.Load(assemblyString);
            Type[] serviceTypes = serviceAss.GetTypes();

            RegisterDialog(containerRegistry, serviceTypes);

            RegisterDialogWindow(containerRegistry, serviceTypes);


        }

        private static void RegisterViewWithRegion(IRegionManager regionManager, string assemblyString)
        {
            if (registered)
                return;
            Assembly serviceAss = Assembly.Load(assemblyString);
            Type[] serviceTypes = serviceAss.GetTypes();

            var contents = serviceTypes.ToList().Where(r => r.Name.EndsWith("Component"));
            foreach (var item in contents)
            {
                regionManager.RegisterViewWithRegion(item.Name, item);
            }
            foreach (var item in serviceTypes)
            {
                var attr = (AutoRegisterAttribute)item.GetCustomAttribute(typeof(AutoRegisterAttribute), false);
                if (attr != null && attr.Register && attr.RegionName != null)
                {
                    regionManager.RegisterViewWithRegion(attr.RegionName, item);
                }
            }

            registered = true;
        }


        private static void RegisterViewWithRegion(IContainerRegistry containerRegistry, string assemblyString)
        {
            var containerEx = containerRegistry as IContainerExtension;
            var regionManager = containerEx.Resolve<IRegionManager>();
            RegisterViewWithRegion(regionManager, assemblyString);
        }

        #endregion

        #region 方法函数

        private static void RegisterDialog(IContainerRegistry containerRegistry, Type[] types)
        {
            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();
            containerRegistry.RegisterDialog<SuccessDialog, SuccessDialogViewModel>();
            containerRegistry.RegisterDialog<WarningDialog, WarningDialogViewModel>();
            containerRegistry.RegisterDialog<NoticeDialog, NoticeDialogViewModel>();

        }
        private static void RegisterDialogWindow(IContainerRegistry containerRegistry, Type[] types)
        {
            containerRegistry.RegisterDialog<DailogWindow>();
        }


        [AttributeUsage(AttributeTargets.Class)]
        public class AutoRegisterAttribute : Attribute
        {
            public bool Register { get; }

            public string RegionName { get; }
            public AutoRegisterAttribute(bool register, string regionName)
            {
                Register = register;
                RegionName = regionName;
            }

            public AutoRegisterAttribute(bool register)
            {
                Register = register;
            }
        }
        #endregion

    }
}

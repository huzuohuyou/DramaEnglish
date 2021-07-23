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

        public static void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Assembly serviceAss = Assembly.Load("DramaEnglish.UserInterface");
            Type[] serviceTypes = serviceAss.GetTypes();

            RegisterDialog(containerRegistry, serviceTypes);

            RegisterDialogWindow(containerRegistry, serviceTypes);

            //RegisterForNavigation(containerRegistry, serviceTypes);

        }

        public static void RegisterViewWithRegion(IRegionManager regionManager) {
            if (registered)
                return;
            Assembly serviceAss = Assembly.Load("DramaEnglish.UserInterface");
            Type[] serviceTypes = serviceAss.GetTypes();

            var contents = serviceTypes.ToList().Where(r => r.Name.EndsWith("Componet"));
            foreach (var item in contents)
            {
                regionManager.RegisterViewWithRegion(item.Name, item);
            }
            registered = true;
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
       

        #endregion

    }
}

using DramaEnglish.WPF.ViewModels.Dialog;
using DramaEnglish.WPF.Views.Dialog;
using Prism.Ioc;
using System;
using System.Linq;
using System.Reflection;

namespace DramaEnglish.Infrastructure.Register
{
    public static class PrismRegister
    {
        #region 注册入口

        public static void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Assembly serviceAss = Assembly.Load("DramaEnglish.UserInterface");
            Type[] serviceTypes = serviceAss.GetTypes();

            RegisterDialog(containerRegistry, serviceTypes);

            RegisterDialogWindow(containerRegistry, serviceTypes);

            RegisterForNavigation(containerRegistry, serviceTypes);

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
        private static void RegisterForNavigation(IContainerRegistry containerRegistry, Type[] types)
        {
            var contents = types.ToList().Where(r => r.Name.EndsWith("Content"));
            foreach (var item in contents)
            {
                containerRegistry.RegisterForNavigation(item, item.Name);
            }
        }

        #endregion

    }
}

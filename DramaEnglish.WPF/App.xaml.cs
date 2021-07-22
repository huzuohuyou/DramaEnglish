using DramaEnglish.WPF.ViewModels.Dialog;
using DramaEnglish.WPF.Views.Dialog;
using DramaEnglish.WPF.Views.Login;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace DramaEnglish.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<LoginWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();
            containerRegistry.RegisterDialog<SuccessDialog, SuccessDialogViewModel>();
            containerRegistry.RegisterDialog<WarningDialog, WarningDialogViewModel>();
            containerRegistry.RegisterDialog<NoticeDialog, NoticeDialogViewModel>();
            containerRegistry.RegisterDialogWindow<DailogWindow>();
            containerRegistry.RegisterForNavigation<LoginContent>();
        }
    }
}

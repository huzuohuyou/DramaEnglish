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
            containerRegistry.RegisterForNavigation<LoginContent>();
        }
    }
}

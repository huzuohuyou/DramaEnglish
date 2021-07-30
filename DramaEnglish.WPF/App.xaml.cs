using DramaEnglish.Infrastructure.Register;
using DramaEnglish.WPF.Views.Login;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Regions;
using System.Reflection;
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
        public App()
        {
        }
        public App(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("LoginRegion", typeof(LoginComponent));
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
           
            PrismRegister.ExecureRegister(containerRegistry, assemblyName);
        }
    }
}

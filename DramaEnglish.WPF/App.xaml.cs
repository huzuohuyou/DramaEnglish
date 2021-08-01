using DramaEnglish.Infrastructure.Register;
using DramaEnglish.UserInterface.Views;
using DramaEnglish.WPF.Views.Login;
using Prism.DryIoc;
using Prism.Ioc;
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
        {//Container Resolve 哪个窗体RegionManagerr 才能管理里边的region
            return Container.Resolve<MainShellWindow>();
        }
        public App()
        {
        }
       
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            PrismRegister.ExecureRegister(containerRegistry, assemblyName);
        }
    }
}

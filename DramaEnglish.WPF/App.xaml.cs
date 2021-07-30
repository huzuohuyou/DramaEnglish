﻿using DramaEnglish.Infrastructure.Register;
using DramaEnglish.WPF.Views.Login;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
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
            this.Startup += new StartupEventHandler(App_Startup);
        }
  

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            PrismRegister.ExecureRegister(containerRegistry, assemblyName);
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            //UI线程未捕获异常处理事件
           this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            //Task线程内未捕获异常处理事件　　　　　
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            //非UI线程未捕获异常处理事件
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            //AppDomain.CurrentDomain.ArgumentOutOfRangeException
        }
        //public static class GloableExceptionCatcher
        //{



            public static void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
            {
                try
                {
                    e.Handled = true; //把 Handled 属性设为true，表示此异常已处理，程序可以继续运行，不会强制退出      
                    MessageBox.Show("捕获未处理异常:" + e.Exception.Message);
                }
                catch (Exception ex)
                {
                    //此时程序出现严重异常，将强制结束退出
                    MessageBox.Show("程序发生致命错误，将终止，请联系运营商！");
                }

            }

            public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                StringBuilder sbEx = new StringBuilder();
                if (e.IsTerminating)
                {
                    sbEx.Append("程序发生致命错误，将终止，请联系运营商！\n");
                }
                sbEx.Append("捕获未处理异常：");
                if (e.ExceptionObject is Exception)
                {
                    sbEx.Append(((Exception)e.ExceptionObject).Message);
                }
                else
                {
                    sbEx.Append(e.ExceptionObject);
                }
                MessageBox.Show(sbEx.ToString());
            }

            public static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs args)
            {
                //task线程内未处理捕获
                MessageBox.Show("捕获线程内未处理异常：" + args.Exception.Message);
                args.SetObserved();//设置该异常已察觉（这样处理后就不会引起程序崩溃）
            }
        //}
    }
}

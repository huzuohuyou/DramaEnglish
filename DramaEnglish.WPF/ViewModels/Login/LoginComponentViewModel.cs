using DramaEnglish.Infrastructure;
using DramaEnglish.Styling.EventAggregator;
using DramaEnglish.UserInterface.Views;
using DramaEnglish.WPF.Models;
using DramaEnglish.WPF.Views.Login;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;

namespace DramaEnglish.WPF.ViewModels.Login
{
    public class LoginComponentViewModel : ViewModelBase
    {
        #region 字段属性

        private User _currentUser = new User() { UserName= "admin" };
        public User CurrentUser
        {
            get { return _currentUser; }
            set { SetProperty(ref _currentUser, value); }
        }
        #endregion

        #region 构造方法

        public LoginComponentViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
           : base(regionManager, dialogService, ea)
        {
        }

        #endregion

        #region 命令

        public DelegateCommand<PasswordBox> LoginCommand =>
             new((passwordBox) =>
             {
                 if (string.IsNullOrWhiteSpace(this.CurrentUser.UserName))
                 {
                     DialogService.Show("WarningDialog", new DialogParameters($"message={"Name 不能为空!"}"), null);
                     return;
                 }
                 this.CurrentUser.Password = UserMd5(passwordBox.Password);
                 if (string.IsNullOrWhiteSpace(this.CurrentUser.Password))
                 {
                     DialogService.Show("WarningDialog", new DialogParameters($"message={"PassWord 不能为空!"}"), null);
                     return;
                 }
                 else if (!CheckUser(CurrentUser))
                 {
                     DialogService.Show("WarningDialog", new DialogParameters($"message={"Name 或者 PassWord 错误!"}"), null);
                     return;
                 }
                 ShellSwitcher.Switch<LoginWindow, MainShellWindow>();
             }, (passwordBox) =>
             {
                 this.IsCanExcute = Journal != null && Journal.CanGoForward;
                 return true;
             });

        public DelegateCommand CloseCommand => new(() => EventAggregator.GetEvent<PubSubEvent<EnumFormStatus>>().Publish(EnumFormStatus.close));

        public DelegateCommand MiniCommand => new(() => EventAggregator.GetEvent<PubSubEvent<EnumFormStatus>>().Publish(EnumFormStatus.mini));

        #endregion

        #region 方法函数
        private string UserMd5(string str)
        {
            byte[] buffer = Encoding.Default.GetBytes(str);
            try
            {
                MD5CryptoServiceProvider check;
                check = new MD5CryptoServiceProvider();
                byte[] somme = check.ComputeHash(buffer);
                string ret = "";
                foreach (byte a in somme)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("X");
                    else
                        ret += a.ToString("X");
                }
                return ret.ToLower();
            }
            catch
            {
                throw;
            }

        }

        private bool CheckUser(User currentUser)
        {
            try
            {
                return true;
                //var client = new CustomAsyncHttpClient();
                //var r = client.PostTask<Body>(UriHelper.USER_LOGIN, currentUser).Result;
                //Global.CurrentUser = r.Value?.User;
                //Global.Authorization = r.Value?.Authorization;
                //return Global.CurrentUser != null;
            }
            catch (Exception ex)
            {
                DialogService.Show("WarningDialog", new DialogParameters($"message={ex.Message}"), null);
                return false;
            }

        }
        #endregion




    }
}

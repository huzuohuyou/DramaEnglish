using DramaEnglish.Styling.EventAggregator;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows;

namespace DramaEnglish.WPF.ViewModels.Login
{
    public class LoginWindowComponentViewModel : ViewModelBase
    {
        #region 字段属性

        #endregion

        #region 构造方法

        public LoginWindowComponentViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
           : base(regionManager, dialogService, ea)
        {
           
        }

        #endregion

        #region 命令

        #endregion

        #region 方法函数
      
        #endregion
    }
}

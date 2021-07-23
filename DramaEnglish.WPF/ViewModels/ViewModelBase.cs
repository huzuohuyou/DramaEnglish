using DramaEnglish.Infrastructure.Register;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace DramaEnglish.WPF.ViewModels
{
    public abstract class ViewModelBase : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        #region 字段属性
        public virtual string SetMyRegion { get { return "ViewModelBase"; } }
        public IEventAggregator EventAggregator;
        public IRegionNavigationJournal Journal { get; set; }
        public IRegionManager RegionManager { get; set; }
        public IDialogService DialogService { get; set; }
        public bool KeepAlive => throw new NotImplementedException();

        private bool _isCanExcute;
        public bool IsCanExcute
        {
            get { return _isCanExcute; }
            set { SetProperty(ref _isCanExcute, value); }
        }
        #endregion

        #region 命令

        public DelegateCommand GoBackCommand => new DelegateCommand(() => { Journal.GoBack(); });

        public DelegateCommand GoForwardCommand => new DelegateCommand(() => { Journal.GoForward(); });
        
        #endregion

        #region 构造

        public ViewModelBase(IRegionManager regionManager, IDialogService dialogService, IEventAggregator eventAggregator)
        {
            RegionManager = regionManager;
            DialogService = dialogService;
            EventAggregator = eventAggregator;
        }
        #endregion

        #region 方法函数

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            Journal = navigationContext.NavigationService.Journal;
            OnNavigatedToBase(navigationContext);
        }

        public void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                RegionManager.RequestNavigate(SetMyRegion, navigatePath);
        }

        public virtual void OnNavigatedToBase(NavigationContext navigationContext) { }
        #endregion


    }
}

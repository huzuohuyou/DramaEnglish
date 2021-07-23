using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace DramaEnglish.WPF.ViewModels.Dialog
{
    public class NoticeDialogViewModel : BindableBase, IDialogAware
    {
        #region Fields

        public event Action<IDialogResult> RequestClose;

        #endregion

        #region Properties

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _title = "提示信息";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        #endregion

        #region Commands

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(ExecuteCloseDialogCommand));

        #endregion

        #region  Excutes

        void ExecuteCloseDialogCommand(string parameter)
        {
            ButtonResult result = ButtonResult.No;
            RaiseRequestClose(new DialogResult(result));
        }

        #endregion


        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
            var _title = parameters.GetValue<string>("title");
            if (!string.IsNullOrWhiteSpace(_title))
                Title = _title;
        }
    }
}

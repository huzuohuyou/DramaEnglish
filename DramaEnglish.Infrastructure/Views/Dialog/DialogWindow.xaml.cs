using Prism.Services.Dialogs;
using System.Windows;

namespace DramaEnglish.WPF.Views.Dialog
{
    /// <summary>
    /// MessageDlg.xaml 的交互逻辑
    /// </summary>
    public partial class DailogWindow : Window, IDialogWindow
    {
        public DailogWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}

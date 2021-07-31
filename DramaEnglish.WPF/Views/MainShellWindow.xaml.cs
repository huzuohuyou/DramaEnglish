using System.Windows;
using System.Windows.Input;

namespace DramaEnglish.UserInterface.Views
{
    /// <summary>
    /// MainShellWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainShellWindow : Window
    {
        public MainShellWindow()
        {
            InitializeComponent();
        }

        private void ContentControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}

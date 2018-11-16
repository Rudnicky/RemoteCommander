using System.Windows;
using System.Windows.Input;

namespace RemoteCommander.Server.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Ctor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        #endregion
    }
}

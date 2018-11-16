using RemoteCommander.Server.Interfaces;
using RemoteCommander.Server.Utils;
using RemoteCommander.Server.ViewModels;
using RemoteCommander.Server.Views;
using System.Windows;
using Unity;

namespace RemoteCommander.Server
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Protected Methods
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            UnityContainerSetup();
        }
        #endregion

        #region Private Methods
        private void UnityContainerSetup()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<INetworkManager, NetworkManager>();

            var mainWindowViewModel = container.Resolve<MainWindowViewModel>();
            var window = new MainWindow { DataContext = mainWindowViewModel };
            window.Show();
        }
        #endregion
    }
}

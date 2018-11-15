using RemoteCommander.Server.Interfaces;
using RemoteCommander.Server.Utils;
using RemoteCommander.Server.ViewModels;
using System.Windows;
using Unity;

namespace RemoteCommander.Server
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer();
            container.RegisterType<INetworkManager, NetworkManager>();

            var mainWindowViewModel = container.Resolve<MainWindowViewModel>();
            var window = new MainWindow { DataContext = mainWindowViewModel };
            window.Show();
        }
    }
}

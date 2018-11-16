using RemoteCommander.Shared.Interfaces;

namespace RemoteCommander.Server.ViewModels
{
    public sealed class MainWindowViewModel : BaseViewModel
    {
        #region Private Fields
        private INetworkManager _networkManager;
        #endregion

        #region Commands
        //private ICommand _mainWindowMouseDownCommand;
        //public ICommand MainWindowMouseDownCommand
        //{
        //    get
        //    {
        //        return _mainWindowMouseDownCommand ?? (_mainWindowMouseDownCommand = new RelayCommand<object>(e =>
        //        {
        //            MainWindow_MouseDown(e);
        //        }));
        //    }
        //}
        #endregion

        #region Constructor
        public MainWindowViewModel(INetworkManager networkManager)
        {
            this._networkManager = networkManager;

            RetrieveNetworkInterface(_networkManager);
        }
        #endregion

        #region Private Methods
        private void RetrieveNetworkInterface(INetworkManager networkManager)
        {
            if (networkManager != null)
            {
                networkManager.GetCurrentNetworkInterface();
            }
        }
        #endregion
    }
}

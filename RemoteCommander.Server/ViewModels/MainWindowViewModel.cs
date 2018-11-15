using RemoteCommander.Server.Interfaces;

namespace RemoteCommander.Server.ViewModels
{
    public sealed class MainWindowViewModel : BaseViewModel
    {
        #region Private Fields
        private INetworkManager _networkManager;
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

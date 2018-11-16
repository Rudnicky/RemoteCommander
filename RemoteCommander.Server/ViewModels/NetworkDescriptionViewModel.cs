using RemoteCommander.Shared.Interfaces;
using RemoteCommander.Shared.Models;
using System.Collections.ObjectModel;

namespace RemoteCommander.Server.ViewModels
{
    public class NetworkDescriptionViewModel : BaseViewModel
    {
        #region Private Fields
        private INetworkManager _networkManager;
        #endregion

        #region Properties
        private ObservableCollection<NetworkDescriptionModel> _networkDescriptionModels = new ObservableCollection<NetworkDescriptionModel>();
        public ObservableCollection<NetworkDescriptionModel> NetworkDescriptionModels
        {
            get
            {
                return _networkDescriptionModels;
            }
            set
            {
                _networkDescriptionModels = value;
                OnPropertyChanged(nameof(NetworkDescriptionModels));
            }
        }

        private string _availableNetworks;
        public string AvailableNetworks
        {
            get
            {
                return _availableNetworks;
            }
            set
            {
                if (_availableNetworks != value)
                {
                    _availableNetworks = value;
                    OnPropertyChanged(nameof(AvailableNetworks));
                }
            }
        }
        #endregion

        #region Constructor
        public NetworkDescriptionViewModel(INetworkManager networkManager)
        {
            this._networkManager = networkManager;
            Setup();
        }
        #endregion

        #region Private Methods
        private void Setup()
        {
            if (_networkManager != null)
            {
                NetworkDescriptionModels = _networkManager.GetCurrentData();
                AvailableNetworks = NetworkDescriptionModels.Count.ToString();
            }
        }
        #endregion
    }
}

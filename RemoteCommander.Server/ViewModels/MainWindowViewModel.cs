using RemoteCommander.Shared.Interfaces;
using RemoteCommander.Shared.Utils;
using System;
using System.Windows.Input;

namespace RemoteCommander.Server.ViewModels
{
    public sealed class MainWindowViewModel : BaseViewModel
    {
        #region Private Fields
        private readonly INetworkManager _networkManager;
        #endregion

        #region Properties
        private object _currentContent;
        public object CurrentContent
        {
            get
            {
                return _currentContent;
            }
            set
            {
                if (_currentContent != value)
                {
                    _currentContent = value;
                    OnPropertyChanged(nameof(CurrentContent));
                }
            }
        }
        #endregion

        #region Commands 
        private ICommand _networkInformationButtonClickedCommand;
        public ICommand NetworkInformationButtonClickedCommand
        {
            get
            {
                return _networkInformationButtonClickedCommand ?? (_networkInformationButtonClickedCommand = new RelayCommand<object>(e =>
                {
                    NetworkInformationButton_Clicked(e);
                }));
            }
        }

        private ICommand _availableHostsButtonClickedCommand;
        public ICommand AvailableHostsButtonClickedCommand
        {
            get
            {
                return _availableHostsButtonClickedCommand ?? (_availableHostsButtonClickedCommand = new RelayCommand<object>(e =>
                {
                    AvailableHostsButton_Clicked(e);
                }));
            }
        }
        #endregion

        #region Constructor
        public MainWindowViewModel(INetworkManager networkManager)
        {
            this._networkManager = networkManager;
        }
        #endregion

        #region Private Methods
        private void NetworkInformationButton_Clicked(object e)
        {
            if (_networkManager != null)
            {
                CurrentContent = new NetworkDescriptionViewModel(_networkManager);
            }
        }

        private void AvailableHostsButton_Clicked(object e)
        {
            // TODO:
        }
        #endregion
    }
}

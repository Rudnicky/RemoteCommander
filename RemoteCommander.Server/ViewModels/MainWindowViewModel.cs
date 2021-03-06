﻿using RemoteCommander.Shared.Interfaces;
using RemoteCommander.Shared.Utils;
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

        private ICommand _settingsButtonClickedCommand;
        public ICommand SettingsButtonClickedCommand
        {
            get
            {
                return _settingsButtonClickedCommand ?? (_settingsButtonClickedCommand = new RelayCommand<object>(e =>
                {
                    SettingsButton_Clicked(e);
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
                if (CurrentContent != null)
                {
                    var availableHostsViewModel = CurrentContent as AvailableHostsViewModel;
                    if (availableHostsViewModel != null)
                    {
                        availableHostsViewModel.Dispose();
                    }
                }

                CurrentContent = new NetworkDescriptionViewModel(_networkManager);
            }
        }

        private void AvailableHostsButton_Clicked(object e)
        {
            if (_networkManager != null)
            {
                CurrentContent = new AvailableHostsViewModel(_networkManager);
            }
        }

        private void SettingsButton_Clicked(object e)
        {
            // TODO:
        }
        #endregion
    }
}

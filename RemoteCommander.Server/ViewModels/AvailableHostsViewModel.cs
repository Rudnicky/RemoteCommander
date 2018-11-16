using RemoteCommander.Shared.Interfaces;
using RemoteCommander.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;

namespace RemoteCommander.Server.ViewModels
{
    public class AvailableHostsViewModel : BaseViewModel
    {
        #region Private Fields
        private const int TIMEOUT = 2000;
        private const int ATTEMPTS = 4;
        private readonly INetworkManager _networkManager;
        private string _networkGateway;
        private int _hostsAmount;
        private List<Ping> _listOfPings = new List<Ping>();
        private bool _cancelRequested = false;
        #endregion

        #region Properties
        private ObservableCollection<AvailableHost> _availableHostsModels = new ObservableCollection<AvailableHost>();
        public ObservableCollection<AvailableHost> AvailableHostsModels
        {
            get
            {
                return _availableHostsModels;
            }
            set
            {
                _availableHostsModels = value;
                OnPropertyChanged(nameof(AvailableHostsModels));
            }
        }

        private string _availableHostss;
        public string AvailableHosts
        {
            get
            {
                return _availableHostss;
            }
            set
            {
                if (_availableHostss != value)
                {
                    _availableHostss = value;
                    OnPropertyChanged(nameof(AvailableHosts));
                }
            }
        }
        #endregion

        #region Constructor
        public AvailableHostsViewModel(INetworkManager networkManager)
        {
            this._networkManager = networkManager;
            SetupAsync();
        }
        #endregion

        #region Private Methods
        private async Task SetupAsync()
        {
            if (_networkManager != null)
            {
                _networkGateway = _networkManager.GetNetworkGateway();
                await PingHostsAsync();
            }
        }

        private async Task PingHostsAsync()
        {
            if (_networkGateway != string.Empty)
            {
                string[] splittedIps = _networkGateway.Split('.');

                for (int i=2; i <= 255; i++)
                {
                    if (_cancelRequested)
                        break;

                    string ping = splittedIps[0] + "." + splittedIps[1] + "." + splittedIps[2] + "." + i;
                    await PingAsync(ping, ATTEMPTS, TIMEOUT);
                }
            }
        }

        private async Task PingAsync(string host, int attempts, int timeout)
        {
            for (int i = 0; i < attempts; i++)
            {
                await Task.Factory.StartNew(() =>
                {
                    try
                    {
                        if (!_cancelRequested)
                        {
                            var ping = new Ping();
                            ping.PingCompleted += Ping_PingCompleted;
                            ping.SendAsync(host, timeout, host);

                            _listOfPings.Add(ping);
                        }
                    }
                    catch (Exception)
                    {
                        // do nothing and let it try again until
                        // attempts are exausted. Exceptions are thrown
                        // for normal ping failures like address lookups
                        // because of that these errors are supressed.
                    }
                });
            }
        }

        private void Ping_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = e.UserState as string;
            if (ip != string.Empty && e.Reply.Status == IPStatus.Success)
            {
                if (_networkManager != null)
                {
                    string hostName = _networkManager.GetHostName(ip);
                    string macAddress = _networkManager.GetMacAddress(ip);

                    var availableHost = new AvailableHost
                    {
                        IP = ip,
                        HostName = hostName,
                        MacAddress = macAddress
                    };

                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (!_cancelRequested)
                        {
                            AvailableHostsModels.Add(availableHost);
                        }
                    }));
                }
            }

            _hostsAmount++;
            AvailableHosts = _hostsAmount.ToString();
        }
        #endregion

        #region Public Methods
        public void Dispose()
        {
            _cancelRequested = true;

            foreach (var ping in _listOfPings)
            {
                ping.PingCompleted -= Ping_PingCompleted;
            }
        }
        #endregion
    }
}

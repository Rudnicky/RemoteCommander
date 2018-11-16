using RemoteCommander.Shared.Interfaces;
using RemoteCommander.Shared.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;

namespace RemoteCommander.Server.ViewModels
{
    public class AvailableHostsViewModel : BaseViewModel
    {
        #region Private Fields
        private readonly INetworkManager _networkManager;
        private string _networkGateway;
        private int _hostsAmount;
        private Ping _ping;
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
            Setup();
        }
        #endregion

        #region Private Methods
        private void Setup()
        {
            if (_networkManager != null)
            {
                _networkGateway = _networkManager.GetNetworkGateway();
                PingHosts();
            }
        }

        private void PingHosts()
        {
            if (_networkGateway != string.Empty)
            {
                string[] splittedIps = _networkGateway.Split('.');

                for (int i=2; i <= 255; i++)
                {
                    string ping = splittedIps[0] + "." + splittedIps[1] + "." + splittedIps[2] + "." + i;
                    Ping(ping, 4, 2000);
                }
            }
        }

        private void Ping(string host, int attempts, int timeout)
        {
            _hostsAmount = 0;

            for (int i=0; i < attempts; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        _ping = new Ping();
                        _ping.PingCompleted += Ping_PingCompleted;
                        _ping.SendAsync(host, timeout, host);
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
                        AvailableHostsModels.Add(availableHost);
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
            if (_ping != null)
            {
                _ping.PingCompleted -= Ping_PingCompleted;
            }
        }
        #endregion
    }
}

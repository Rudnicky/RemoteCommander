using RemoteCommander.Shared.Interfaces;
using RemoteCommander.Shared.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;

namespace RemoteCommander.Shared.Utils
{
    public sealed class NetworkManager : INetworkManager
    {
        #region Constructor
        public NetworkManager()
        {

        }
        #endregion

        #region Public Methods
        public ObservableCollection<NetworkDescriptionModel> GetCurrentData()
        {
            var listOfInformations = new ObservableCollection<NetworkDescriptionModel>();

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            if (networkInterfaces != null)
            {
                foreach (var networkInterface in networkInterfaces)
                {
                    var networkDescriptionModel = new NetworkDescriptionModel
                    {
                        Description = networkInterface.Description,
                        Id = networkInterface.Id,
                        Name = networkInterface.Name,
                        Type = networkInterface.NetworkInterfaceType.ToString(),
                        Status = networkInterface.OperationalStatus.ToString(),
                        Speed = networkInterface.Speed.ToString(),
                        Multicast = networkInterface.SupportsMulticast.ToString()
                    };

                    listOfInformations.Add(networkDescriptionModel);
                }
            }

            return listOfInformations;
        }
        #endregion
    }
}

using RemoteCommander.Shared.Interfaces;
using RemoteCommander.Shared.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
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

        public string GetNetworkGateway()
        {
            var ip = string.Empty;

            foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface != null && networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (var gatewayIPAddressInfo in networkInterface.GetIPProperties().GatewayAddresses)
                    {
                        ip = gatewayIPAddressInfo.Address.ToString();
                    }
                }
            }

            return ip;
        }

        public string GetHostName(string ipAddress)
        {
            try
            {
                var hostEntry = Dns.GetHostEntry(ipAddress);
                if (hostEntry != null)
                {
                    return hostEntry.HostName;
                }
            }
            catch (Exception)
            {
                // something went wrong
                // create a logger 
            }
            return string.Empty;
        }

        public string GetMacAddress(string ipAddress)
        {
            var macAddress = string.Empty;
            var process = new Process();
            process.StartInfo.FileName = "arp";
            process.StartInfo.Arguments = "-a " + ipAddress;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            var suboutputs = output.Split('-');

            if (suboutputs.Length >= 8)
            {
                 return suboutputs[3].Substring(Math.Max(0, suboutputs[3].Length - 2))
                               + "-" + suboutputs[4] + "-" + suboutputs[5] + "-" + suboutputs[6]
                               + "-" + suboutputs[7] + "-"
                               + suboutputs[8].Substring(0, 2);
            }
            else
            {
                return "Own machine";
            }
        }
        #endregion
    }
}

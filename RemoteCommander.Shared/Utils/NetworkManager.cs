using RemoteCommander.Shared.Interfaces;
using System.Diagnostics;
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
        public void GetCurrentNetworkInterface()
        {
            NetworkInterface[] niArr = NetworkInterface.GetAllNetworkInterfaces();

            Debug.WriteLine("Retriving basic information of network.\n\n");

            //Display all information of NetworkInterface using foreach loop.

            foreach (NetworkInterface tempNetworkInterface in niArr)

            {

                Debug.WriteLine("Network Discription  :  " + tempNetworkInterface.Description);

                Debug.WriteLine("Network ID  :  " + tempNetworkInterface.Id);

                Debug.WriteLine("Network Name  :  " + tempNetworkInterface.Name);

                Debug.WriteLine("Network interface type  :  " + tempNetworkInterface.NetworkInterfaceType.ToString());

                Debug.WriteLine("Network Operational Status   :   " + tempNetworkInterface.OperationalStatus.ToString());

                Debug.WriteLine("Network Spped   :   " + tempNetworkInterface.Speed);

                Debug.WriteLine("Support Multicast   :   " + tempNetworkInterface.SupportsMulticast);

            }

        }
        #endregion
    }
}

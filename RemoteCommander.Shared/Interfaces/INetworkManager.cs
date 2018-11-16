using RemoteCommander.Shared.Models;
using System.Collections.ObjectModel;

namespace RemoteCommander.Shared.Interfaces
{
    public interface INetworkManager
    {
        ObservableCollection<NetworkDescriptionModel> GetCurrentData();
    }
}

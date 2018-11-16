using System.Net.NetworkInformation;

namespace RemoteCommander.Shared.Models
{
    public class NetworkDescriptionModel
    {
        public string Description { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public string Speed { get; set; }

        public string Multicast { get; set; }
    }
}

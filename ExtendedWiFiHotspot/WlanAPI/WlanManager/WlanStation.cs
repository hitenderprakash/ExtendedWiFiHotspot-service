// Modified work of VirtualRouter Plus 
//http://virtualwifihotspot.codeplex.com/releases/view/101496
//http://virtualwifihotspot.codeplex.com/license
//************************************************************ 
namespace ExtendedWiFi
{
    public class WlanStation
    {
        public WlanStation(WLAN_HOSTED_NETWORK_PEER_STATE state)
        {
            this.State = state;
        }

        public WLAN_HOSTED_NETWORK_PEER_STATE State { get; set; }

        public string MacAddress
        {
            get
            {
                return this.State.PeerMacAddress.ConvertToString();
            }
        }
    }
}

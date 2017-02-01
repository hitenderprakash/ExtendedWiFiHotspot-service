///*****************************************************************************************************
//Native WiFi Structures
//http://msdn.microsoft.com/en-us/library/windows/desktop/ms706276(v=vs.85).aspx
///*****************************************************************************************************
using System;
using System.Runtime.InteropServices;


namespace ExtendedWiFi
{
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DOT11_BSSID_LIST
    {
        NDIS_OBJECT_HEADER header;
        uint uNumOfEntries; // ULONG
        uint uTotalNumOfEntries; // ULONG
        DOT11_MAC_ADDRESS[] BSSIDs;
    }
///*****************************************************************************************************

///*****************************************************************************************************
[StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DOT11_MAC_ADDRESS
    {
        public byte one;
        public byte two;
        public byte three;
        public byte four;
        public byte five;
        public byte six;
    }
///*****************************************************************************************************

///*****************************************************************************************************
[StructLayout(LayoutKind.Sequential)] //, CharSet = CharSet.Ansi)]
    public struct DOT11_SSID
    {

        /// ULONG->unsigned int
        public int uSSIDLength; //uint

        /// UCHAR[]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string ucSSID;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        //public byte[] ucSSID;
    }
///*****************************************************************************************************

///*****************************************************************************************************
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NDIS_OBJECT_HEADER
    {
        string Type; //UCHAR
        string Revision; //UCHAR
        ushort Size;
    }
///*****************************************************************************************************

///*****************************************************************************************************
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_ASSOCIATION_ATTRIBUTES
    {
        DOT11_SSID dot11Ssid;
        DOT11_BSS_TYPE dot11BssType;
        DOT11_MAC_ADDRESS dot11Bssid;
        DOT11_PHY_TYPE dot11PhyType;
        uint uDot11PhyIndex; //ULONG
        uint wlanSignalQuality; //WLAN_SIGNAL_QUALITY -> ULONG
        uint ulRxRate; //ULONG
        uint ulTxRate; //ULONG
    }
///*****************************************************************************************************

///*****************************************************************************************************
//http://msdn.microsoft.com/en-us/library/ms707403%28VS.85%29.aspx
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_AVAILABLE_NETWORK
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strProfileName; // WCHAR[256]
        public DOT11_SSID dot11Ssid;
        public DOT11_BSS_TYPE dot11BssType;
        public uint uNumberOfBssids; // ULONG
        public bool bNetworkConnectable; // BOOL
        public uint wlanNotConnectableReason; // WLAN_REASON_CODE
        public uint uNumberOfPhyTypes; // ULONG
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public DOT11_PHY_TYPE[] dot11PhyTypes;
        public bool bMorePhyTypes; // BOOL
        public uint wlanSignalQuality; // WLAN_SIGNAL_QUALITY
        public bool bSecurityEnabled; // BOOL
        public DOT11_AUTH_ALGORITHM dot11DefaultAuthAlgorithm;
        public DOT11_CIPHER_ALGORITHM dot11DefaultCipherAlgorithm;
        public uint dwFlags; // DWORD
        public uint dwReserved; // DWORD
    }
///*****************************************************************************************************

///*****************************************************************************************************
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct WLAN_AVAILABLE_NETWORK_LIST
    {
        internal uint dwNumberOfItems;
        internal uint dwIndex;
        internal WLAN_AVAILABLE_NETWORK[] wlanAvailableNetwork;

        internal WLAN_AVAILABLE_NETWORK_LIST(IntPtr ppAvailableNetworkList)
        {
            dwNumberOfItems = (uint)Marshal.ReadInt32(ppAvailableNetworkList);
            dwIndex = (uint)Marshal.ReadInt32(ppAvailableNetworkList, 4);
            wlanAvailableNetwork = new WLAN_AVAILABLE_NETWORK[dwNumberOfItems];

            for (int i = 0; i < dwNumberOfItems; i++)
            {
                IntPtr pWlanAvailableNetwork = new IntPtr(ppAvailableNetworkList.ToInt32() + i * Marshal.SizeOf(typeof(WLAN_AVAILABLE_NETWORK)) + 8);
                wlanAvailableNetwork[i] = (WLAN_AVAILABLE_NETWORK)Marshal.PtrToStructure(pWlanAvailableNetwork, typeof(WLAN_AVAILABLE_NETWORK));
            }
        }
    }
///*****************************************************************************************************

///*****************************************************************************************************
//http://msdn.microsoft.com/en-us/library/ms706842%28VS.85%29.aspx
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_CONNECTION_ATTRIBUTES
    {
        WLAN_INTERFACE_STATE isState;
        WLAN_CONNECTION_MODE wlanCOnnectionMode;
        string strProfileMode; //WCHAR[256];
        WLAN_ASSOCIATION_ATTRIBUTES wlanAssociationAttributes;
        WLAN_SECURITY_ATTRIBUTES wlanSecurityAttributes;
    }
///*****************************************************************************************************

///*****************************************************************************************************
//http://msdn.microsoft.com/en-us/library/ms706851%28VS.85%29.aspx
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_CONNECTION_PARAMETERS
    {
        WLAN_CONNECTION_MODE wlanConnectionMode;
        string strProfile; // LPCWSTR
        DOT11_SSID pDot11Ssid;
        DOT11_BSSID_LIST pDesiredBssidList;
        DOT11_BSS_TYPE dot11BssType;
        uint dwFlags; // DWORD
    }
///*****************************************************************************************************


///*****************************************************************************************************
[StructLayout(LayoutKind.Sequential)] //, CharSet =  CharSet.Unicode)]
    public struct WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS
    {
        public DOT11_SSID hostedNetworkSSID;
        public UInt32 dwMaxNumberOfPeers; // DWORD
    }
///*****************************************************************************************************

///*****************************************************************************************************
//http://msdn.microsoft.com/en-us/library/dd439500%28VS.85%29.aspx
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE
    {
        public WLAN_HOSTED_NETWORK_PEER_STATE OldState;
        public WLAN_HOSTED_NETWORK_PEER_STATE NewState;
        public WLAN_HOSTED_NETWORK_REASON Reason; //NewState;
    }
///*****************************************************************************************************

///*****************************************************************************************************
[StructLayout(LayoutKind.Sequential)]
    public struct WLAN_HOSTED_NETWORK_PEER_STATE
    {
        public DOT11_MAC_ADDRESS PeerMacAddress;
        public WLAN_HOSTED_NETWORK_PEER_AUTH_STATE PeerAuthState;
    }
///*****************************************************************************************************

///*****************************************************************************************************
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_HOSTED_NETWORK_RADIO_STATE
    {
        DOT11_RADIO_STATE dot11SoftwareRadioState;
        DOT11_RADIO_STATE dot11HardwareRadioState;
    }
///*****************************************************************************************************

///*****************************************************************************************************
 [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_HOSTED_NETWORK_SECURITY_SETTINGS
    {
        DOT11_AUTH_ALGORITHM dot11AuthAlgo;
        DOT11_CIPHER_ALGORITHM dot11CipherAlgo;
    }
///*****************************************************************************************************

///*****************************************************************************************************
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_HOSTED_NETWORK_STATE_CHANGE
    {
        public WLAN_HOSTED_NETWORK_STATE OldState;
        public WLAN_HOSTED_NETWORK_STATE NewState;
        public WLAN_HOSTED_NETWORK_REASON Reason; // NewState;
    }
///*****************************************************************************************************

///*****************************************************************************************************
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_HOSTED_NETWORK_STATUS
    {
        public WLAN_HOSTED_NETWORK_STATE HostedNetworkState;
        public Guid IPDeviceID;
        public DOT11_MAC_ADDRESS wlanHostedNetworkBSSID;
        public DOT11_PHY_TYPE dot11PhyType;
        public uint ulChannelFrequency; // ULONG
        public uint dwNumberOfPeers; // DWORD
        //public WLAN_HOSTED_NETWORK_PEER_STATE PeerList[1];
        public IntPtr PeerList;
    }
///*****************************************************************************************************

///*****************************************************************************************************
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_INTERFACE_INFO
    {
        /// GUID->_GUID
        public Guid InterfaceGuid;

        /// WCHAR[256]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strInterfaceDescription;

        /// WLAN_INTERFACE_STATE->_WLAN_INTERFACE_STATE
        public WLAN_INTERFACE_STATE isState;
    }
///*****************************************************************************************************

///*****************************************************************************************************
/// <summary>
        /// Contains an array of NIC information
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WLAN_INTERFACE_INFO_LIST
        {
        /// <summary>
        /// Length of <see cref="InterfaceInfo"/> array
        /// </summary>
        public Int32 dwNumberOfItems;
        /// <summary>
        /// This member is not used by the wireless service. Applications can use this member when processing individual interfaces.
        /// </summary>
        public Int32 dwIndex;
        /// <summary>
        /// Array of WLAN interfaces.
        /// </summary>
        public WLAN_INTERFACE_INFO[] InterfaceInfo;

        /// <summary>
        /// Constructor for WLAN_INTERFACE_INFO_LIST.
        /// Constructor is needed because the InterfaceInfo member varies based on how many adapters are in the system.
        /// </summary>
        /// <param name="pList">the unmanaged pointer containing the list.</param>
        public WLAN_INTERFACE_INFO_LIST(IntPtr pList)
        {
            // The first 4 bytes are the number of WLAN_INTERFACE_INFO structures.
            dwNumberOfItems = Marshal.ReadInt32(pList, 0);

            // The next 4 bytes are the index of the current item in the unmanaged API.
            dwIndex = Marshal.ReadInt32(pList, 4);

            // Construct the array of WLAN_INTERFACE_INFO structures.
            InterfaceInfo = new WLAN_INTERFACE_INFO[dwNumberOfItems];

            for (int i = 0; i < dwNumberOfItems; i++)
            {
            // The offset of the array of structures is 8 bytes past the beginning. Then, take the index and multiply it by the number of bytes in the structure.
            // the length of the WLAN_INTERFACE_INFO structure is 532 bytes - this was determined by doing a sizeof(WLAN_INTERFACE_INFO) in an unmanaged C++ app.
            IntPtr pItemList = new IntPtr(pList.ToInt32() + (i * 532) + 8);

            // Construct the WLAN_INTERFACE_INFO structure, marshal the unmanaged structure into it, then copy it to the array of structures.
            WLAN_INTERFACE_INFO wii = new WLAN_INTERFACE_INFO();
            wii = (WLAN_INTERFACE_INFO)Marshal.PtrToStructure(pItemList, typeof(WLAN_INTERFACE_INFO));
            InterfaceInfo[i] = wii;
            }
        }
    }
///*****************************************************************************************************

///*****************************************************************************************************
/// <summary>
    /// Contains information provided when registering for notifications.
    /// </summary>
    /// <remarks>
    /// Corresponds to the native <c>WLAN_NOTIFICATION_DATA</c> type.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct WLAN_NOTIFICATION_DATA
    {
        /// <summary>
        /// Specifies where the notification comes from.
        /// </summary>
        /// <remarks>
        /// On Windows XP SP2, this field must be set to <see cref="WlanNotificationSource.None"/>, <see cref="WlanNotificationSource.All"/> or <see cref="WlanNotificationSource.ACM"/>.
        /// </remarks>
        public WLAN_NOTIFICATION_SOURCE notificationSource;
        /// <summary>
        /// Indicates the type of notification. The value of this field indicates what type of associated data will be present in <see cref="dataPtr"/>.
        /// </summary>
        public int notificationCode;
        /// <summary>
        /// Indicates which interface the notification is for.
        /// </summary>
        public Guid interfaceGuid;
        /// <summary>
        /// Specifies the size of <see cref="dataPtr"/>, in bytes.
        /// </summary>
        public int dataSize;
        /// <summary>
        /// Pointer to additional data needed for the notification, as indicated by <see cref="notificationCode"/>.
        /// </summary>
        public IntPtr dataPtr;

        /// <summary>
        /// Gets the notification code (in the correct enumeration type) according to the notification source.
        /// </summary>
        public object NotificationCode
        {
            get
            {
                if (notificationSource == WLAN_NOTIFICATION_SOURCE.MSM)
                    return (WLAN_NOTIFICATION_CODE_MSM)notificationCode;
                else if (notificationSource == WLAN_NOTIFICATION_SOURCE.ACM)
                    return (WLAN_NOTIFICATION_CODE_ACM)notificationCode;
                else
                    return notificationCode;
            }

        }
    } 
///*****************************************************************************************************

///*****************************************************************************************************
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_PROFILE_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strProfileName;
        public uint dwFlags;
    }
///*****************************************************************************************************

///*****************************************************************************************************
public struct WLAN_PROFILE_INFO_LIST
    {
        public uint dwNumberOfItems;
        public uint dwIndex;
        public WLAN_PROFILE_INFO[] ProfileInfo;

        public WLAN_PROFILE_INFO_LIST(IntPtr ppProfileList)
        {
            dwNumberOfItems = (uint)Marshal.ReadInt32(ppProfileList);
            dwIndex = (uint)Marshal.ReadInt32(ppProfileList, 4);
            ProfileInfo = new WLAN_PROFILE_INFO[dwNumberOfItems];
            IntPtr ppProfileListTemp = new IntPtr(ppProfileList.ToInt32() + 8);

            for (int i = 0; i < dwNumberOfItems; i++)
            {
                ppProfileList = new IntPtr(ppProfileListTemp.ToInt32() + i * Marshal.SizeOf(typeof(WLAN_PROFILE_INFO)));
                ProfileInfo[i] = (WLAN_PROFILE_INFO)Marshal.PtrToStructure(ppProfileList, typeof(WLAN_PROFILE_INFO));
            }
        }
    }
///*****************************************************************************************************

///*****************************************************************************************************
//http://msdn.microsoft.com/en-us/library/ms707400%28VS.85%29.aspx
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_SECURITY_ATTRIBUTES
    {
        bool bSecurityEnabled;
        bool bOneXEnabled;
        DOT11_AUTH_ALGORITHM dot11AuthAlgorithm;
        DOT11_CIPHER_ALGORITHM dot11CipherAlgorithm;
    }
///*****************************************************************************************************
}


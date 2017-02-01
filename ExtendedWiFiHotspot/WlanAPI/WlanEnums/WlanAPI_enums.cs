// Native WiFi enumerations 
//http://msdn.microsoft.com/en-us/library/windows/desktop/ms706273(v=vs.85).aspx
//*******************************************************************************
using System;

namespace ExtendedWiFi
{ 

public enum DOT11_AUTH_ALGORITHM
    {

        /// DOT11_AUTH_ALGO_80211_OPEN -> 1
        DOT11_AUTH_ALGO_80211_OPEN = 1,

        /// DOT11_AUTH_ALGO_80211_SHARED_KEY -> 2
        DOT11_AUTH_ALGO_80211_SHARED_KEY = 2,

        /// DOT11_AUTH_ALGO_WPA -> 3
        DOT11_AUTH_ALGO_WPA = 3,

        /// DOT11_AUTH_ALGO_WPA_PSK -> 4
        DOT11_AUTH_ALGO_WPA_PSK = 4,

        /// DOT11_AUTH_ALGO_WPA_NONE -> 5
        DOT11_AUTH_ALGO_WPA_NONE = 5,

        /// DOT11_AUTH_ALGO_RSNA -> 6
        DOT11_AUTH_ALGO_RSNA = 6,

        /// DOT11_AUTH_ALGO_RSNA_PSK -> 7
        DOT11_AUTH_ALGO_RSNA_PSK = 7,

        /// DOT11_AUTH_ALGO_IHV_START -> 0x80000000
        DOT11_AUTH_ALGO_IHV_START = -2147483648,

        /// DOT11_AUTH_ALGO_IHV_END -> 0xffffffff
        DOT11_AUTH_ALGO_IHV_END = -1,
    }
//*****************************************************************************************************

//*****************************************************************************************************
/// <summary>
    /// Represents an 802.11 Basic Service Set type
    /// </summary>
    public enum DOT11_BSS_TYPE
    {
        ///<summary>
        /// dot11_BSS_type_infrastructure -> 1
        ///</summary>
        dot11_BSS_type_infrastructure = 1,

        ///<summary>
        /// dot11_BSS_type_independent -> 2
        ///</summary>
        dot11_BSS_type_independent = 2,

        ///<summary>
        /// dot11_BSS_type_any -> 3
        ///</summary>
        dot11_BSS_type_any = 3,
    }
//*****************************************************************************************************

//*****************************************************************************************************
 public enum DOT11_CIPHER_ALGORITHM
    {

        /// DOT11_CIPHER_ALGO_NONE -> 0x00
        DOT11_CIPHER_ALGO_NONE = 0,

        /// DOT11_CIPHER_ALGO_WEP40 -> 0x01
        DOT11_CIPHER_ALGO_WEP40 = 1,

        /// DOT11_CIPHER_ALGO_TKIP -> 0x02
        DOT11_CIPHER_ALGO_TKIP = 2,

        /// DOT11_CIPHER_ALGO_CCMP -> 0x04
        DOT11_CIPHER_ALGO_CCMP = 4,

        /// DOT11_CIPHER_ALGO_WEP104 -> 0x05
        DOT11_CIPHER_ALGO_WEP104 = 5,

        /// DOT11_CIPHER_ALGO_WPA_USE_GROUP -> 0x100
        DOT11_CIPHER_ALGO_WPA_USE_GROUP = 256,

        /// DOT11_CIPHER_ALGO_RSN_USE_GROUP -> 0x100
        DOT11_CIPHER_ALGO_RSN_USE_GROUP = 256,

        /// DOT11_CIPHER_ALGO_WEP -> 0x101
        DOT11_CIPHER_ALGO_WEP = 257,

        /// DOT11_CIPHER_ALGO_IHV_START -> 0x80000000
        DOT11_CIPHER_ALGO_IHV_START = -2147483648,

        /// DOT11_CIPHER_ALGO_IHV_END -> 0xffffffff
        DOT11_CIPHER_ALGO_IHV_END = -1,
    }
//*****************************************************************************************************

//*****************************************************************************************************
 public enum DOT11_PHY_TYPE
    {
        dot11_phy_type_unknown,

        dot11_phy_type_any,

        dot11_phy_type_fhss,

        dot11_phy_type_dsss,

        dot11_phy_type_irbaseband,

        dot11_phy_type_ofdm,

        dot11_phy_type_hrdsss,

        dot11_phy_type_erp,

        dot11_phy_type_ht,

        dot11_phy_type_IHV_start,

        dot11_phy_type_IHV_end,
    }
//*****************************************************************************************************

//*****************************************************************************************************
public enum DOT11_RADIO_STATE
    {
        dot11_radio_state_unknown,
        dot11_radio_state_on,
        dot11_radio_state_off
    }
//*****************************************************************************************************

//*****************************************************************************************************
public enum WLAN_CONNECTION_MODE
    {
        wlan_connection_mode_profile = 0,
        wlan_connection_mode_temporary_profile,
        wlan_connection_mode_discovery_secure,
        wlan_connection_mode_discovery_unsecure,
        wlan_connection_mode_auto,
        wlan_connection_mode_invalid
    }
//*****************************************************************************************************

//*****************************************************************************************************
public enum WLAN_HOSTED_NETWORK_NOTIFICATION_CODE
    {
        /// <summary>
        /// The Hosted Network state has changed.
        /// </summary>
        wlan_hosted_network_state_change = 0x00001000,
        /// <summary>
        /// The Hosted Network peer state has changed.
        /// </summary>
        wlan_hosted_network_peer_state_change,
        /// <summary>
        /// The Hosted Network radio state has changed.
        /// </summary>
        wlan_hosted_network_radio_state_change
    }
//*****************************************************************************************************

//*****************************************************************************************************
public enum WLAN_HOSTED_NETWORK_OPCODE
    {
        wlan_hosted_network_opcode_connection_settings,
        wlan_hosted_network_opcode_security_settings,
        wlan_hosted_network_opcode_station_profile,
        wlan_hosted_network_opcode_enable
    }
//*****************************************************************************************************

//*****************************************************************************************************
public enum WLAN_HOSTED_NETWORK_PEER_AUTH_STATE
    {
        wlan_hosted_network_peer_state_invalid,
        wlan_hosted_network_peer_state_authenticated
    }
//*****************************************************************************************************

//*****************************************************************************************************
public enum WLAN_HOSTED_NETWORK_REASON
    {
        wlan_hosted_network_reason_success = 0,
        wlan_hosted_network_reason_unspecified,
        wlan_hosted_network_reason_bad_parameters,
        wlan_hosted_network_reason_service_shutting_down,
        wlan_hosted_network_reason_insufficient_resources,
        wlan_hosted_network_reason_elevation_required,
        wlan_hosted_network_reason_read_only,
        wlan_hosted_network_reason_persistence_failed,
        wlan_hosted_network_reason_crypt_error,
        wlan_hosted_network_reason_impersonation,
        wlan_hosted_network_reason_stop_before_start,
        wlan_hosted_network_reason_interface_available,
        wlan_hosted_network_reason_interface_unavailable,
        wlan_hosted_network_reason_miniport_stopped,
        wlan_hosted_network_reason_miniport_started,
        wlan_hosted_network_reason_incompatible_connection_started,
        wlan_hosted_network_reason_incompatible_connection_stopped,
        wlan_hosted_network_reason_user_action,
        wlan_hosted_network_reason_client_abort,
        wlan_hosted_network_reason_ap_start_failed,
        wlan_hosted_network_reason_peer_arrived,
        wlan_hosted_network_reason_peer_departed,
        wlan_hosted_network_reason_peer_timeout,
        wlan_hosted_network_reason_gp_denied,
        wlan_hosted_network_reason_service_unavailable,
        wlan_hosted_network_reason_device_change,
        wlan_hosted_network_reason_properties_change,
        wlan_hosted_network_reason_virtual_station_blocking_use,
        wlan_hosted_network_reason_service_available_on_virtual_station 
    }
//*****************************************************************************************************

//*****************************************************************************************************
public enum WLAN_HOSTED_NETWORK_STATE
    {
        wlan_hosted_network_unavailable,
        wlan_hosted_network_idle,
        wlan_hosted_network_active
    }
//*****************************************************************************************************

//*****************************************************************************************************
public enum WLAN_INTERFACE_STATE
    {
        /// <summary>
        /// wlan_interface_state_not_ready -> 0
        /// </summary>
        wlan_interface_state_not_ready = 0,

        /// <summary>
        /// wlan_interface_state_connected -> 1
        /// </summary>
        wlan_interface_state_connected = 1,

        /// <summary>
        /// wlan_interface_state_ad_hoc_network_formed -> 2
        /// </summary>
        wlan_interface_state_ad_hoc_network_formed = 2,

        /// <summary>
        /// wlan_interface_state_disconnecting -> 3
        /// </summary>
        wlan_interface_state_disconnecting = 3,

        /// <summary>
        /// wlan_interface_state_disconnected -> 4
        /// </summary>
        wlan_interface_state_disconnected = 4,

        /// <summary>
        /// wlan_interface_state_associating -> 5
        /// </summary>
        wlan_interface_state_associating = 5,

        /// <summary>
        /// wlan_interface_state_discovering -> 6
        /// </summary>
        wlan_interface_state_discovering = 6,

        /// <summary>
        /// wlan_interface_state_authenticating -> 7
        /// </summary>
        wlan_interface_state_authenticating = 7,
    }
//*****************************************************************************************************

//*****************************************************************************************************
public enum WLAN_INTF_OPCODE
    {

        /// wlan_intf_opcode_autoconf_start -> 0x000000000
        wlan_intf_opcode_autoconf_start = 0,

        wlan_intf_opcode_autoconf_enabled,

        wlan_intf_opcode_background_scan_enabled,

        wlan_intf_opcode_media_streaming_mode,

        wlan_intf_opcode_radio_state,

        wlan_intf_opcode_bss_type,

        wlan_intf_opcode_interface_state,

        wlan_intf_opcode_current_connection,

        wlan_intf_opcode_channel_number,

        wlan_intf_opcode_supported_infrastructure_auth_cipher_pairs,

        wlan_intf_opcode_supported_adhoc_auth_cipher_pairs,

        wlan_intf_opcode_supported_country_or_region_string_list,

        wlan_intf_opcode_current_operation_mode,

        wlan_intf_opcode_supported_safe_mode,

        wlan_intf_opcode_certified_safe_mode,

        /// wlan_intf_opcode_autoconf_end -> 0x0fffffff
        wlan_intf_opcode_autoconf_end = 268435455,

        /// wlan_intf_opcode_msm_start -> 0x10000100
        wlan_intf_opcode_msm_start = 268435712,

        wlan_intf_opcode_statistics,

        wlan_intf_opcode_rssi,

        /// wlan_intf_opcode_msm_end -> 0x1fffffff
        wlan_intf_opcode_msm_end = 536870911,

        /// wlan_intf_opcode_security_start -> 0x20010000
        wlan_intf_opcode_security_start = 536936448,

        /// wlan_intf_opcode_security_end -> 0x2fffffff
        wlan_intf_opcode_security_end = 805306367,

        /// wlan_intf_opcode_ihv_start -> 0x30000000
        wlan_intf_opcode_ihv_start = 805306368,

        /// wlan_intf_opcode_ihv_end -> 0x3fffffff
        wlan_intf_opcode_ihv_end = 1073741823,
    }
//*****************************************************************************************************

//*****************************************************************************************************
 public enum WLAN_NOTIFICATION_CODE_ACM
 {
 AutoconfEnabled = 1,
 AutoconfDisabled,
 BackgroundScanEnabled,
 BackgroundScanDisabled,
 BssTypeChange,
 PowerSettingChange,
 ScanComplete,
 ScanFail,
 ConnectionStart,
 ConnectionComplete,
 ConnectionAttemptFail,
 FilterListChange,
 InterfaceArrival,
 InterfaceRemoval,
 ProfileChange,
 ProfileNameChange,
 ProfilesExhausted,
 NetworkNotAvailable,
 NetworkAvailable,
 Disconnecting,
 Disconnected,
 AdhocNetworkStateChange
 } 
//*****************************************************************************************************

//*****************************************************************************************************
public enum WLAN_NOTIFICATION_CODE_MSM
 {
 Associating = 1,
 Associated,
 Authenticating,
 Connected,
 RoamingStart,
 RoamingEnd,
 RadioStateChange,
 SignalQualityChange,
 Disassociating,
 Disconnected,
 PeerJoin,
 PeerLeave,
 AdapterRemoval,
 AdapterOperationModeChange
 } 
//*****************************************************************************************************

//*****************************************************************************************************
/// <summary>
    /// Specifies where the notification comes from.
    /// </summary>
    [Flags]
    public enum WLAN_NOTIFICATION_SOURCE : uint
    {
        None = 0,
        /// <summary>
        /// All notifications, including those generated by the 802.1X module.
        /// </summary>
        All = 0X0000FFFF,
        /// <summary>
        /// Notifications generated by the auto configuration module.
        /// </summary>
        ACM = 0X00000008,
        /// <summary>
        /// Notifications generated by MSM.
        /// </summary>
        MSM = 0X00000010,
        /// <summary>
        /// Notifications generated by the security module.
        /// </summary>
        Security = 0X00000020,
        /// <summary>
        /// Notifications generated by independent hardware vendors (IHV).
        /// </summary>
        IHV = 0X00000040
    } 
//*****************************************************************************************************

//*****************************************************************************************************
 public enum WLAN_OPCODE_VALUE_TYPE
    {
        wlan_opcode_value_type_query_only = 0,
        wlan_opcode_value_type_set_by_group_policy,
        wlan_opcode_value_type_set_by_user,
        wlan_opcode_value_type_invalid
    }
//*****************************************************************************************************
}
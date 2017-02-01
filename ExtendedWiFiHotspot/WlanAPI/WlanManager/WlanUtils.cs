﻿// Modified work of VirtualRouter Plus 
//http://virtualwifihotspot.codeplex.com/releases/view/101496
//http://virtualwifihotspot.codeplex.com/license
//************************************************************ 
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace ExtendedWiFi
{
    public static class WlanUtils
    {
        [DebuggerStepThrough]
        public static void Throw_On_Win32_Error(uint retCode)
        {
            if (retCode != 0) // 0 = ERROR_SUCCESS
            {
                throw new Win32Exception((int)retCode);
            }
        }

        public static string ConvertToString(this DOT11_MAC_ADDRESS mac)
        {
            var sb = new StringBuilder();

            sb.Append(mac.one.ConvertToHexString());
            sb.Append(":");
            sb.Append(mac.two.ConvertToHexString());
            sb.Append(":");
            sb.Append(mac.three.ConvertToHexString());
            sb.Append(":");
            sb.Append(mac.four.ConvertToHexString());
            sb.Append(":");
            sb.Append(mac.five.ConvertToHexString());
            sb.Append(":");
            sb.Append(mac.six.ConvertToHexString());

            return sb.ToString();
        }

        public static string ConvertToString(this DOT11_SSID ssid)
        {
            return ssid.ucSSID;
        }

        public static string ConvertToHexString(this byte value)
        {
            return Convert.ToString(value, 0x10).PadLeft(2, '0');
        }

        public static DOT11_SSID ConvertStringToDOT11_SSID(string ssid)
        {
            return new DOT11_SSID()
            {
                 ucSSID = ssid,
                uSSIDLength = ssid.Length
            };
        }
    }
}

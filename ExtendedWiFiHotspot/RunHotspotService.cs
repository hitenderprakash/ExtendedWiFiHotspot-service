using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExtendedWiFiHotspot
{

    public partial class RunHotspotService : ServiceBase
    {
        ExtendedWiFi.WlanManager wlanManager = new ExtendedWiFi.WlanManager();
        ExtendedWiFi.IcsManager icsManager = new ExtendedWiFi.IcsManager();
        Thread mThread;
        List<ExtendedWiFi.IcsConnection> Connlist = new List<ExtendedWiFi.IcsConnection>();
        List<System.Net.NetworkInformation.NetworkInterface> InetFacelist = new List<System.Net.NetworkInformation.NetworkInterface>();
        bool status;
        string ssid = System.Environment.MachineName.ToString() + "Hotspot";
        string key = "pass1234";
        //Also be taken from Config file or Registry entry
        //For the demo purpose, we have hard-coded the password.

        //*********************************************************************************************************************
        public RunHotspotService()
        {
            InitializeComponent();
            //this.ServiceName = "RunHotspotService";
            //this.EventLog.Log = "*********RunHotspotService*********";
            //this.CanPauseAndContinue = true;
            //this.CanShutdown = true;
            //this.CanStop = true;
        }

        static void parallelFunc(RunHotspotService that)
        {
            that.execute(false);
        }

        protected override void OnStart(string[] args)
        {
            mThread = new Thread(() => parallelFunc(this));         // Kick off a new thread
            mThread.Start();   
            //this.EventLog.Log = " Starting Service";
        }

        protected override void OnStop()
        {
            try
            {
                mThread.Abort();
                this.StopHotspot();
                this.status = false;
                //this.EventLog.Log = " Stopping Service";
            }
            catch
            {
            }
            System.Threading.Thread.Sleep(5000);
        }
        //********************************************************************************************************************* 
        
        public  void getICSConnections()
        {
            this.InetFacelist.Clear();
            System.Net.NetworkInformation.NetworkInterface[] NetIFaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            foreach (var NetIFace in NetIFaces)
            {
                //
                if (NetIFace.OperationalStatus.ToString() == "Up")
                {
                    this.InetFacelist.Add(NetIFace);
                }
            }
            this.Connlist.Clear();
            foreach (var connection in this.icsManager.Connections)
            {
                if (connection.IsConnected && connection.IsSupported)
                {
                    foreach (var iface in InetFacelist)
                    {
                        if (connection.Name.ToString() == iface.Name.ToString())
                        {
                            this.Connlist.Add(connection);
                        }
                    }
                }
            }
        }

        public void execute(bool Flag)
        {            
            this.status = Flag;
            while (true) 
            {
                if (this.HasConnection() && (this.status == false))
                {
                    this.getICSConnections();
                    bool k = this.Start(this.ssid, this.key, 32);
                    System.Threading.Thread.Sleep(3000);
                }
                else if ((this.HasConnection() == false) && (this.status == true))
                {
                    this.StopHotspot();
                    System.Threading.Thread.Sleep(3000);
                    this.status = false;
                }
            }
        }
      
        public bool Start(string ssid, string password, int maxClients)
        {
            try
            {
                this.StopHotspot();
                //System.Console.Write("\nStarting Hotspot.....");
                this.wlanManager.SetConnectionSettings(ssid, 32);
                this.wlanManager.SetSecondaryKey(password);
                this.wlanManager.StartHostedNetwork();
                var privateConnectionGuid = this.wlanManager.HostedNetworkInterfaceGuid;
                this.icsManager.EnableIcs(this.Connlist[0].Guid, privateConnectionGuid);
                this.status = true;
                System.Threading.Thread.Sleep(3000);
                return true;           
            }
            catch
            {
                this.status = false;
                return false;
            }
        }

        public bool StopHotspot()
        {
            try
            {
                if (this.icsManager.SharingInstalled)
                {
                    this.icsManager.DisableIcsOnAll();
                }
                this.wlanManager.StopHostedNetwork();
                System.Threading.Thread.Sleep(3000);
                this.status = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public  bool HasConnection()
        {
            try
            {
                System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}

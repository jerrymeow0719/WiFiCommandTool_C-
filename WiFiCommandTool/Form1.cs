using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WiFiCommandTool
{
    public partial class Form1 : Form
    {
        Socket SckSPort;    //宣告Socket
        string RmIP = "192.168.1.254";  //Server端IP
        int SPort = 3333;

        public Form1()
        {
            InitializeComponent();
            UpdateUI((int)ProcessStatus.Status_None);
        }

        private void Connect_button1_Click(object sender, EventArgs e)
        {
            globalVar.ConnectSSID = CheckConnect();
            UpdateUI((int)ProcessStatus.Status_Connect);
        }

        private void URL_button1_Click(object sender, EventArgs e)
        {
            string Cmd = URL_textBox1.Text.ToString();
            string Cmd_Serialnumber = "";
            string Cmd_Parameter = "";
            if (Cmd.Contains("192.168.1.254"))
            {
                if (Cmd.Contains("custom=1"))
                {
                    if (Cmd.Contains("&"))
                    {
                        Cmd = Cmd.Substring(Cmd.IndexOf("&") + 1);
                        //Command Type
                        if (Cmd.Contains("cmd="))
                        {
                            Cmd_Serialnumber = Cmd.Substring(Cmd.IndexOf("=") + 1, 4);
                            if (Cmd.Contains("&"))
                            {
                                Cmd = Cmd.Substring(Cmd.IndexOf("&") + 1);
                                Cmd_Parameter = Cmd.Substring(Cmd.IndexOf("=") + 1);
                            }
                        }
                    }
                    globalVar.CommandList.Add(URL_textBox1.Text.ToString());
                }
                else if (Cmd.Contains(":8192"))
                {
                    globalVar.CommandList.Add(URL_textBox1.Text.ToString());
                    Cmd_Serialnumber = "Liveview";
                    //Liveview Type
                }
                else
                {
                    //FileSystem Type
                }
            }
            else
            { MessageBox.Show("Illegal URL!!"); }

            if (Cmd_Parameter != "")
                Info_listView1.Items.Add(Cmd_Serialnumber + " , " + Cmd_Parameter);
            else
                Info_listView1.Items.Add(Cmd_Serialnumber);
            Info_listView1.Refresh();
        }

        private void URL_button2_Click(object sender, EventArgs e)
        {
            if (URL_textBox2.Text.ToString() != "")
            {
                globalVar.CommandList.Add("Delay," + URL_textBox2.Text.ToString());
                Info_listView1.Items.Add("Delay" + " , " + URL_textBox2.Text.ToString());
            }
        }

        private void Info_listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Info_listView1.Focused)
            {
                int SelectIndex = Info_listView1.FocusedItem.Index;
                globalVar.CommandList.RemoveAt(SelectIndex);
                Info_listView1.Items.RemoveAt(SelectIndex);
                Info_listView1.Refresh();
            }
        }

        private void Socket_button1_Click(object sender, EventArgs e)
        {
            globalVar.CommandList.Add("Socket");
            Info_listView1.Items.Add("Socket");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            globalVar.CommandList.Clear();
            globalVar.IsConnect = false;
            globalVar.IsSocket = false;
            wifi WiFiAPI = new wifi();
            WiFiAPI.ExecuteCommand("netsh wlan disconnect");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateUI((int)ProcessStatus.Status_Start);
            wifi WifiAPI = new wifi();
            string sURL = "";
            if (globalVar.IsConnect)
            {
                if (URL_textBox1.Text.ToString() != "" && globalVar.CommandList.Count == 0)
                {
                    sURL = URL_textBox1.Text.ToString();
                    WifiAPI.ExecuteHTTPCommand(sURL);
                }
                else
                {
                    int index = 0;
                    for (index = 0; index < globalVar.CommandList.Count; index++)
                    {
                        Info_listView1.Items[index].Selected = true;
                        Info_listView1.Select();
                        if (Info_listView1.Items[index].Text.ToString().Contains("Socket"))
                        {
                            ExecuteSocketConnect();
                        }
                        else if (Info_listView1.Items[index].Text.ToString().Contains("Delay"))
                        {
                            int sleepMS = Convert.ToInt32(Info_listView1.Items[index].Text.ToString().Substring(Info_listView1.Items[index].Text.ToString().IndexOf(",") + 2));
                            System.Threading.Thread.Sleep(sleepMS);
                        }
                        else
                        {
                            sURL = globalVar.CommandList[index].ToString();
                            WifiAPI.ExecuteHTTPCommand(sURL);
                        }
                    }
                }
                UpdateUI((int)ProcessStatus.Status_Finish);
            }
        }

        private void ExecuteSocketConnect()
        {
            if (globalVar.IsConnect)
            {
                try
                {
                    SckSPort = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    SckSPort.Connect(new IPEndPoint(IPAddress.Parse(RmIP), SPort)); //RmIp和SPort分別為string和int型態, 前者為Server端的IP, 後者為Server端的Port
                    globalVar.IsSocket = SckSPort.Connected;
                    Socket_ovalShape1.FillColor = (globalVar.IsSocket) ? Color.LawnGreen : Color.DimGray;
                    if (!globalVar.IsSocket)
                        MessageBox.Show("Connect to Socket fail!!");

                    //Thread SckReceivedTd = new Thread(SckSReceiveProc);
                    //SckReceivedTd.Start();
                }
                catch { }
            }
            else
                MessageBox.Show("Please connet to WiFi first!!");
        }

        private void SckSReceiveProc()
        {
            try
            {
                long IntAcceptData;
                byte[] Data = new byte[32];
                IntAcceptData = SckSPort.Receive(Data);
                string S = Encoding.Default.GetString(Data);
                Console.WriteLine(S);
            }
            catch { }
        }

        private string CheckConnect()
        {
            wifi wifiAPI = new wifi();
            globalVar.IsConnect = wifiAPI.EnumerateNICs();
            string nSSID = "";
            nSSID = wifiAPI.GetConnectSSID();
            return nSSID;
        }

        private void UpdateUI(int status)
        {
            switch (status)
            {
                case (int)ProcessStatus.Status_None:
                    groupBox_Connect.Enabled = true;
                    Connect_button1.Enabled = true;
                    Connet_label1.Text = "SSID";
                    Connect_ovalShape1.FillColor = Color.DimGray;
                    groupBox_Socket.Enabled = true;
                    Socket_button1.Enabled = true;
                    Socket_ovalShape1.FillColor = Color.DimGray;
                    groupBox_URL.Enabled = true;
                    URL_button1.Enabled = true;
                    URL_button2.Enabled = true;
                    URL_textBox1.ReadOnly = false;
                    URL_textBox2.ReadOnly = false;
                    URL_textBox1.Clear();
                    URL_textBox2.Clear();
                    groupBox_Info.Enabled = true;
                    Info_listView1.Enabled = true;
                    Info_listView1.Clear();
                    button1.Enabled = true;
                    button2.Enabled = true;
                    break;
                case (int)ProcessStatus.Status_Connect:
                    groupBox_Connect.Enabled = true;
                    Connect_button1.Enabled = true;
                    Connet_label1.Text = (globalVar.IsConnect) ? globalVar.ConnectSSID : "SSID";
                    Connect_ovalShape1.FillColor = (globalVar.IsConnect) ? Color.LawnGreen : Color.DimGray;
                    groupBox_Socket.Enabled = true;
                    Socket_button1.Enabled = true;
                    Socket_ovalShape1.FillColor = (globalVar.IsSocket) ? Color.LawnGreen : Color.DimGray;
                    groupBox_URL.Enabled = true;
                    URL_textBox1.ReadOnly = false;
                    URL_textBox2.ReadOnly = false;
                    URL_button1.Enabled = true;
                    URL_button2.Enabled = true;
                    //URL_textBox1.Clear();
                    //URL_textBox2.Clear();
                    groupBox_Info.Enabled = true;
                    Info_listView1.Enabled = true;
                    //Info_listView1.Clear();
                    button1.Enabled = true;
                    button2.Enabled = true;
                    break;
                case (int)ProcessStatus.Status_Start:
                    groupBox_Connect.Enabled = true;
                    Connect_button1.Enabled = false;
                    Connet_label1.Text = (globalVar.IsConnect) ? globalVar.ConnectSSID : "SSID";
                    Connect_ovalShape1.FillColor = (globalVar.IsConnect) ? Color.LawnGreen : Color.DimGray;
                    groupBox_Socket.Enabled = true;
                    Socket_button1.Enabled = false;
                    Socket_ovalShape1.FillColor = (globalVar.IsSocket) ? Color.LawnGreen : Color.DimGray;
                    groupBox_URL.Enabled = false;
                    URL_button1.Enabled = false;
                    URL_button2.Enabled = false;
                    URL_textBox1.ReadOnly = true;
                    URL_textBox2.ReadOnly = true;
                    //URL_textBox1.Clear();
                    //URL_textBox2.Clear();
                    groupBox_Info.Enabled = false;
                    Info_listView1.Enabled = false;
                    //Info_listView1.Clear();
                    button1.Enabled = false;
                    button2.Enabled = false;
                    break;
                case (int)ProcessStatus.Status_Finish:
                    groupBox_Connect.Enabled = true;
                    Connect_button1.Enabled = true;
                    Connet_label1.Text = (globalVar.IsConnect) ? globalVar.ConnectSSID : "SSID";
                    Connect_ovalShape1.FillColor = (globalVar.IsConnect) ? Color.LawnGreen : Color.DimGray;
                    groupBox_Socket.Enabled = true;
                    Socket_button1.Enabled = true;
                    Socket_ovalShape1.FillColor = (globalVar.IsSocket) ? Color.LawnGreen : Color.DimGray;
                    groupBox_URL.Enabled = true;
                    URL_button1.Enabled = true;
                    URL_button2.Enabled = true;
                    URL_textBox1.ReadOnly = false;
                    URL_textBox2.ReadOnly = false;
                    //URL_textBox1.Clear();
                    //URL_textBox2.Clear();
                    groupBox_Info.Enabled = true;
                    Info_listView1.Enabled = true;
                    //Info_listView1.Clear();
                    button1.Enabled = true;
                    button2.Enabled = true;
                    break;
            }
        }
    }

    public static class globalVar
    {
        public static string ConnectSSID = "";
        public static bool IsConnect = false;
        public static bool IsSocket = false;
        public static List<string> CommandList = new List<string>();
    }

    enum ProcessStatus { Status_None, Status_Connect, Status_Start, Status_Finish };

    class wifi
    {
        private const int WLAN_API_VERSION_2_0 = 2; //Windows Vista WiFi API Version
        private const int WLAN_API_XP_VERSION = 1;
        private const int ERROR_SUCCESS = 0;

        /// <summary>
        /// Opens a connection to the server
        /// </summary>
        [DllImport("wlanapi.dll", SetLastError = true)]
        private static extern UInt32 WlanOpenHandle(UInt32 dwClientVersion, IntPtr pReserved, out UInt32 pdwNegotiatedVersion, ref IntPtr phClientHandle);

        /// <summary>
        /// Closes a connection to the server
        /// </summary>
        [DllImport("wlanapi.dll", SetLastError = true)]
        private static extern UInt32 WlanCloseHandle(IntPtr hClientHandle, IntPtr pReserved);

        /// <summary>
        /// Enumerates all wireless interfaces in the laptop
        /// </summary>
        [DllImport("wlanapi.dll", SetLastError = true)]
        private static extern UInt32 WlanEnumInterfaces(IntPtr hClientHandle, IntPtr pReserved, ref IntPtr ppInterfaceList);

        /// <summary>
        /// Frees memory returned by native WiFi functions
        /// </summary>
        [DllImport("wlanapi.dll", SetLastError = true)]
        private static extern void WlanFreeMemory(IntPtr pmemory);

        // Scan all variable Wi-Fi network
        [DllImport("wlanapi.dll", SetLastError = true)]
        private static extern int WlanScan(IntPtr hClientHandle, IntPtr pInterfaceGuid, IntPtr pDot11Ssid, IntPtr pIeData, IntPtr pReserved);

        /// <summary>
        /// Interface state enums
        /// </summary>
        public enum WLAN_INTERFACE_STATE : int
        {
            wlan_interface_state_not_ready = 0,
            wlan_interface_state_connected,
            wlan_interface_state_ad_hoc_network_formed,
            wlan_interface_state_disconnecting,
            wlan_interface_state_disconnected,
            wlan_interface_state_associating,
            wlan_interface_state_discovering,
            wlan_interface_state_authenticating
        };

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
        /// <summary>
        /// This structure contains an array of NIC information
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WLAN_INTERFACE_INFO_LIST
        {
            public Int32 dwNumberofItems;
            public Int32 dwIndex;
            public WLAN_INTERFACE_INFO[] InterfaceInfo;

            public WLAN_INTERFACE_INFO_LIST(IntPtr pList)
            {
                // The first 4 bytes are the number of WLAN_INTERFACE_INFO structures.
                dwNumberofItems = Marshal.ReadInt32(pList, 0);

                // The next 4 bytes are the index of the current item in the unmanaged API.
                dwIndex = Marshal.ReadInt32(pList, 4);

                // Construct the array of WLAN_INTERFACE_INFO structures.
                InterfaceInfo = new WLAN_INTERFACE_INFO[dwNumberofItems];

                for (int i = 0; i < dwNumberofItems; i++)
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
        /// <summary>
        ///get NIC state  
        /// </summary>
        private string getStateDescription(WLAN_INTERFACE_STATE state)
        {
            string stateDescription = string.Empty;
            switch (state)
            {
                case WLAN_INTERFACE_STATE.wlan_interface_state_connected:
                    stateDescription = "connected";
                    break;
                case WLAN_INTERFACE_STATE.wlan_interface_state_not_ready:
                case WLAN_INTERFACE_STATE.wlan_interface_state_ad_hoc_network_formed:
                case WLAN_INTERFACE_STATE.wlan_interface_state_disconnecting:
                case WLAN_INTERFACE_STATE.wlan_interface_state_disconnected:
                case WLAN_INTERFACE_STATE.wlan_interface_state_associating:
                case WLAN_INTERFACE_STATE.wlan_interface_state_discovering:
                case WLAN_INTERFACE_STATE.wlan_interface_state_authenticating:
                    stateDescription = "connect fail";
                    break;
            }

            return stateDescription;
        }

        //啟動 windows service
        private void StartService(string s)
        {
            try
            {
                ServiceController sc = new ServiceController(s);        //if service is stopped, start it        

                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    //start the service      
                    TimeSpan timeout = TimeSpan.FromMilliseconds(1000 * 15);
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : ", e.Message);
            }
        }

        /// <summary>
        /// enumerate wireless network adapters using wifi api
        /// </summary>
        public bool EnumerateNICs()
        {
            uint version = 2;
            uint serviceVersion = 0;
            IntPtr handle = IntPtr.Zero;
            bool connectPass = false;
            IntPtr ppInterfaceList = IntPtr.Zero;
            WLAN_INTERFACE_INFO_LIST interfaceList;
            //Open WLAN handler
            try
            {
                if (WlanOpenHandle(version, IntPtr.Zero, out serviceVersion, ref handle) == ERROR_SUCCESS)
                {
                    //Enumerates all of the wireless LAN interfaces currently enabled
                    if (WlanEnumInterfaces(handle, IntPtr.Zero, ref ppInterfaceList) == ERROR_SUCCESS)
                    {
                        //Tranfer all values from IntPtr to WLAN_INTERFACE_INFO_LIST structure 
                        interfaceList = new WLAN_INTERFACE_INFO_LIST(ppInterfaceList);
                        //檢查是否連線成功
                        if (getStateDescription(interfaceList.InterfaceInfo[0].isState) == "connected")
                            connectPass = true;
                        if (ppInterfaceList != IntPtr.Zero)
                            WlanFreeMemory(ppInterfaceList);
                    }
                    WlanCloseHandle(handle, IntPtr.Zero);
                }
            }
            catch { MessageBox.Show("WiFi status error!!"); }
            return connectPass;
        }

        public string GetConnectSSID()
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "netsh.exe",
                    Arguments = "wlan show interfaces",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            var line = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                             .FirstOrDefault(l => l.Contains("SSID") && !l.Contains("BSSID"));
            if (line == null)
            {
                return string.Empty;
            }
            var ssid = line.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].TrimStart();
            return ssid;
        }

        public int ExecuteCommand(string Command)
        {
            int ExitCode;
            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/c " + Command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;

            Process = Process.Start(ProcessInfo);
            Process.WaitForExit();
            ExitCode = Process.ExitCode;
            Process.Close();

            return ExitCode;
        }

        public bool ExecuteHTTPCommand(string sURL)
        {
            HttpWebRequest httpRequest = null;
            HttpWebResponse httpResponse = null;
            try
            {
                httpRequest = (HttpWebRequest)WebRequest.Create(sURL);
                httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            }
            catch (Exception e)
            {
                if (httpResponse != null)
                    httpResponse.Close();
                Console.WriteLine(e.ToString());
                return false;
            }
            if (httpResponse != null)
                httpResponse.Close();
            return true;
        }
    }
}

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
using System.Data.OleDb;
using System.Data.SqlClient;

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

        private void button1_Click(object sender, EventArgs e)
        {
            globalVar.CommandList.Clear();
            wifi WiFiAPI = new wifi();
            WiFiAPI.ExecuteCommand("netsh wlan disconnect");
            UpdateUI((int)ProcessStatus.Status_None);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateUI((int)ProcessStatus.Status_Start);
            double[] TimeEstimation = new double[globalVar.CommandList.Count];
            wifi WifiAPI = new wifi();
            string sURL = "";
            Stopwatch sw = new Stopwatch();
            int index = 0;
            for (index = 0; index < globalVar.CommandList.Count; index++)
            {
                sw.Reset();
                sw.Start();
                Info_listView1.Items[index].Selected = true;
                Info_listView1.Select();
                if (Info_listView1.Items[index].Text.ToString().Contains("Connect"))
                {
                    string URLConnet = Info_listView1.Items[index].Text.ToString();
                    string SSID = "";
                    URLConnet = URLConnet.Substring(URLConnet.IndexOf(",") + 1);
                    SSID = URLConnet.Substring(0, URLConnet.IndexOf(","));
                    URLConnet = URLConnet.Substring(URLConnet.IndexOf(",") + 1);
                    if (URLConnet == "0")
                        ExecuteConnect(SSID, false);
                    else
                        ExecuteConnect(SSID, true);
                }
                if (Info_listView1.Items[index].Text.ToString().Contains("Socket"))
                {
                    if (Info_listView1.Items[index].Text.ToString().Contains("0"))
                        ExecuteSocketConnect(false);
                    else
                        ExecuteSocketConnect(true);
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
                sw.Stop();
                TimeEstimation[index] = sw.Elapsed.TotalMilliseconds;
            }

            UpdateUI((int)ProcessStatus.Status_Finish);
            foreach (int element in TimeEstimation)
            {
                Console.WriteLine(element.ToString());
            }
            MessageBox.Show("Command Finish");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select script file";
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "xls file (*.*)|*.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                globalVar.ScriptPath = dialog.FileName;
            }
            else
                return;

            string ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + globalVar.ScriptPath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;Mode=Read'";
            OleDbConnection ODConn;
            ODConn = new OleDbConnection(ConnStr);
            try
            { 
                ODConn.Open();
            }
            catch { }
            globalVar.CommandList.Clear();
            Info_listView1.Clear();
            string strSql = "SELECT * FROM[Script$]";
            int ScriptCommandCount = 0;
            string ScriptCommandURL = "";
            OleDbCommand ODCmd = ODConn.CreateCommand();
            ODCmd.CommandText = strSql;
            DataSet myDataSet = new DataSet();
            OleDbDataAdapter MyAdapter = new OleDbDataAdapter(strSql, ODConn);
            MyAdapter.Fill(myDataSet, "Script");
            DataTable dt = myDataSet.Tables["Script"];
            foreach (DataRow dr in dt.Rows)
            {
                ScriptCommandURL = "";
                if (dr["Case"].ToString() == "")
                    return;
                if (Convert.ToInt32(dr["Case"].ToString()) == ScriptCommandCount + 1)
                {
                    switch (dr["Type"].ToString())
                    {
                        case "Command":
                            ScriptCommandCount++;
                            ScriptCommandURL = String.Concat("http://192.168.1.254/?custom=1&cmd=", dr["ID"].ToString());
                            if (dr["Parameter"].ToString() != "" && dr["Parameter"].ToString() != "NULL")
                            {
                                if(dr["Parameter Type"].ToString() == "par")
                                    ScriptCommandURL = String.Concat(ScriptCommandURL, "&par=", dr["Parameter"].ToString());
                                else if(dr["Parameter Type"].ToString() == "str")
                                    ScriptCommandURL = String.Concat(ScriptCommandURL, "&str=", dr["Parameter"].ToString());
                                Info_listView1.Items.Add(dr["ID"].ToString() + " , " + dr["Parameter"].ToString());
                            }
                            else
                                Info_listView1.Items.Add(dr["ID"].ToString());
                            break;
                        case "Liveview":
                            ScriptCommandCount++;
                            if(dr["Parameter"].ToString() != "" && dr["Parameter"].ToString() != "NULL")
                                ScriptCommandURL = String.Concat("http://192.168.1.254:", dr["Parameter"].ToString());
                            else
                                ScriptCommandURL = String.Concat("http://192.168.1.254:", "8192");
                            Info_listView1.Items.Add("Liveview");
                            break;
                        case "FileSystem":
                            ScriptCommandCount++;
                            if (dr["ID"].ToString() != "")
                            {
                                ScriptCommandURL = String.Concat("http://192.168.1.254/", dr["ID"].ToString());
                                if(dr["Parameter"].ToString() == "0")
                                    ScriptCommandURL = String.Concat(ScriptCommandURL, "?del=1");
                            }
                            Info_listView1.Items.Add("FileSystem");
                            break;
                        case "Connect":
                            ScriptCommandCount++;
                            ScriptCommandURL = "Connect," + dr["ID"].ToString() + "," + dr["Parameter"].ToString();
                            Info_listView1.Items.Add("Connect" + " , " + dr["ID"].ToString() + " , " + dr["Parameter"].ToString());
                            break;
                        case "Socket":
                            ScriptCommandCount++;
                            ScriptCommandURL = "Socket," + dr["Parameter"].ToString();
                            Info_listView1.Items.Add("Socket" + " , " + dr["Parameter"].ToString());
                            break;
                        case "Delay":
                            ScriptCommandCount++;
                            ScriptCommandURL = "Delay," + dr["Parameter"].ToString();
                            Info_listView1.Items.Add("Delay" + " , " + dr["Parameter"].ToString());
                            break;
                        case "Thumb":
                            ScriptCommandCount++;
                            if (dr["ID"].ToString() != "")
                            {
                                ScriptCommandURL = String.Concat("http://192.168.1.254/", dr["ID"].ToString(),"?custom=1&cmd=6003");
                                Info_listView1.Items.Add("Thumb" + " , " + dr["ID"].ToString());
                            }
                            break;
                    }
                    globalVar.CommandList.Add(ScriptCommandURL);
                    Info_listView1.Refresh();
                }
            }
        }

        private void tabControl1_tabPage1_button1_Click(object sender, EventArgs e)
        {
            if (tabControl1_tabPage1_textBox1.Text.ToString() != "")
            {
                string URL = "";
                URL = String.Concat("http://192.168.1.254/?custom=1&cmd=", tabControl1_tabPage1_textBox1.Text.ToString());
                if (tabControl1_tabPage1_textBox2.Text.ToString() != "")
                {
                    if (tabControl1_tabPage1_textBox3.Text.ToString() == "par")
                        URL = String.Concat(URL, "&par=", tabControl1_tabPage1_textBox2.Text.ToString());
                    else if (tabControl1_tabPage1_textBox3.Text.ToString() == "str")
                        URL = String.Concat(URL, "&str=", tabControl1_tabPage1_textBox2.Text.ToString());
                    Info_listView1.Items.Add(tabControl1_tabPage1_textBox1.Text.ToString() + " , " + tabControl1_tabPage1_textBox2.Text.ToString());
                }
                else
                    Info_listView1.Items.Add(tabControl1_tabPage1_textBox1.Text.ToString());
                globalVar.CommandList.Add(URL);
            }
        }

        private void tabControl1_tabPage2_button1_Click(object sender, EventArgs e)
        {
            string URL = "";
            if (tabControl1_tabPage2_textBox1.Text.ToString() != "")
            {
                URL = String.Concat("http://192.168.1.254:" + tabControl1_tabPage2_textBox1.Text.ToString());
            }
            else
            {
                URL = "http://192.168.1.254:8192";
            }
            Info_listView1.Items.Add("Liveview");
            globalVar.CommandList.Add(URL);
        }

        private void tabControl1_tabPage3_button1_Click(object sender, EventArgs e)
        {
            if (tabControl1_tabPage3_textBox1.Text.ToString() != "" && tabControl1_tabPage3_textBox2.Text.ToString() != "")
            {
                string URL = "";
                URL = String.Concat("http://192.168.1.254/", tabControl1_tabPage3_textBox1.Text.ToString());
                if (tabControl1_tabPage3_textBox2.Text.ToString() == "0")
                    URL = String.Concat(URL, "?del=1");
                Info_listView1.Items.Add("FileSystem");
                globalVar.CommandList.Add(URL);
            }
        }

        private void tabControl1_tabPage4_button1_Click(object sender, EventArgs e)
        {
            if (tabControl1_tabPage4_textBox1.Text.ToString() != "" && tabControl1_tabPage4_textBox2.Text.ToString() != "")
            {
                string URL = "";
                URL = "Connect," + tabControl1_tabPage4_textBox1.Text.ToString() + "," + tabControl1_tabPage4_textBox2.Text.ToString();
                Info_listView1.Items.Add("Connect" + " , " + tabControl1_tabPage4_textBox1.Text.ToString() + " , " + tabControl1_tabPage4_textBox2.Text.ToString());
                globalVar.CommandList.Add(URL);
            }
        }

        private void tabControl1_tabPage5_button1_Click(object sender, EventArgs e)
        {
            if (tabControl1_tabPage5_textBox1.Text.ToString() != "")
            {
                string URL = "";
                URL = "Socket," + tabControl1_tabPage5_textBox1.Text.ToString();
                Info_listView1.Items.Add("Socket" + " , " + tabControl1_tabPage5_textBox1.Text.ToString());
                globalVar.CommandList.Add(URL);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1_tabPage6_textBox1.Text.ToString() != "")
            {
                string URL = "";
                URL = "Delay," + tabControl1_tabPage6_textBox1.Text.ToString();
                Info_listView1.Items.Add("Delay" + " , " + tabControl1_tabPage6_textBox1.Text.ToString());
                globalVar.CommandList.Add(URL);
            }
        }

        private void ExecuteConnect(string SSID, bool establish)
        {
            wifi wifiAPI = new wifi();
            if (establish)
            {
                wifiAPI.EnumerateNICs(SSID);
            }
            else
            {
                wifiAPI.ExecuteCommand("netsh wlan disconnect");
            }

        }

        private void ExecuteSocketConnect(bool establish)
        {
            if (establish)
            {
                try
                {
                    SckSPort = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    SckSPort.Connect(new IPEndPoint(IPAddress.Parse(RmIP), SPort)); //RmIp和SPort分別為string和int型態, 前者為Server端的IP, 後者為Server端的Port

                    //Thread SckSReceiveTd = new Thread(SckSReceiveProc);
                    //SckSReceiveTd.Start();
                }
                catch { }
            }
            else
            {
                SckSPort.Disconnect(true);
                SckSPort.Dispose();
            }
        }

        private void SckSReceiveProc()
        {
                long IntAcceptData;
                byte[] clientData = new byte[128];

                while (true)
                {
                    // 程式會被 hand 在此, 等待接收來自 Server 端傳來的資料
                    IntAcceptData = SckSPort.Receive(clientData);
                    string S = Encoding.Default.GetString(clientData);
                }
        }

        private void UpdateUI(int status)
        {
            switch (status)
            {
                case (int)ProcessStatus.Status_None:
                    groupBox_Info.Enabled = true;
                    Info_listView1.Enabled = true;
                    Info_listView1.Clear();
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    break;
                case (int)ProcessStatus.Status_Connect:
                    groupBox_Info.Enabled = true;
                    Info_listView1.Enabled = true;
                    //Info_listView1.Clear();
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    break;
                case (int)ProcessStatus.Status_Start:
                    groupBox_Info.Enabled = false;
                    Info_listView1.Enabled = false;
                    //Info_listView1.Clear();
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    break;
                case (int)ProcessStatus.Status_Finish:
                    groupBox_Info.Enabled = true;
                    Info_listView1.Enabled = true;
                    //Info_listView1.Clear();
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    break;
            }
        }
    }

    public static class globalVar
    {
        public static List<string> CommandList = new List<string>();
        public static string ScriptPath = "";
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
        public bool EnumerateNICs(string SSID)
        {
            uint version = 2;
            uint serviceVersion = 0;
            IntPtr handle = IntPtr.Zero;
            bool connectPass = false;
            int connetCount = 0;
            //Open WLAN handler
            try
            {
                if (WlanOpenHandle(version, IntPtr.Zero, out serviceVersion, ref handle) == ERROR_SUCCESS)
                {
                    while (connetCount < 3 && connectPass == false)
                    {
                        IntPtr ppInterfaceList = IntPtr.Zero;
                        WLAN_INTERFACE_INFO_LIST interfaceList;
                        ExecuteCommand("netsh wlan connect name=" + SSID + " ssid=" + SSID);
                        System.Threading.Thread.Sleep(500);
                        //Enumerates all of the wireless LAN interfaces currently enabled
                        if (WlanEnumInterfaces(handle, IntPtr.Zero, ref ppInterfaceList) == ERROR_SUCCESS)
                        {
                            //Tranfer all values from IntPtr to WLAN_INTERFACE_INFO_LIST structure 
                            interfaceList = new WLAN_INTERFACE_INFO_LIST(ppInterfaceList);
                            //檢查是否連線成功
                            if (getStateDescription(interfaceList.InterfaceInfo[0].isState) == "connected")
                                connectPass = true;
                            else
                                connetCount++;
                            if (ppInterfaceList != IntPtr.Zero)
                                WlanFreeMemory(ppInterfaceList);
                        }
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
                httpRequest.Timeout = 5000;
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

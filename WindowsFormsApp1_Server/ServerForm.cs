using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1_Server
{
    public partial class ServerForm : Form
    {        
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        // Tower lamp, Dll Import
        [DllImport("QUvc_dll.dll")]
        public static extern unsafe bool Usb_Qu_write(byte Q_index, byte Q_type, byte[] pQ_data);
        [DllImport("QUvc_dll.dll")]
        public static extern void Usb_Qu_Open();
        [DllImport("QUvc_dll.dll")]
        public static extern void Usb_Qu_Close();
        [DllImport("QUvc_dll.dll")]
        public static extern int Usb_Qu_Getstate();


        private string ConfigurePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\Configure\"));

        private Socket m_ServerSocket;
        private List<Socket> m_ClientSocket;
        private byte[] szData;

        private const int iEquipmentNo = 5;
        private string[] strAssetNo;
        private Label[] m_UnloaderStateBox;        

        // Unloader의 Towerlamp 신호를 저장할 변수 (5대)
        private string[] strRed;
        private string[] strYellow;
        private string[] strGreen;

        // 통신 여부
        private string[] strConn_receivedValue;
        private string[] strConn_previousValue;
        private DateTime[] lastReceivedTime;

        private bool bLampSet;
        
        public ServerForm()
        {
            InitializeComponent();

            strAssetNo = new string[iEquipmentNo];
            m_UnloaderStateBox = new Label[iEquipmentNo] { labl_Unloader1, labl_Unloader2, labl_Unloader3, labl_Unloader4, labl_Unloader5 };            

            _Init_Server();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;

            strRed = new string[iEquipmentNo];
            strYellow = new string[iEquipmentNo];
            strGreen = new string[iEquipmentNo];

            strConn_receivedValue = new string[iEquipmentNo];
            strConn_previousValue = new string[iEquipmentNo];
            lastReceivedTime = new DateTime[iEquipmentNo];

            // USB Tower lamp init
            _USB_Tower_lamp_init();            

            _Equipment_Description_Load();
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Usb_Qu_Close();

            Dispose();            
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void ServerForm_Activated(object sender, EventArgs e)
        {
            SetDoubleBuffered(richTextBoxServerStatus);
            SetDoubleBuffered(richTextBoxRecvMsg);
        }

        private void SetDoubleBuffered(Control control, bool doubleBuffered = true)
        {
            PropertyInfo propertyInfo = typeof(Control).GetProperty
            (
                "DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            propertyInfo.SetValue(control, doubleBuffered, null);
        }

        private void _USB_Tower_lamp_init()
        {
            try
            {
                Usb_Qu_Open();

                Towerlamp_Set(0, 0, 1, 0, 0, 0);
                bLampSet = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"USB Tower lamp init : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _Equipment_Description_Load()
        {
            try
            {
                // Ini file read
                StringBuilder sbUnloader = new StringBuilder();

                // Asset No
                GetPrivateProfileString("Unloader_1", "AssetNo", "", sbUnloader, sbUnloader.Capacity, string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                strAssetNo[0] = sbUnloader.ToString();
                labelUnloader1Asset.Text = strAssetNo[0];

                GetPrivateProfileString("Unloader_2", "AssetNo", "", sbUnloader, sbUnloader.Capacity, string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                strAssetNo[1] = sbUnloader.ToString();
                labelUnloader2Asset.Text = strAssetNo[1];

                GetPrivateProfileString("Unloader_3", "AssetNo", "", sbUnloader, sbUnloader.Capacity, string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                strAssetNo[2] = sbUnloader.ToString();
                labelUnloader3Asset.Text = strAssetNo[2];

                GetPrivateProfileString("Unloader_4", "AssetNo", "", sbUnloader, sbUnloader.Capacity, string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                strAssetNo[3] = sbUnloader.ToString();
                labelUnloader4Asset.Text = strAssetNo[3];

                GetPrivateProfileString("Unloader_5", "AssetNo", "", sbUnloader, sbUnloader.Capacity, string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                strAssetNo[4] = sbUnloader.ToString();
                labelUnloader5Asset.Text = strAssetNo[4];

                // Description
                GetPrivateProfileString("Unloader_1", "Description", "", sbUnloader, sbUnloader.Capacity, string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                textBoxUnloader1.Text = sbUnloader.ToString();
                
                GetPrivateProfileString("Unloader_2", "Description", "", sbUnloader, sbUnloader.Capacity, string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                textBoxUnloader2.Text = sbUnloader.ToString();

                GetPrivateProfileString("Unloader_3", "Description", "", sbUnloader, sbUnloader.Capacity, string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                textBoxUnloader3.Text = sbUnloader.ToString();

                GetPrivateProfileString("Unloader_4", "Description", "", sbUnloader, sbUnloader.Capacity, string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                textBoxUnloader4.Text = sbUnloader.ToString();

                GetPrivateProfileString("Unloader_5", "Description", "", sbUnloader, sbUnloader.Capacity, string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                textBoxUnloader5.Text = sbUnloader.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Equipment Description Load : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _Init_Server()
        {
            try
            {
                m_ClientSocket = new List<Socket>();
                m_ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Server IP 및 Port
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 8000);

                // Server binding
                m_ServerSocket.Bind(iPEndPoint);
                m_ServerSocket.Listen(10);

                // Socket event
                SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs();
                // Event 발생 시, Accept_Completed 함수 실행
                socketAsyncEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(_Accept_Completed);

                // Waiting for client connection
                m_ServerSocket.AcceptAsync(socketAsyncEventArgs);
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Init Server : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                        
        }

        /*
         * Client connection acceptance callback function
         */
        private void _Accept_Completed(object sender, SocketAsyncEventArgs e)
        {
            try
            {
                Socket clientSocket = e.AcceptSocket;

                // 요청 Socket을 수락 후 리스트에 추가
                m_ClientSocket.Add(clientSocket);

                if (m_ClientSocket != null)
                {
                    DisplayText_ServerStatus("<< " + clientSocket.RemoteEndPoint.ToString() + " >>" + " is connected");

                    SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs();

                    // 수신용 buffer 할당
                    szData = new byte[1024];
                    socketAsyncEventArgs.SetBuffer(szData, 0, 1024);
                    socketAsyncEventArgs.UserToken = m_ClientSocket;
                    socketAsyncEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(_Receive_Completed);

                    // 수락 된 Socket의 데이터 수신 대기
                    clientSocket.ReceiveAsync(socketAsyncEventArgs);
                }

                e.AcceptSocket = null;
                // 요청 Socket 처리 후 다시 수락 대기
                m_ServerSocket.AcceptAsync(e);
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Accept Completed : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * Data receive callback function
         */
        private void _Receive_Completed(object sender, SocketAsyncEventArgs e)
        {
            try
            {
                Socket clientSocket = (Socket)sender;

                // 해당 Socket의 접속 유무 확인 후 false면 Socket을 닫음
                if (clientSocket.Connected && e.BytesTransferred > 0)
                {
                    // Data receive                
                    byte[] szData = e.Buffer;
                    string strData = Encoding.Unicode.GetString(szData);
                    string[] arrayStr = strData.Split(';');
                    string sParsingData = arrayStr[0];
                    string recvMsg = sParsingData.Replace("\0", "").Trim();
                    DisplayText("<< " + clientSocket.RemoteEndPoint.ToString() + " >>" + recvMsg);

                    _DATA_PARSING(recvMsg);

                    for (int i = 0; i < szData.Length; i++)
                    {
                        szData[i] = 0;
                    }

                    for (int i = 0; i < arrayStr.Length; i++)
                    {
                        arrayStr[i] = string.Empty;
                    }

                    e.SetBuffer(szData, 0, 1024);
                    clientSocket.ReceiveAsync(e);
                }
                else
                {
                    // Socket 재사용 유무
                    clientSocket.Disconnect(false);

                    // Client socket 리스트에서 해당 Socket 삭제
                    m_ClientSocket.Remove(clientSocket);
                    DisplayText_ServerStatus("<< " + clientSocket.RemoteEndPoint.ToString() + " >>" + " is disconnected");
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Receive Completed : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void DisplayText_ServerStatus(string text)
        {
            try
            {
                if (richTextBoxServerStatus.InvokeRequired)
                {
                    richTextBoxServerStatus.BeginInvoke(new MethodInvoker(delegate
                    {
                        if (richTextBoxServerStatus.Lines.Length > 600)
                        {
                            richTextBoxServerStatus.Clear();
                        }

                        richTextBoxServerStatus.AppendText("[ " + DateTime.Now.ToString() + "] " + text + Environment.NewLine);
                        richTextBoxServerStatus.ScrollToCaret();
                    }));
                }
                else
                {
                    richTextBoxServerStatus.AppendText("[ " + DateTime.Now.ToString() + "] " + text + Environment.NewLine);
                    richTextBoxServerStatus.ScrollToCaret();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DisplayText ServerStatus : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayText(string text)
        {
            try
            {
                if (richTextBoxRecvMsg.InvokeRequired)
                {
                    richTextBoxRecvMsg.BeginInvoke(new MethodInvoker(delegate
                    {
                        if (richTextBoxRecvMsg.Lines.Length > 600)
                        {
                            richTextBoxRecvMsg.Clear();
                        }

                        richTextBoxRecvMsg.AppendText("[ " + DateTime.Now.ToString() + "] " + text + Environment.NewLine);
                        richTextBoxRecvMsg.ScrollToCaret();
                    }));
                }
                else
                {
                    richTextBoxRecvMsg.AppendText("[ " + DateTime.Now.ToString() + "] " + text + Environment.NewLine);
                    richTextBoxRecvMsg.ScrollToCaret();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DisplayText : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _DATA_PARSING(string strMsg)
        {
            try
            {
                string[] sWords = strMsg.Split(',');
                if (sWords.Length != 5)
                    return;

                if (sWords[0].Equals(strAssetNo[0], StringComparison.InvariantCultureIgnoreCase))
                {
                    strRed[0] = sWords[1];      // Red
                    strYellow[0] = sWords[2];   // Yellow
                    strGreen[0] = sWords[3];    // Green
                    strConn_receivedValue[0] = sWords[4];   // 통신 여부
                }
                else if (sWords[0].Equals(strAssetNo[1], StringComparison.InvariantCultureIgnoreCase))
                {
                    strRed[1] = sWords[1];      // Red
                    strYellow[1] = sWords[2];   // Yellow
                    strGreen[1] = sWords[3];    // Green
                    strConn_receivedValue[1] = sWords[4];   // 통신 여부
                }
                else if (sWords[0].Equals(strAssetNo[2], StringComparison.InvariantCultureIgnoreCase))
                {
                    strRed[2] = sWords[1];      // Red
                    strYellow[2] = sWords[2];   // Yellow
                    strGreen[2] = sWords[3];    // Green
                    strConn_receivedValue[2] = sWords[4];   // 통신 여부
                }
                else if (sWords[0].Equals(strAssetNo[3], StringComparison.InvariantCultureIgnoreCase))
                {
                    strRed[3] = sWords[1];      // Red
                    strYellow[3] = sWords[2];   // Yellow
                    strGreen[3] = sWords[3];    // Green
                    strConn_receivedValue[3] = sWords[4];   // 통신 여부
                }
                else if (sWords[0].Equals(strAssetNo[4], StringComparison.InvariantCultureIgnoreCase))
                {
                    strRed[4] = sWords[1];      // Red
                    strYellow[4] = sWords[2];   // Yellow
                    strGreen[4] = sWords[3];    // Green
                    strConn_receivedValue[4] = sWords[4];   // 통신 여부
                }


                // X-Ray room에서 모니터링
                _Show_Lamp_UI(strRed, strYellow, strGreen, strConn_receivedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DATA PARSING : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _Show_Lamp_UI(string[] Red, string[] Yellow, string[] Green, string[] Conn_receivedValue)
        {
            try
            {
                bool[] bUnloaderErr = new bool[5] { false, false, false, false, false };

                // Unloader#1
                this.labl_Unloader1.Invoke((MethodInvoker)delegate
                {
                    for (int i = 0; i < iEquipmentNo; i++)
                    {
                        /*
                        if (Conn_receivedValue[i] != strConn_previousValue[i])
                        {
                            strConn_previousValue[i] = Conn_receivedValue[i];
                            lastReceivedTime[i] = DateTime.Now; // 값이 바뀌면 마지막 수신 시간을 갱신                        
                        }

                        if ((DateTime.Now - lastReceivedTime[i]).TotalSeconds > 5)
                        {
                            // 5초 이상 값이 바뀌지 않으면 통신 끊어짐
                            m_UnloaderStateBox[i].Text = "No communication";
                            m_UnloaderStateBox[i].ForeColor = Color.Red;
                        }
                        */

                        if (Red[i] == "True")
                        {
                            m_UnloaderStateBox[i].Text = "Error";

                            if (m_UnloaderStateBox[i].BackColor != Color.Red)
                                m_UnloaderStateBox[i].BackColor = Color.Red;
                            else
                                m_UnloaderStateBox[i].BackColor = Color.Silver;

                            bUnloaderErr[i] = true;
                        }
                        else if (Yellow[i] == "True")
                        {
                            m_UnloaderStateBox[i].Text = "Idle";

                            if (m_UnloaderStateBox[i].BackColor != Color.Yellow)
                                m_UnloaderStateBox[i].BackColor = Color.Yellow;

                            bUnloaderErr[i] = false;
                        }
                        else if (Green[i] == "True")
                        {
                            m_UnloaderStateBox[i].Text = "Auto Run";

                            if (m_UnloaderStateBox[i].BackColor != Color.Lime)
                                m_UnloaderStateBox[i].BackColor = Color.Lime;

                            bUnloaderErr[i] = false;
                        }
                        else if ((Red[i] == "False") && (Yellow[i] == "False") && (Green[i] == "False"))
                        {
                            m_UnloaderStateBox[i].Text = "No signal";

                            if (m_UnloaderStateBox[i].BackColor != Color.Silver)
                                m_UnloaderStateBox[i].BackColor = Color.Silver;

                            bUnloaderErr[i] = false;
                        }
                    }

                    if ((bUnloaderErr[0]) || (bUnloaderErr[1]) || (bUnloaderErr[2]) || (bUnloaderErr[3]) || (bUnloaderErr[4]))
                    {
                        if (!bLampSet)
                        {
                            Towerlamp_Set(1, 0, 0, 0, 0, 1);
                            bLampSet = true;

                            // Form이 작업표시줄로 내려가 있거나, 다른 프로그램 뒤에 가려져 있을 때 활성화                            
                            WindowState = FormWindowState.Normal;
                            TopMost = true;
                        }
                    }
                    else
                    {
                        if (bLampSet)
                        {
                            Towerlamp_Set(0, 0, 1, 0, 0, 0);
                            bLampSet = false;                            
                        }

                        if (TopMost != false)
                            TopMost = false;
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Show Lamp UI : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                        
        }

        private void Towerlamp_Set(byte Red, byte Yellow, byte Green, byte Blue, byte White, byte Sound)
        {
            try
            {
                byte[] bAcon = new byte[6];
                bAcon[0] = Red;
                bAcon[1] = Yellow;
                bAcon[2] = Green;
                bAcon[3] = Blue;
                bAcon[4] = White;
                bAcon[5] = Sound;

                Usb_Qu_write(0, 0, bAcon);
            }
            catch
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                WritePrivateProfileString("Unloader_1", "Description", textBoxUnloader1.Text.ToString(), string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                WritePrivateProfileString("Unloader_2", "Description", textBoxUnloader2.Text.ToString(), string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                WritePrivateProfileString("Unloader_3", "Description", textBoxUnloader3.Text.ToString(), string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                WritePrivateProfileString("Unloader_4", "Description", textBoxUnloader4.Text.ToString(), string.Format("{0}{1}", ConfigurePath, "Configure.ini"));
                WritePrivateProfileString("Unloader_5", "Description", textBoxUnloader5.Text.ToString(), string.Format("{0}{1}", ConfigurePath, "Configure.ini"));

                _Equipment_Description_Load();

                MessageBox.Show($"장비 메모 저장 완료!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"btnSave Click : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuzzerOff_Click(object sender, EventArgs e)
        {
            Towerlamp_Set(0, 0, 1, 0, 0, 0);
            bLampSet = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApp1_Server
{
    public partial class ServerForm : Form
    {
        private Socket m_ServerSocket;
        private List<Socket> m_ClientSocket;
        private byte[] szData;

        // Unloader의 Towerlamp 신호를 저장할 변수 (5대)
        public string[] strRed;
        public string[] strYellow;
        public string[] strGreen;

        public ServerForm()
        {
            InitializeComponent();

            _Init_Server();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;

            strRed = new string[5];
            strYellow = new string[5];
            strGreen = new string[5];
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void _Init_Server()
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

        /*
         * Client connection acceptance callback function
         */
        private void _Accept_Completed(object sender, SocketAsyncEventArgs e)
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

        /*
         * Data receive callback function
         */
        private void _Receive_Completed(object sender, SocketAsyncEventArgs e)
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

        private void DisplayText_ServerStatus(string text)
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

        private void DisplayText(string text)
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

        private void _DATA_PARSING(string strMsg)
        {
            try
            {
                string[] sWords = strMsg.Split(',');
                if (sWords[0].Equals("Unloader#1", StringComparison.InvariantCultureIgnoreCase))
                {
                    strRed[0] = sWords[1];      // Red
                    strYellow[0] = sWords[2];   // Yellow
                    strGreen[0] = sWords[3];    // Green
                }
                else if (sWords[0].Equals("Unloader#2", StringComparison.InvariantCultureIgnoreCase))
                {
                    strRed[1] = sWords[1];      // Red
                    strYellow[1] = sWords[2];   // Yellow
                    strGreen[1] = sWords[3];    // Green
                }
                else if (sWords[0].Equals("Unloader#3", StringComparison.InvariantCultureIgnoreCase))
                {
                    strRed[2] = sWords[1];      // Red
                    strYellow[2] = sWords[2];   // Yellow
                    strGreen[2] = sWords[3];    // Green
                }
                else if (sWords[0].Equals("Unloader#4", StringComparison.InvariantCultureIgnoreCase))
                {
                    strRed[3] = sWords[1];      // Red
                    strYellow[3] = sWords[2];   // Yellow
                    strGreen[3] = sWords[3];    // Green
                }
                else if (sWords[0].Equals("Unloader#5", StringComparison.InvariantCultureIgnoreCase))
                {
                    strRed[4] = sWords[1];      // Red
                    strYellow[4] = sWords[2];   // Yellow
                    strGreen[4] = sWords[3];    // Green
                }


                // X-Ray room에서 모니터링
                _Show_Lamp_UI(strRed, strYellow, strGreen);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _Show_Lamp_UI(string[] Red, string[] Yellow, string[] Green)
        {
            if (Red[0] == "True")
            {
                panelUnloader1_Red.BackColor = Color.Red;
            }
            
            if (Yellow[0] == "True")
            {
                panelUnloader1_Yellow.BackColor = Color.Yellow;
            }

            if (Green[0] == "True")
            {
                panelUnloader1_Green.BackColor = Color.Blue;
            }
        }
    }
}

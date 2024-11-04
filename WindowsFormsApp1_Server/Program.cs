using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1_Server
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        static Mutex mutex = null;

        [STAThread]
        static void Main()
        {
            // 고유한 이름으로 Mutex 생성
            string mutexName = "WindowsFormsApp1_Server_UniqueMutexName";
            bool isNewInstance;
            mutex = new Mutex(true, mutexName, out isNewInstance);
            if (!isNewInstance)
            {
                // 이미 실행 중인 경우 메시지를 출력하고 종료                
                MessageBox.Show($"이미 프로그램이 실행 중입니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerForm());

            // 애플리케이션이 종료될 때까지 Mutex 유지
            GC.KeepAlive(mutex);
        }
    }
}

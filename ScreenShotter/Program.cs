using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace ScreenShotter
{
    public static class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool PostMessage(IntPtr hhwnd, uint msg, uint wparam, uint lparam);
        [DllImport("user32.dll")]
        public static extern uint RegisterWindowMessage(string message);

        static string appid = "a77a67-baa7a7a7-4123-9ff-67-6-7234ababab675-5374-777";
        public static uint ao = RegisterWindowMessage("SS_ANOTHER_INSTANCE");
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + appid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    PostMessage((IntPtr)0xffff, ao, 0, 0);
                    return;
                }
                MemoryManagement.FlushMemory();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ScreenShotter SSMain = new ScreenShotter();
                Application.Run();
            }
        }
    }
}
    

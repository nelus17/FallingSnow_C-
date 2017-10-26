using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading;

namespace Snow
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        private static Mutex m_Mutex;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            m_Mutex = new Mutex(true, "SnowFallMutex");

            if (m_Mutex.WaitOne(0, false))
                Application.Run(new MainForm());
        }
    }
}
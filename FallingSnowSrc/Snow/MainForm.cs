using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Snow
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Rectangle rcWorkArea = Screen.PrimaryScreen.WorkingArea;
            int nScreenWidth = rcWorkArea.Width;

            int nTimer = 5;
            int nPosX = 0;

            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                nTimer = r.Next(50);
                nPosX = r.Next(nScreenWidth);
                
                FlakeDlg fd = new FlakeDlg(nTimer, nPosX);
                fd.Show();
            }
        }

        private void OnTrayIcon(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                AboutForm formAbout = new AboutForm();
                formAbout.ShowDialog();

                // or
                // this.Close();
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnAbout(object sender, EventArgs e)
        {
            AboutForm formAbout = new AboutForm();
            formAbout.ShowDialog();            
        }
    }
}
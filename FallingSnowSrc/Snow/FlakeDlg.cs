using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Snow
{
    public partial class FlakeDlg : Form
    {
        private int m_nTimer = 0;
        private int m_nCurrentX = 0;
        private int m_nCurrentY = 0;
        private int m_nScreenHeight = 0;
        private int m_nScreenWidth = 0;
        private int m_nCounter = 0;
        private int m_nIncrement = 1;

        private Bitmap bmpFlake = new Bitmap(typeof(FlakeDlg), "flake.bmp");

        public FlakeDlg(int nTimer, int nPosX)
        {
            m_nTimer = nTimer + 10;
            m_nCurrentX = nPosX;

            InitializeComponent();

            BitmapRegion.CreateControlRegion(this, bmpFlake);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Rectangle rcWorkArea = Screen.PrimaryScreen.WorkingArea;
            m_nScreenWidth = rcWorkArea.Width;
            m_nScreenHeight = rcWorkArea.Height;

            this.timerMove.Interval = m_nTimer;
            this.Left = m_nCurrentX;
            this.timerMove.Start();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            this.timerMove.Stop();

            m_nCurrentY += 5;
            m_nCounter++;

            Random r = new Random();
            if (m_nCounter == 15)
            {
                if ((r.Next(10) - 5) > 0) m_nIncrement = 1;
                else m_nIncrement = -1;

                m_nCounter = 0;
            }

            m_nCurrentX += m_nIncrement;

            if (m_nCurrentY > m_nScreenHeight)
            {
                m_nCurrentY = 0;
                m_nCurrentX = r.Next(m_nScreenWidth);
                m_nTimer = r.Next(50) + 10;
            }

            this.Left = m_nCurrentX;
            this.Top = m_nCurrentY;

            this.timerMove.Interval = m_nTimer;
            this.timerMove.Start();
        }
    }
}
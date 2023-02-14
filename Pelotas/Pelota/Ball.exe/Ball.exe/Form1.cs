using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ball.exe
{
    public partial class Form1 : Form
    {
        private int ballWidth = 50;
        private int ballHeight = 50;
        private int ballPosX = 0;
        private int ballPosY = 0;
        private int moveStepX = 7;
        private int moveStepY = 7;
        private int ball2Width = 50;
        private int ball2Height = 50;
        private int ball2PosX = 0;
        private int ball2PosY = 0;
        private int moveStep2X = 5;
        private int moveStep2Y = 5;
        static Graphics g;

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            this.UpdateStyles();
        }

        private void PaintCircle(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.Clear(this.BackColor);

            e.Graphics.FillEllipse(Brushes.Blue, ballPosX, ballPosY, ballWidth, ballHeight);
            e.Graphics.DrawEllipse(Pens.White, ballPosX, ballPosY, ballWidth, ballHeight);

            e.Graphics.FillEllipse(Brushes.Green, ball2PosX, ball2PosY, ball2Width, ball2Height);
            e.Graphics.DrawEllipse(Pens.White, ball2PosX, ball2PosY, ball2Width, ball2Height);
        }

        private void Move(object sender, EventArgs e)
        {
            ballPosX += moveStepX;
            if (ballPosX < 0 || ballPosX + ballWidth > this.ClientSize.Width)
            {
                moveStepX = -moveStepX;
            }

            ballPosY += moveStepY;
            if (ballPosY < 0 || ballPosY + ballHeight > this.ClientSize.Height)
            {
                moveStepY = -moveStepY;
            }

            ball2PosX += moveStep2X;
            if (ball2PosX < 0 || ball2PosX + ball2Width > this.ClientSize.Width)
            {
                moveStep2X = -moveStep2X;
            }

            ball2PosY += moveStep2Y;
            if (ball2PosY < 0 || ball2PosY + ball2Height > this.ClientSize.Height)
            {
                moveStep2Y = -moveStep2Y;
            }

            this.Refresh();
        }
    }
}
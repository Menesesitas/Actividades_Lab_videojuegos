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
        //-------------------------
        private int ball2Width = 50;
        private int ball2Height = 50;
        private int ball2PosX = 0;
        private int ball2PosY = 0;
        private int moveStep2X = 5;
        private int moveStep2Y = 5;
        //--------------------------
        private int ball3Width = 50;
        private int ball3Height = 50;
        private int ball3PosX = 0;
        private int ball3PosY = 0;
        private int moveStep3X = 6;
        private int moveStep3Y = 6;
        //--------------------------
        private int ball4Width = 50;
        private int ball4Height = 50;
        private int ball4PosX = 0;
        private int ball4PosY = 0;
        private int moveStep4X = 8;
        private int moveStep4Y = 8;
        //--------------------------
        private int ball5Width = 50;
        private int ball5Height = 50;
        private int ball5PosX = 0;
        private int ball5PosY = 0;
        private int moveStep5X = 4;
        private int moveStep5Y = 4;
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

            e.Graphics.FillEllipse(Brushes.Red, ball3PosX, ball3PosY, ball3Width, ball3Height);
            e.Graphics.DrawEllipse(Pens.White, ball3PosX, ball3PosY, ball3Width, ball3Height);

            e.Graphics.FillEllipse(Brushes.Yellow, ball4PosX, ball4PosY, ball4Width, ball4Height);
            e.Graphics.DrawEllipse(Pens.White, ball4PosX, ball4PosY, ball4Width, ball4Height);

            e.Graphics.FillEllipse(Brushes.Purple, ball5PosX, ball5PosY, ball5Width, ball5Height);
            e.Graphics.DrawEllipse(Pens.White, ball5PosX, ball5PosY, ball5Width, ball5Height);
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

            //--------------------------

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

            //--------------------------

            ball3PosX += moveStep3X;
            if (ball3PosX < 0 || ball3PosX + ball3Width > this.ClientSize.Width)
            {
                moveStep3X = -moveStep3X;
            }

            ball3PosY += moveStep3Y;
            if (ball3PosY < 0 || ball3PosY + ball3Height > this.ClientSize.Height)
            {
                moveStep3Y = -moveStep3Y;
            }

            //--------------------------

            ball4PosX += moveStep4X;
            if (ball4PosX < 0 || ball4PosX + ball4Width > this.ClientSize.Width)
            {
                moveStep4X = -moveStep4X;
            }

            ball4PosY += moveStep4Y;
            if (ball4PosY < 0 || ball4PosY + ball4Height > this.ClientSize.Height)
            {
                moveStep4Y = -moveStep4Y;
            }

            //--------------------------

            ball5PosX += moveStep5X;
            if (ball5PosX < 0 || ball5PosX + ball5Width > this.ClientSize.Width)
            {
                moveStep5X = -moveStep5X;
            }

            ball5PosY += moveStep5Y;
            if (ball5PosY < 0 || ball5PosY + ball5Height > this.ClientSize.Height)
            {
                moveStep5Y = -moveStep5Y;
            }

            this.Refresh();
        }
    }
}
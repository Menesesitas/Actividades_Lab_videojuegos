using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Pelotas.Properties;
using System.Drawing.Imaging;

namespace Pelotas
{
    public partial class Pelotas : Form
    {
        static List<Pelota> balls;
        static Bitmap bmp;
        static Graphics g;
        static Random rand = new Random();
        static float deltaTime;
        static float Timelap;
        Image Volcan = Resource1.Volcan;
        Image particulaImage = Resource1.Lava_1;

        
        public int alpha = 255;

        ParticleEmisor1 emitter = new ParticleEmisor1(rand, new Size(800, 600), 100, 100);

        public Pelotas()
        {
            InitializeComponent();
        }

        private void Init()
        {
            if (PCT_CANVAS.Width == 0)
                return;

            balls       = new List<Pelota>();
            bmp         = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g           = Graphics.FromImage(bmp);
            deltaTime   = 1;
            PCT_CANVAS.Image = bmp;

            for (int b = 0; b < 500; b++)
                balls.Add(new Pelota (rand, PCT_CANVAS.Size, b));
        }

        private void Pelotas_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Pelotas_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }


        private void TIMER_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
            emitter.Update(deltaTime);
            

            for (int i = balls.Count - 1; i >= 0; i--)
            {
                Pelota P;
                P = balls[i];
                balls[i].Update(deltaTime, balls);
            }
            /*Parallel.For(0, balls.Count, b =>//ACTUALIZAMOS EN PARALELO
            {
                Pelota P;
                balls[b].Update(deltaTime, balls);
                P = balls[b];               
            });*/

            Pelota p;
            for (int b = 0; b < balls.Count; b++)//PINTAMOS EN SECUENCIA
            {
                p = balls[b];
                /*g.FillEllipse(new SolidBrush(p.c), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);

                Color color = Color.FromArgb(alpha, 255, 255, 255);

                alpha = 255;
                alpha -= 5;
                color = Color.FromArgb(alpha, 255, 255, 255);*/
                ImageAnimator.UpdateFrames(particulaImage);
                g.DrawImage(particulaImage, p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            }

            PCT_CANVAS.Invalidate();
            deltaTime += .1f;
            Timelap += deltaTime;
            g.DrawImage(Volcan, new Rectangle(-350, PCT_CANVAS.Height - 500, PCT_CANVAS.Width, 500));

        }

    }
}

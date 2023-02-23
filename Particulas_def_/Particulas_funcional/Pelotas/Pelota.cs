using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pelotas
{
    public class Pelota
    {
        int index;
        Size space;
        public Color c;
        static Random rand = new Random();
        // Variables de posición
        public float x;
        public float y;

        // Variables de velocidad
        private float vx;
        private float vy;

        // Variable de radio
        public float radio;

        //Variable del tiempo de vida
        public float lifetime;
        public float limitTime;


        // Constructor
        public Pelota(Random rand, Size size, int index)
        {
            this.radio = rand.Next(20, 35);
            this.x = rand.Next(400, 622); 
            this.y = 1000;  //rand.Next((int)radio , size.Height - (int)radio );           
            c           = Color.FromArgb(rand.Next(255, 255), rand.Next(60, 60), rand.Next(0, 0));
            this.vx = rand.Next(0, 5);
            this.vy = rand.Next(0, 75);

            this.index = index;
            space = size;

            this.lifetime = rand.Next(100, 300);
        }


        // Método para actualizar la posición de la pelota en función de su velocidad
        public void Update(float deltaTime, List<Pelota> balls)
        {

            Random RAND = new Random();
            //int alpha;
            if (this.lifetime <= 0)
            {
                balls.Remove(this);
                if (balls.Count <= 200)
                {
                    balls.Add(new Pelota(rand, space, balls.Count));
                }

            }

            for (int b = index + 1; b < balls.Count; b++)
            {
                Collision(balls[b]);
            }

            if ((x - radio) <= 0 || (x + radio) >= space.Width)
            {
                if (x - radio <= 0)
                    x = radio + 3;
                else
                    x = space.Width - radio - 3;

                vx *= -.10f;
                vy *= .25f;
            }

            if ((y - radio) == 0 || (y + radio) >= space.Height)
            {
                if (y - radio <= 0)
                    y = radio + 3;
                else
                    y = space.Height - radio - 3;

                vx *= .10f;
                vy *= -.50f;
            }

            this.x += this.vx * deltaTime;
            this.y += this.vy * deltaTime;

            this.limitTime -= deltaTime;

            int alpha = (int)Math.Min(255, 255 * this.lifetime / 160);
            if (alpha <= 0) alpha = 0;
            this.c = Color.FromArgb(alpha, c.R, c.G, c.B);
            // Si el tiempo de vida llega a cero, remover la pelota de la lista



            this.lifetime -= 2;

        }

        // Método para manejar colisiones entre pelotas
        public void Collision(Pelota otraPelota)
        {
            float distancia = (float)Math.Sqrt(Math.Pow((otraPelota.x - this.x), 2) + Math.Pow((otraPelota.y - this.y), 2));

            if (distancia < (this.radio + otraPelota.radio))//ESTO SIGNIFICA COLISIÓN...
            {
                // Calculamos las velocidades finales de cada pelota en función de su masa y velocidad inicial
                float masaTotal = this.radio + otraPelota.radio;
                float masaRelativa = this.radio / masaTotal;

                float v1fx = this.vx - masaRelativa * (this.vx - otraPelota.vx);
                float v1fy = this.vy - masaRelativa * (this.vy - otraPelota.vy) / 10;

                float v2fx = otraPelota.vx - masaRelativa * (otraPelota.vx - this.vx);
                float v2fy = otraPelota.vy - masaRelativa * (otraPelota.vy - this.vy) / 10;

                // Actualizamos las velocidades de las pelotas
                this.vx = v1fx;     // -----AQUI CAMBIAMOS EL ANGULO---------
                this.vy = v1fy;     // -----AQUI CAMBIAMOS EL ANGULO--------------

                otraPelota.vx = v2fx;//-----AQUI CAMBIAMOS EL ANGULO----------------------
                otraPelota.vy = v2fy;//-----AQUI CAMBIAMOS EL ANGULO----------------------

                // Movemos las pelotas para evitar que se superpongan
                float distanciaOverlap = (this.radio + otraPelota.radio) - distancia;
                float dx = (this.x - otraPelota.x) / distancia;
                float dy = (this.y - otraPelota.y) / distancia;

                this.x += dx * distanciaOverlap / 2f;
                this.y += dy * distanciaOverlap / 2f;

                otraPelota.x -= dx * distanciaOverlap / 2f;
                otraPelota.y -= dy * distanciaOverlap / 2f;
            }
        }

    }

}

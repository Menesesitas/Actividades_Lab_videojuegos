using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pelotas
{
    public class ParticleEmisor1
    {
        int index;
        Size space;
        public Color c;
        // Variables de posición
        public float x;
        public float y;

        // Variables de velocidad
        private float vx;
        private float vy;

        // Variable de radio
        public float radio;

        //Vida de las pelotas
        public float vida;

        public ParticleEmisor1 (Random rand, Size size, int index)
        {
            this.radio = rand.Next(20, 25);
            this.x = rand.Next((int)radio, size.Width - (int)radio);
            this.y = 1000;  //rand.Next((int)radio , size.Height - (int)radio );           
            c = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            // Velocidades iniciales
            this.vx = rand.Next((int)-radio, (int)radio);
            this.vy = rand.Next((int)-radio, (int)radio);

            this.index = index;
            space = size;

            //vida = 5f; //vida de 5 segundos
        }
    }
}

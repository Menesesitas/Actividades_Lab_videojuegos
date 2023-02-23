using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pelotas
{
    public class ParticleEmisor1
    {
        private Random rand;
        public List<Pelota> particulas;

        private Size space;
        private int max;

        private float emision;
        private float timer;

        public float x;
        public float y;
        public ParticleEmisor1(Random rand, Size space, int max, float emision)
        {
            this.rand = rand;
            this.particulas = new List<Pelota>();
            this.space = space;
            this.max = max;
            this.emision = emision;
            this.timer = 0;
            this.x = 70;
            this.y = 0;
        }


        public void Update(float deltaTime)
        {
            if (particulas.Count < max)
            {
                timer += deltaTime;

                if (timer >= 0 / emision)
                {
                    Pelota newParticle = new Pelota(rand, space, particulas.Count);
                    timer = 0;
                }
            }
        }
    }
}

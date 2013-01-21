using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Templar
{
    class poper_particule
    {
        Queue<particule> ParticleList;
        public List<Color> CouleurList { get; set; }
        Vector2 Position;
        public int nbpop { get; set; }

        public poper_particule(particule particule, Vector2 position)
        {
            Position = position;
            ParticleList = new Queue<particule>();
            CouleurList = new List<Color>();
            CouleurList = new List<Color> { Color.Brown, Color.DarkOrange, Color.DarkRed, Color.Black };
        }

        public void UpdateParticles()
        {
            if (ParticleList.Count <= nbpop)
            {
                particule particule = new particule(Position);

                ParticleList.Enqueue(particule);
            }

            if (ParticleList.Count >= nbpop)
            {
                ParticleList.Dequeue();
            }
        }

        public void DrawParticles(SpriteBatch spriteBatch)
        {
            int i = 0;

            foreach (particule particle in ParticleList)
            {
                if (i > CouleurList.Count - 1)
                    i = 0;

                spriteBatch.Draw(ressource.particule, Position, CouleurList[i]);
                i++;
            }
        }
    }

}

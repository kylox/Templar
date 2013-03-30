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
    class particule
    {

        Vector2 Position;
        public Vector2 _position
        {
            get { return Position; }
            set { Position = value; }
        }

        public particule(Vector2 position)
        {
            Position = position;
        }

        public void update()
        {

        }
    }
}

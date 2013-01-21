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
    abstract class item
    {
        Texture2D Texture;
        protected Vector2 Position;

        public item(Texture2D texture, GamePlayer player, Vector2 position, GameScreen screen)
        {
            Texture = texture;
            Position = position;
        }

        public virtual void update()
        {

        }

        public virtual void draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Position, Color.White);
        }
    }
}

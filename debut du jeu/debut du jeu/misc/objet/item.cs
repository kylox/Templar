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
    public abstract class item
    {
        public int[] Bonus;
        public Texture2D Texture;
        public Vector2 Position;
        public bool usable;
        public string utilité;
        public bool is_equipable;
        public item(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            usable = false;
            is_equipable = false;
            Bonus = new int[]{0,0,0,0,0,0,0};
        }
        public virtual void action(gamemain main)
        {
        }
        public virtual void update()
        {
        }
        public virtual void draw(SpriteBatch spritebatch, int x, int y, int z, int w)
        {
        }
    }
}

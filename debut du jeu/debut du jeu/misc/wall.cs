using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Templar
{
   public class wall
    {
        //fields
        public Rectangle Hitbox;
        Texture2D Texture;
        Color Color;

        //constructor
        public wall(int x, int y, Texture2D texture, int size, Color color) // creer un mur avec une postion(x,y) une texture et une couleur 
        {
            this.Texture = texture;
            this.Hitbox = new Rectangle(x, y, size, size);
            this.Color = color;
        }

        //method

        //update && draw
        public void Update(MouseState mouse, KeyboardState keyboard)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Hitbox, this.Color); //dessine CE PUTAIN DE MUR !! 
        }
    }
}

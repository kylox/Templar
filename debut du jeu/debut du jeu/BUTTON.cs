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
    class BUTTON
    {
        Texture2D Texture;
        Rectangle Bouton;
        bool click_down;
        public Rectangle Hitbox_button
        {
            get { return Bouton; }
            set { Bouton = value; }
        }

        public BUTTON(Texture2D texture, Rectangle bouton)
        {
            Texture = texture;
            Bouton = bouton;
        }
       
        public void Update(MouseEvent mouse)
        {
            if (Bouton.Intersects(mouse.getMousecontainer()))
                click_down = true;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (click_down == false)
                spriteBatch.Draw(Texture, Bouton, Color.White);

            else
                spriteBatch.Draw(Texture, Bouton, Color.DarkRed);
        }


    }
}

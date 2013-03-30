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
    class MouseEvent
    {
        MouseState buttonpressed;
        Rectangle mouseDetection;

        public bool UpdateMouse()
        {
            buttonpressed = Mouse.GetState();

            if (buttonpressed.LeftButton == ButtonState.Pressed)
                return true;

            else
                return false;
        }

        public Rectangle getMousecontainer()
        {
            mouseDetection = new Rectangle((int)buttonpressed.X, (int)buttonpressed.Y, 1, 1);

            return mouseDetection;
        }
    }
}

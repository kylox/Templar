using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Templar.ecran.liste_des_ecrans
{
    class Menudeuxjoueurs : GameScreen
    {
        //fields
        Texture2D image;
        menugenerale menugenerale;
        Rectangle rec;
        public int SelectedIndex
        {
            get { return menugenerale.SelectedIndex; }
            set { menugenerale.SelectedIndex = value; }
        }
    }
}

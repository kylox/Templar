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
    public class Coffre
    {
        public bool is_open;
        item[,] tab;
        public Coffre(Vector2 position)
        {
            tab = new item[5, 5];
            is_open = false;
        }
        public void Draw(SpriteBatch spritebatch, Rectangle Fenetre)
        {
            if (is_open == true)
            {
                spritebatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width / 3, Fenetre.Height / 3, 160, 160), Color.Black);
                for (int i = 0; i < tab.GetLength(0); i++)
                    for (int j = 0; j < tab.GetLength(1); j++)
                    {
                        spritebatch.Draw(ressource.selection_sort, new Rectangle(Fenetre.Width / 3 + i * 32, Fenetre.Height / 3
                            + j * 32, 32 + i, 32 + j), Color.White);
                        if (tab[i, j] != null)
                            tab[i, j].draw(spritebatch);
                    }
            }
        }
    }
}

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
        public Vector2 selection;
        public bool is_open;
        public Items[,] tab;
        public Coffre(Vector2 position)
        {
            selection = new Vector2(0, 0);
            tab = new Items[5, 5];
            is_open = false;
        }
        public void Update(GamePlayer player)
        {
            if (is_open)
            {
                if (Data.keyboardState.IsKeyDown(Keys.Right) && Data.prevKeyboardState.IsKeyUp(Keys.Right))
                {
                    selection.X += 32;
                    if (selection.X > 4 * 32)
                        selection.X = 0;
                }
                if (Data.keyboardState.IsKeyDown(Keys.Left) && Data.prevKeyboardState.IsKeyUp(Keys.Left))
                {
                    selection.X -= 32;
                    if (selection.X < 0)
                        selection.X = 4 * 32;
                }
                if (Data.keyboardState.IsKeyDown(Keys.Up) && Data.prevKeyboardState.IsKeyUp(Keys.Up))
                {
                    selection.Y -= 32;
                    if (selection.Y < 0)
                        selection.Y = 4 * 32;
                }
                if (Data.keyboardState.IsKeyDown(Keys.Down) && Data.prevKeyboardState.IsKeyUp(Keys.Down))
                {
                    selection.Y += 32;
                    if (selection.Y > 4 * 32)
                        selection.Y = 0;
                }
                if (Data.keyboardState.IsKeyDown(Keys.Enter) && Data.prevKeyboardState.IsKeyUp(Keys.Enter))
                {
                    if (player.nb_item(player.inventaire) != 25 && this.tab[(int)selection.X / 32, (int)selection.Y / 32] != null)
                    {
                        for (int j = 0; j < 5; j++)
                            for (int i = 0; i < 5; i++)
                                if (player.inventaire[i, j] == null)
                                {
                                    player.inventaire[i, j] = this.tab[(int)selection.X / 32, (int)selection.Y / 32];
                                    i = 5;
                                    j = 5;
                                }

                        this.tab[(int)selection.X / 32, (int)selection.Y / 32] = null;
                    }
                }
            }
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
                            tab[i, j].draw(spritebatch, Fenetre.Width / 3 + i * 32, Fenetre.Height / 3
                            + j * 32, 32, 32);
                    }
            }
        }
        public void Draw(SpriteBatch spritebatch, int x, int y)
        {
            if (is_open == true)
            {
                spritebatch.Draw(ressource.pixel, new Rectangle(x, y, 160, 160), Color.Black);
                for (int i = 0; i < tab.GetLength(0); i++)
                    for (int j = 0; j < tab.GetLength(1); j++)
                    {
                        spritebatch.Draw(ressource.selection_sort, new Rectangle(x + i * 32, y
                            + j * 32, 32, 32), Color.White);
                    }
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        if (tab[i, j] != null)
                            spritebatch.Draw(ressource.item, new Rectangle(x + i * 32, y + j * 32, 32, 32), new Rectangle((int)tab[i, j].positin_tile.X * 32, (int)tab[i, j].positin_tile.Y * 32, 32, 32), Color.White);

                spritebatch.Draw(ressource.pixel, new Rectangle((int)selection.X + x, (int)selection.Y + y, 2, 32), Color.Red);
                spritebatch.Draw(ressource.pixel, new Rectangle((int)selection.X + x, (int)selection.Y + y, 32, 2), Color.Red);
                spritebatch.Draw(ressource.pixel, new Rectangle((int)selection.X + 32 + x, (int)selection.Y + y, 2, 32), Color.Red);
                spritebatch.Draw(ressource.pixel, new Rectangle((int)selection.X + x, (int)selection.Y + 32 + y, 32, 2), Color.Red);

            }
        }
    }
}

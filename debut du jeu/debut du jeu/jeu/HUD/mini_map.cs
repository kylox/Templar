using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Templar
{
    class mini_map
    {
        GamePlayer Player;
        gamemain Main;
        Vector2 Postion_red_dot;
        Rectangle fenetre;

        public mini_map(GamePlayer player, gamemain main)
        {
            Player = player;
            Main = main;

            Postion_red_dot.X = (Player.Position.X / 5) + Main.Fenetre.Width - 200;
            Postion_red_dot.Y = (Player.Position.Y / 5) + Main.Fenetre.Height - 100;
     
            fenetre = new Rectangle(Main.Fenetre.Width - 200 + 10,
                                    Main.Fenetre.Height - 100 + 10 ,
                                    Main.Fenetre.Width / 5,
                                    Main.Fenetre.Height / 5); 
        }

        public void update()
        {
            Postion_red_dot.X = (Player.Position.X / 5) + Main.Fenetre.Width - 200 + 10;
            Postion_red_dot.Y = (Player.Position.Y / 5) + Main.Fenetre.Height - 100 + 10;
        }

        public void draw(SpriteBatch Spritebatch)
        {
            Spritebatch.Draw(ressource.pixel, fenetre, Color.White);
            Spritebatch.Draw(ressource.pixel, new Rectangle((int)Postion_red_dot.X, (int)Postion_red_dot.Y, 5, 5), Color.Red);
        }
    }
}

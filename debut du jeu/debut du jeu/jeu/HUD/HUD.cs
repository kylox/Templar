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
    class HUD
    {
        GamePlayer localPlayer;
        gamemain Main;
        Rectangle barre_vie, barre_endurance, barre_mana, barre_v, barre_e, barre_m, barre_xp, barre_experience;
        mini_map mini_map;

        public HUD(GamePlayer Player, gamemain main)
        {
            localPlayer = Player;
            Main = main;

            //dessine les rectangle 
            barre_vie = new Rectangle(100, 0, localPlayer.pv_player, 20);
            barre_endurance = new Rectangle(300, 0, localPlayer.end_player, 20);
            barre_mana = new Rectangle(500, 0, localPlayer.mana_player, 20);
            barre_experience = new Rectangle((2 * Main.Fenetre.Width / 6) - 26, Main.Fenetre.Height - 87, localPlayer.XP, 10);

            //dessine les truc qui entour les rectangles 
            barre_v = new Rectangle(0, Main.Fenetre.Height - 94, 142, 34);
            barre_e = new Rectangle(0, Main.Fenetre.Height - 62, 142, 34);
            barre_m = new Rectangle(0, Main.Fenetre.Height - 30, 142, 34);
            barre_xp = new Rectangle((2 * Main.Fenetre.Width / 6) - 30, Main.Fenetre.Height - 80
                , (Main.Fenetre.Width / 5) + 150, 10);

            //dessine une mini map
            mini_map = new mini_map(localPlayer, main);

        }

        public void update()
        {
            mini_map.update();
            //update des barres de vie d'endurance et de mana 
            barre_vie = new Rectangle(20, Main.Fenetre.Height - 80, localPlayer.pv_player, 7);
            barre_endurance = new Rectangle(20, Main.Fenetre.Height - 48, localPlayer.end_player, 7);
            barre_mana = new Rectangle(20, Main.Fenetre.Height - 18, localPlayer.mana_player, 7);
            barre_experience = new Rectangle((2 * Main.Fenetre.Width / 6) - 26, Main.Fenetre.Height - 76, localPlayer.XP * ((Main.Fenetre.Width / 5) + 150) / 100, 3);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            //dessine les barre vie mana endurance
            spriteBatch.Draw(ressource.pixel, barre_vie, Color.Red);
            spriteBatch.Draw(ressource.pixel, barre_endurance, Color.DarkGreen);
            spriteBatch.Draw(ressource.pixel, barre_mana, Color.DarkBlue);

            //dessine l'experience
            spriteBatch.Draw(ressource.pixel, barre_experience, Color.Yellow);

            //dessine le level iup
            spriteBatch.DrawString(ressource.ecriture, Convert.ToString(localPlayer.Niveau),
                new Vector2(Main.Fenetre.Width - 30, Main.Fenetre.Height - 30),
                Color.White);

            //dessine les contour des barres
            spriteBatch.Draw(ressource.barre, barre_v, Color.White);
            spriteBatch.Draw(ressource.barre, barre_e, Color.White);
            spriteBatch.Draw(ressource.barre, barre_m, Color.White);
            spriteBatch.Draw(ressource.barre_xp, barre_xp, Color.White);

            //dessine les sorts
            spriteBatch.Draw(ressource.boule_de_feu,
                new Rectangle((2 * Main.Fenetre.Width / 6) - 20 - ressource.selection_sort.Width, Main.Fenetre.Height - 65, 40, 40),
                Color.White);
            spriteBatch.Draw(ressource.glace,
                new Rectangle((2 * Main.Fenetre.Width / 6) + 20 - ressource.selection_sort.Width, Main.Fenetre.Height - 65, 40, 40),
                Color.White);

            for (int i = 0; i < 5; i++)
            {
                if (Main.player.inventaire[i,0] != null)
                    Main.player.inventaire[i,0].draw(spriteBatch, 2 * Main.Fenetre.Width / 6 + 40 * i + 100, Main.Fenetre.Height - 65,40,40);
            }

            //dessine les fenetre des sort 
            for (int i = 0; i < 4; i++)
            {
                if (localPlayer.Sort_selec == i + 1)
                    spriteBatch.Draw(ressource.selection_sort,
                        new Rectangle((2 * Main.Fenetre.Width / 6) + 40 * i - 20 - ressource.selection_sort.Width, Main.Fenetre.Height - 65, 40, 40),
                            Color.Red);
                else
                    spriteBatch.Draw(ressource.selection_sort,
                    new Rectangle((2 * Main.Fenetre.Width / 6) + 40 * i - 20 - ressource.selection_sort.Width, Main.Fenetre.Height - 65, 40, 40), Color.White);
            }
            for (int i = 0; i < 5; i++)
            {
                if (localPlayer.obj_selec == i + 1)
                    spriteBatch.Draw(ressource.selection_sort,
                        new Rectangle((2 * Main.Fenetre.Width / 6) + 40 * i + 100, Main.Fenetre.Height - 65, 40, 40),
                        Color.Red);
                else
                    spriteBatch.Draw(
                      ressource.selection_sort,
                    new Rectangle((Main.Fenetre.Width / 3) + 40 * i + 100, Main.Fenetre.Height - 65, 40, 40),
                    Color.White);
            }
            //dessine la mini map 
            mini_map.draw(spriteBatch);
        }
    }
}

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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace Templar
{
    //class qui switch les map qui pour l'instant sont representé
    //par des textures

    class switch_map
    {
        GamePlayer player;
        gamemain main;
        Texture2D[,] liste_map;
        Texture2D active_map;



        int x;
        int y;

        public Texture2D Active_Map
        {
            get { return active_map; }
            set { active_map = value; }
        }

        public switch_map(GamePlayer Player, gamemain Main)
        {
            player = Player;
            main = Main;
            liste_map = new Texture2D[5, 5];
            liste_map[1, 2] = ressource.map_1;
            liste_map[2, 1] = ressource.map_2;
            liste_map[2, 2] = ressource.map_0;
            x = 2;
            y = 2;
            active_map = liste_map[2, 2];
        }


        public void update()
        {

            if (player.Position.X == 0 && liste_map[x - 1, y] != null)
            {
                x--;
                player.Position = new Vector2(main.Fenetre.Width - 10, player.Position.Y);
                main.List_Objet_Map.Clear();
                main.List_Zombie.Clear();
                main.List_Sort.Clear();
                main.List_wall.Clear();
            }

            if (player.Position.Y == 0 && liste_map[x, y - 1] != null)
            {
                y--;
                player.Position = new Vector2(player.Position.X, main.Fenetre.Height - 10);
                main.List_Objet_Map.Clear();
                main.List_Zombie.Clear();
                main.List_Sort.Clear();
                main.List_wall.Clear();
            }

            if (player.Position.X == main.Fenetre.Width - 34 && liste_map[x + 1, y] != null)
            {
                x++;
                player.Position = new Vector2(0 + 10, player.Position.Y);
                main.List_Objet_Map.Clear();
                main.List_Zombie.Clear();
                main.List_Sort.Clear();
                main.List_wall.Clear();
            }

            if (player.Position.Y == main.Fenetre.Height - 61 && liste_map[x, y + 1] != null)
            {
                y++;
                player.Position = new Vector2(player.Position.X, 0 + 10);
                main.List_Objet_Map.Clear();
                main.List_Zombie.Clear();
                main.List_Sort.Clear();
                main.List_wall.Clear();
            }

            active_map = liste_map[x, y];
        }
    }
}

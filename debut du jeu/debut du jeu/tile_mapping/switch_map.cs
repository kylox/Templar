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
        Map[,] listes_map;
        Map active_map;
        public int x { get; set; }
        public int y { get; set; }

        public Map Active_Map
        {
            get { return active_map; }
            set { active_map = value; }
        }
        public Texture2D[,] Liste_map
        {
            get { return liste_map; }
            set { liste_map = value; }
        }
        public Map[,] Listes_map
        {
            get { return listes_map; }
            set { listes_map = value; }
        }

        public switch_map(GamePlayer Player, gamemain Main, Donjon donjon)
        {
            player = Player;
            main = Main;
            listes_map = new Map[5, 5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    listes_map[j, i] = donjon.Map[j, i];

            x = 0;
            y = 0;
            active_map = listes_map[y, x];
        }
        public void update()
        {
            active_map = listes_map[y, x];
            if (player != null)
            {
                if (player.Position.X == 0 && x - 1 >= 0 && listes_map[x - 1, y] != null)
                {
                    x--;
                    player.Position = new Vector2(main.Fenetre.Width - 10, player.Position.Y);
                    main.List_Objet_Map.Clear();
                    main.List_Zombie.Clear();
                    main.List_Sort.Clear();
                    main.List_wall.Clear();
                }
                if (player.Position.Y == 0 && y - 1 >= 0 && listes_map[x, y - 1] != null)
                {
                    y--;
                    player.Position = new Vector2(player.Position.X, main.Fenetre.Height - 10);
                    main.List_Objet_Map.Clear();
                    main.List_Zombie.Clear();
                    main.List_Sort.Clear();
                    main.List_wall.Clear();
                }
                if (player.Position.X == main.Fenetre.Width - 34 && listes_map[x + 1, y] != null)
                {
                    x++;
                    player.Position = new Vector2(0 + 10, player.Position.Y);
                    main.List_Objet_Map.Clear();
                    main.List_Zombie.Clear();
                    main.List_Sort.Clear();
                    main.List_wall.Clear();
                }
                if (player.Position.Y == main.Fenetre.Height - 61 && listes_map[x, y + 1] != null)
                {
                    y++;
                    player.Position = new Vector2(player.Position.X, 0 + 10);
                    main.List_Objet_Map.Clear();
                    main.List_Zombie.Clear();
                    main.List_Sort.Clear();
                    main.List_wall.Clear();
                }

            }
        }
    }
}

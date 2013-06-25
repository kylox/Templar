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

    public class switch_map
    {
        GamePlayer player;
        gamemain main;
        Texture2D[,] liste_map;
        Map[,] listes_map;
        Map active_map;
        string Directorie;
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

        public switch_map(GamePlayer Player/*, gamemain Main*/, Donjon donjon, string directori)
        {
            player = Player;
            //main = Main;
           Directorie = directori;
            listes_map = new Map[5, 5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    listes_map[i, j] = donjon.Map[i, j];
            x = (int)donjon.map.X;
            y = (int)donjon.map.Y;
            active_map = listes_map[x, y];
           // active_map.mob = donjon.Map[x, y].mob;
           // active_map.load_mob(@"Donjons\" + @Directorie + @"\Map" + active_map.Nb + @"\creature" + @".txt", main);
        }
        public void update(GamePlayer player, gamemain main)
        {
            active_map = listes_map[x, y];
            if (player != null)
            {
                if ((active_map.objet[(int)player.Position.X / 32, (int)player.position_player.Y / 32] == new Vector2(0, 4) ||
                    active_map.objet[(int)player.Position.X / 32, (int)player.position_player.Y / 32] == new Vector2(0, 7))
                    && x - 1 >= 0 && listes_map[x - 1, y] != null)
                {
                    x--;
                    player.Position = new Vector2(25 * 32 - 64, player.Position.Y);
                    main.List_Objet_Map.Clear();
                    main.List_Zombie.Clear();
                    main.List_Sort.Clear();
                    main.List_wall.Clear();
                    active_map = listes_map[x, y];
                    //active_map.load_mob(@"Donjons\" + @Directorie + @"\Map" + active_map.Nb + @"\creature" + @".txt", main);
                    main.List_Zombie = active_map.monstre;
                }
                else
                    if ((active_map.objet[(int)player.Position.X / 32, (int)player.position_player.Y / 32] == new Vector2(1, 7) ||
                active_map.objet[(int)player.Position.X / 32, (int)player.position_player.Y / 32] == new Vector2(0, 6))
                && y - 1 >= 0 && listes_map[x, y - 1] != null)
                    {
                        y--;
                        player.Position = new Vector2(player.Position.X, 18 * 32 - 64);
                        main.List_Objet_Map.Clear();
                        main.List_Zombie.Clear();
                        main.List_Sort.Clear();
                        main.List_wall.Clear();
                        active_map = listes_map[x, y];
                        //active_map.load_mob(@"Donjons\" + @Directorie + @"\Map" + active_map.Nb + @"\creature" + @".txt", main);
                        main.List_Zombie = active_map.monstre;
                    }
                    else
                        if ((active_map.objet[(int)player.Position.X / 32, (int)player.position_player.Y / 32] == new Vector2(0, 5) ||
            active_map.objet[(int)player.Position.X / 32, (int)player.position_player.Y / 32] == new Vector2(1, 4))
            && listes_map[x + 1, y] != null)
                        {
                            x++;
                            player.Position = new Vector2(0 + 32, player.Position.Y);
                            if (main.List_Objet_Map != null && main.List_Zombie != null && main.List_Sort != null & main.List_wall != null)
                            {
                                main.List_Objet_Map.Clear();
                                main.List_Zombie.Clear();
                                main.List_Sort.Clear();
                                main.List_wall.Clear();
                            }
                            active_map = listes_map[x, y];
                            //active_map.load_mob(@"Donjons\" + @Directorie + @"\Map" + active_map.Nb + @"\creature" + @".txt", main);
                            main.List_Zombie = active_map.monstre;
                        }
                        else
                            if ((active_map.objet[(int)player.Position.X / 32, (int)player.position_player.Y / 32] == new Vector2(1, 5) ||
        active_map.objet[(int)player.Position.X / 32, (int)player.position_player.Y / 32] == new Vector2(1, 4))
        && listes_map[x, y + 1] != null)
                            {
                                y++;
                                player.Position = new Vector2(player.Position.X, 0 + 32);
                                main.List_Objet_Map.Clear();
                                main.List_Zombie.Clear();
                                main.List_Sort.Clear();
                                main.List_wall.Clear();
                                active_map = listes_map[x, y];
                                //active_map.load_mob(@"Donjons\" + @Directorie + @"\Map" + active_map.Nb + @"\creature" + @".txt", main);
                                main.List_Zombie = active_map.monstre;
                            }

            }
        }
    }
}

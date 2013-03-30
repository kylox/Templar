using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Templar
{
    class Chargement
    {
        switch_map Mapi;
        GamePlayer Player;
        Personnage Position;
        Stream fichier;
        BinaryReader load;
        gamemain Main;

        public Chargement(GamePlayer player, switch_map mapi, Personnage pos, gamemain main)
        {
            this.Mapi = mapi;
            this.Main = main;
            this.Player = player;
            Position = pos;
            fichier = new FileStream(@"save/Save.txt", FileMode.Open, FileAccess.Read);
            load = new BinaryReader(fichier);
        }

        public void load_game()
        {
            load.BaseStream.Seek(0, SeekOrigin.Begin);
            int X = load.ReadInt32();
            int Y = load.ReadInt32();
            Position.chgt_position(X, Y);
            Player.pv_player = load.ReadInt32();
            Player.mana_player = load.ReadInt32();
            Player.end_player = load.ReadInt32();
            Player.Niveau = load.ReadInt32();
            Player.XP = load.ReadInt32();
            Mapi.x = load.ReadInt32();
            Mapi.y = load.ReadInt32();
            Main.List_Zombie.Clear();
            Mapi.update();
            load.Close();
            fichier.Close();
        }

    }
}

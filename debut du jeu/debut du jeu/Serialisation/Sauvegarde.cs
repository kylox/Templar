using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Templar
{
    class Sauvegarde
    {
        switch_map Mapi;
        
        BinaryWriter stream;
        Stream fichier;
        GamePlayer Player;

        public Sauvegarde(switch_map map, GamePlayer player)
        {
            this.Mapi = map;
            this.Player = player;
            fichier = new FileStream(@"save/Save.txt", FileMode.OpenOrCreate,FileAccess.Write);
            stream = new BinaryWriter(fichier);
            
        }

        public void Save()
        {
            stream.Write((int)Player.Position.X);
            stream.Write((int)Player.Position.Y);
            stream.Write(Player.pv_player);
            stream.Write(Player.mana_player);
            stream.Write(Player.end_player);
            stream.Write(Player.Niveau);
            stream.Write(Player.XP);
            stream.Write(Mapi.x);
            stream.Write(Mapi.y);

            fichier.Close();
            stream.Close();
            
        }


    }
}

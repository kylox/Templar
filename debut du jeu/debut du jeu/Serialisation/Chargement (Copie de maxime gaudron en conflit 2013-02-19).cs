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
        Stream fichier;
        BinaryReader load;
        Personnage test;

        public Chargement(GamePlayer player, switch_map mapi)
        {
            this.Mapi = mapi;
            this.Player = player;
            fichier = new FileStream("Save.txt", FileMode.Open, FileAccess.Read);
            load = new BinaryReader(fichier);
            load.Close();
        }

        public void load_game()
        {
        }

    }
}

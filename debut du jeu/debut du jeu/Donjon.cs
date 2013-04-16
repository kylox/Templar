using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Templar
{
    class Donjon
    {
        Map map;
        Map[,] _maps;
        
        string Path;
        public Map[,] Map
        {
            get { return _maps; }
            set { _maps = value; }
        }
        public Donjon(string path)
        {
            int x = 0;
            int y = 0;
            this.Path = path;
            _maps = new Map[5, 5];
            foreach (string dr in System.IO.Directory.GetDirectories(path))
            {
                for (int i = 0; i <= Convert.ToInt32(Convert.ToString(dr[5])); i++)
                {
                    x++;
                    if (x > 4)
                    {
                        x = 0;
                        y++;
                    }
                }
                foreach (string file in System.IO.Directory.GetFiles(dr))
                    if (file[7] == 'M')
                    {
                        _maps[x, y] = new Map();
                        _maps[x, y].load(file);
                    }
            }
        }
        public void Ajout_map(int i, int j, int nb, string path)
        {
            System.IO.Directory.CreateDirectory(@path + @"\Map" + @nb);
            Stream sr = new FileStream(@path + @"\Map" + @nb + @"\Map" + @nb + @".txt", FileMode.Create, FileAccess.ReadWrite);
            sr.Close();
            _maps[i, j] = new Map();
            this.Map[i, j].init(@path + @"\Map" + @nb + @"\Map" + @nb + @".txt");
            this.Map[i, j].isCreate = true;
        }

    }
}

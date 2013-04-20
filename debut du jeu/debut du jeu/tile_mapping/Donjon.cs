using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Templar
{
    class Donjon
    {
        Map[,] _maps;
        public Map[,] Map
        {
            get { return _maps; }
            set { _maps = value; }
        }
        public Donjon(string path, gamemain main)
        {
            int x = 0;
            int y = 0;
            _maps = new Map[5, 5];

            if (main != null)
                foreach (string dr in System.IO.Directory.GetDirectories(path))
                {
                    for (int i = 0; i < Convert.ToInt32(Convert.ToString(dr[5])) * 10 + Convert.ToInt32(Convert.ToString(dr[6])); i++)
                    {
                        x++;
                        if (x > 4)
                        {
                            x = 0;
                            y++;
                        }
                    }
                    foreach (string file in System.IO.Directory.GetFiles(dr))
                    {
                        if (file[8] == 'M')
                        {
                            if (_maps[x, y] == null)
                                _maps[x, y] = new Map();
                            _maps[x, y].load(file);
                        }
                        if (file[8] == 'c')
                        {
                            if (_maps[x, y] == null)
                                _maps[x, y] = new Map();
                            _maps[x, y].load_collision(file);
                        }
                        x = 0;
                        y = 0;
                    }
                }
        }
        public void Ajout_map(int i, int j, int nb, string path)
        {
            string nombre;
            if (nb < 10)
                nombre = "0" + Convert.ToString(nb);
            else
                nombre = Convert.ToString(nb);
            System.IO.Directory.CreateDirectory(@path + @"\Map" + @nombre);
            Stream sr = new FileStream(@path + @"\Map" + @nombre + @"\Map" + @nombre + @".txt", FileMode.Create, FileAccess.ReadWrite);
            sr.Close();
            _maps[i, j] = new Map();
            this.Map[i, j].init(@path + @"\Map" + @nombre + @"\Map" + @nombre + @".txt");
            this.Map[i, j].isCreate = true;
        }

    }
}

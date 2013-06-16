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
        public Donjon(string path, bool edm)
        {
            int x = 0;
            int y = 0;
            _maps = new Map[5, 5];

            if (edm == false)
                foreach (string dr in System.IO.Directory.GetDirectories(path))
                {
                    for (int i = 0; i < Convert.ToInt32(Convert.ToString(dr[dr.Length - 2])) * 10 + Convert.ToInt32(Convert.ToString(dr[dr.Length - 1])); i++)
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
                        if (file[file.Length - 9] == 'M')
                        {
                            if (_maps[x, y] == null)
                                _maps[x, y] = new Map();
                            _maps[x, y].load_objet(file);
                            x = 0;
                            y = 0;
                        }
                        else
                            if (file[file.Length - 10] == 'f')
                            {
                                if (_maps[x, y] == null)
                                    _maps[x, y] = new Map();
                                _maps[x, y].load(file);
                            }
                            else
                                if (file[file.Length - 15] == 'c')
                                {
                                    if (_maps[x, y] == null)
                                        _maps[x, y] = new Map();
                                    _maps[x, y].load_collision(file);
                                }
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
            System.IO.Directory.CreateDirectory(@"Donjons\" + @path + @"\Map" + @nombre);
            Stream sr1 = new FileStream(@"Donjons\" + @path + @"\Map" + @nombre + @"\Map" + @nombre + @".txt", FileMode.Create, FileAccess.ReadWrite);
            sr1.Close();
            Stream sr2 = new FileStream(@"Donjons\" + @path + @"\Map" + @nombre + @"\fond" + @nombre + @".txt", FileMode.Create, FileAccess.ReadWrite);
            sr2.Close();
            Stream sr3 = new FileStream(@"Donjons\" + @path + @"\Map" + @nombre + @"\collision" + @nombre + @".txt", FileMode.Create, FileAccess.ReadWrite);
            sr3.Close();
            Stream sr4 = new FileStream(@"Donjons\" + @path + @"\Map" + @nombre + @"\message" + @nombre + @".txt", FileMode.Create, FileAccess.ReadWrite);
            _maps[i, j] = new Map();
            this.Map[i, j].init(@"Donjons\" + @path + @"\Map" + @nombre + @"\fond" + @nombre + @".txt");
            this.Map[i, j].init_objet(@"Donjons\" + @path + @"\Map" + @nombre + @"\Map" + @nombre + @".txt");
            this.Map[i, j].init_coll(@"Donjons\" + @path + @"\Map" + @nombre + @"\collision" + @nombre + @".txt");
            this.Map[i, j].isCreate = true;
        }

    }
}

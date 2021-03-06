﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
    public class Donjon
    {
        //position de la premiere map
        public Vector2 map;
        //position du joueur dans la premiere map 
        public Vector2 position_J;
        public string name;
        Map[,] _maps;
        public Map[,] Map
        {
            get { return _maps; }
            set { _maps = value; }
        }
        public void load_position(string Path)
        {
             StreamReader sr = new StreamReader(Path);
            string ligne = sr.ReadLine();
            string[] pos = ligne.Split(' ');
            position_J.X = Convert.ToInt32(pos[0]);
            position_J.Y = Convert.ToInt32(pos[1]);
            ligne = sr.ReadLine();
            pos = ligne.Split(' ');
            map.X = Convert.ToInt32(pos[0]);
            map.Y = Convert.ToInt32(pos[1]);
            sr.Close();
        }
        public void load_coffre(string path, string dr, Map map)
        {
            int nb = 0;
            StreamReader sr = new StreamReader(path);
            for (int j = 0; j < 18; j++)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (sr.Read() == '1')
                    {
                        map.Coffres[i, j] = new Coffre(new Vector2(i * 32, j * 32));
                        if (nb < 10)
                            load_objet(@dr + @"\Box" + @"0" + @nb + @".txt", map.Coffres[i, j]);
                        else
                            load_objet(@dr + @"\Box" + @nb + @".txt", map.Coffres[i, j]);
                        nb++;
                    }
                }
                sr.ReadLine();
            }

            sr.Close();
        }
        public void load_objet(string path, Coffre coffre)
        {
            StreamReader sr = new StreamReader(path);
            int j = 0;
            string ligne = "";
            while ((ligne = sr.ReadLine()) != null)
            {
                for (int i = 0; i < ligne.Length; i++)
                {
                    if (ligne[i] != cursor.vec_to_id(new Vector2(15, 15)))
                        coffre.tab[i, j] = new Items(cursor.id_to_vec(Convert.ToChar(ligne[i])), cursor.langue);
                }
                j++;
            }
        }

        public Donjon()
        {
            _maps = new Map[5, 5];
        }
        public Donjon(string path, bool edm)
        {
            name = path;
            int x = 0;
            int y = 0;
            _maps = new Map[5, 5];
            if (edm == false)
            {
                load_position(path + @"\autre" + @".txt");
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
                        if (file[file.Length - 7] == 'b')//1
                        {
                            if (_maps[x, y] == null)
                                _maps[x, y] = new Map();
                            load_coffre(file, @dr + @"\Boxes", _maps[x, y]);
                        }
                        else
                            if (file[file.Length - 9] == 'M')//4
                            {
                                if (_maps[x, y] == null)
                                    _maps[x, y] = new Map();
                                _maps[x, y].Nb = Convert.ToString(file[file.Length - 6]) + Convert.ToString(file[file.Length - 5]);

                                _maps[x, y].load_objet(file);// bug ?oO
                            }
                            else
                                if (file[file.Length - 10] == 'f')//3
                                {
                                    if (_maps[x, y] == null)
                                        _maps[x, y] = new Map();
                                    _maps[x, y].load(file);
                                }
                                else
                                    if (file[file.Length - 13] == 'm')//5
                                    {
                                        if (_maps[x, y] == null)
                                            _maps[x, y] = new Map();
                                        _maps[x, y].load_message(file);
                                        x = 0;
                                        y = 0;
                                    }
                                    else
                                        if (file[file.Length - 15] == 'c')//2
                                        {
                                            if (_maps[x, y] == null)
                                                _maps[x, y] = new Map();
                                            _maps[x, y].load_collision(file);
                                        }
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
            System.IO.Directory.CreateDirectory(@"Donjons\" + @path + @"\Map" + @nombre + @"\Boxes");
            Stream sr1 = new FileStream(@"Donjons\" + @path + @"\Map" + @nombre + @"\Map" + @nombre + @".txt", FileMode.Create, FileAccess.ReadWrite);
            sr1.Close();
            Stream sr2 = new FileStream(@"Donjons\" + @path + @"\Map" + @nombre + @"\fond" + @nombre + @".txt", FileMode.Create, FileAccess.ReadWrite);
            sr2.Close();
            Stream sr3 = new FileStream(@"Donjons\" + @path + @"\Map" + @nombre + @"\collision" + @nombre + @".txt", FileMode.Create, FileAccess.ReadWrite);
            sr3.Close();
            Stream sr4 = new FileStream(@"Donjons\" + @path + @"\Map" + @nombre + @"\message" + @nombre + @".txt", FileMode.Create, FileAccess.ReadWrite);
            sr4.Close();
            _maps[i, j] = new Map();
            this.Map[i, j].init(@"Donjons\" + @path + @"\Map" + @nombre + @"\fond" + @nombre + @".txt");
            this.Map[i, j].init_objet(@"Donjons\" + @path + @"\Map" + @nombre + @"\Map" + @nombre + @".txt");
            this.Map[i, j].init_coll(@"Donjons\" + @path + @"\Map" + @nombre + @"\collision" + @nombre + @".txt");
            this.Map[i, j].init_mob(@"Donjons\" + @path + @"\Map" + @nombre + @"\creature" + @".txt");
            this.Map[i, j].init_box(@"Donjons\" + @path + @"\Map" + @nombre + @"\box" + @".txt");
            this.Map[i, j].isCreate = true;
        }

    }
}

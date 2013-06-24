using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Templar
{
    [Serializable()]
    public class Map
    {
        #region variable
        KeyboardState keyboardState;
        KeyboardState lastKeyboardState;
        public List<NPC> monstre;
        public Vector2[,] tiles;
        public Vector2[,] objet;
        public Coffre[,] Coffres;
        public Coffre prev_coffre;
        public Coffre active_coffre;
        Tile[,] tilelist;
        public int[,] colision;
        public Vector2[,] mob;
        bool iscreate;
        string message;
        bool visited;
        public bool isfirst;
        public string Nb;
        # endregion
        #region fields
        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public bool isCreate
        {
            get { return iscreate; }
            set { iscreate = value; }
        }
        public Tile[,] Tilelist
        {
            get { return tilelist; }
            set { tilelist = value; }
        }
        public Vector2[,] Tiles
        {
            get { return tiles; }
        }
        #endregion
        public Map()
        {
            monstre = new List<NPC>();
            prev_coffre = new Coffre(new Vector2(0, 0));
            tiles = new Vector2[25, 18];
            objet = new Vector2[25, 18];
            Coffres = new Coffre[25, 18];
            for (int i = 0; i < objet.GetLength(0); i++)
                for (int j = 0; j < objet.GetLength(1); j++)
                    objet[i, j] = new Vector2(15, 15);
            tilelist = new Tile[25, 18];
            colision = new int[25, 18];
            mob = new Vector2[25, 18];
            iscreate = false;
            visited = false;
            message = "";
            isfirst = false;
        }
        //initialise le fond de la map (les tiles)
        public void init(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    tiles[i, j] = new Vector2(2, 0);
                    sw.Write(cursor.vec_to_id(tiles[i, j]));
                }
                sw.WriteLine();
            }
            sw.Close();
        }
        //initialise les colision
        public void init_coll(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int j = 0; j < 18; j++)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (i == 0)
                        colision[i, j] = 1;
                    else
                        if (j == 0)
                            colision[i, j] = 1;
                        else
                            if (j == 17)
                                colision[i, j] = 1;
                            else
                                if (i == 24)
                                    colision[i, j] = 1;
                                else
                                    colision[i, j] = 0;
                    sw.Write(colision[i, j]);
                }
                sw.WriteLine();
            }
            sw.Close();
        }
        //initialise les objet avec les murs qui vont bien
        public void init_objet(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int j = 0; j < objet.GetLength(1); j++)
            {
                for (int i = 0; i < objet.GetLength(0); i++)
                {
                    if (j == 0)
                        if (i == 0)
                            objet[i, j] = new Vector2(2, 4);
                        else
                            if (i == tiles.GetLength(0) - 1)
                                objet[i, j] = new Vector2(5, 4);
                            else
                                objet[i, j] = new Vector2(3, 4);
                    else if (j == tiles.GetLength(1) - 1)
                        if (i == 0)
                            objet[i, j] = new Vector2(2, 7);
                        else
                            if (i == tiles.GetLength(0) - 1)
                                objet[i, j] = new Vector2(5, 7);
                            else
                                objet[i, j] = new Vector2(3, 7);
                    else if (i == tiles.GetLength(0) - 1 && j != tiles.GetLength(1) - 1 && j != 0)
                        objet[i, j] = new Vector2(5, 5);
                    else
                        if (i == 0 && j != tiles.GetLength(1) - 1 && j != 0)
                            objet[i, j] = new Vector2(2, 5);
                        else
                            objet[i, j] = new Vector2(15, 15);

                    sw.Write(cursor.vec_to_id(objet[i, j]));
                }
                sw.WriteLine();
            }
            sw.Close();
        }
        public void init_mob(string path)
        {
            StreamWriter sw = new StreamWriter(path);

            for (int j = 0; j < 18; j++)
            {
                for (int i = 0; i < 25; i++)
                {
                    mob[i, j] = new Vector2(15, 15);
                    sw.Write(cursor.vec_to_id(mob[i, j]));
                }
                sw.WriteLine();
            }
            sw.Close();
        }
        public void init_box(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 25; j++)
                    sw.Write(0);
                sw.WriteLine();
            }
            sw.Close();
        }
        //ecrit les colision des objet
        public void ecrire_coll(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int j = 0; j < colision.GetLength(1); j++)
            {
                for (int i = 0; i < colision.GetLength(0); i++)
                {
                    sw.Write(colision[i, j]);
                }
                sw.WriteLine();
            }
            sw.Close();
        }
        public void ecrire_box(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int j = 0; j < 18; j++)
            {
                for (int i = 0; i < 25; i++)
                    if (Coffres[i, j] == null)
                        sw.Write(0);
                    else
                        sw.Write(1);
                sw.WriteLine();
            }
            sw.Close();
        }
        //ecrit le objet
        public void ecrire_objet(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                    if (objet[i, j] != new Vector2(15, 15))
                        sw.Write(cursor.vec_to_id(objet[i, j]));
                    else
                        sw.Write(cursor.vec_to_id(new Vector2(15, 15)));
                sw.WriteLine();
            }
            sw.Close();
        }
        public void ecrire_mob(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int j = 0; j < 18; j++)
            {
                for (int i = 0; i < 25; i++)
                    sw.Write(cursor.vec_to_id(mob[i, j]));
                sw.WriteLine();
            }
            sw.Close();
        }
        public void ecrire_message(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write(message);
            sw.Close();
        }
        //charge la map
        public void load(string path)
        {
            try
            {
                int j = 0;
                StreamReader sr = new StreamReader(path);
                string ligne;
                while ((ligne = sr.ReadLine()) != null)
                {
                    for (int i = 0; i < tiles.GetLength(0); i++)
                        tiles[i, j] = (cursor.id_to_vec(ligne[i]));
                    j += 1;
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("erreur : " + e.Message);
            }
        }
        //charge les objet de la map
        public void load_objet(string path)
        {
            try
            {
                int j = 0;
                StreamReader sr = new StreamReader(path);
                string ligne;
                while ((ligne = sr.ReadLine()) != null)
                {
                    for (int i = 0; i < tiles.GetLength(0); i++)
                    {
                        if (ligne[i] != cursor.vec_to_id(new Vector2(15, 15)))
                        {
                            objet[i, j] = (cursor.id_to_vec(ligne[i]));
                        }
                    }
                    j += 1;
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("erreur : " + e.Message);
            }
        }
        public void load_collision(string path)
        {
            int j = 0;
            StreamReader sr = new StreamReader(path);
            string ligne;
            while ((ligne = sr.ReadLine()) != null)
            {
                for (int i = 0; i < colision.GetLength(0); i++)
                {
                    tilelist[i, j] = new Tile(i, j, Convert.ToInt32(ligne[i]));
                    colision[i, j] = Convert.ToInt32(Convert.ToString(ligne[i]));
                }
                j += 1;
            }
            sr.Close();
        }
        public void load_message(string path)
        {
            StreamReader sr = new StreamReader(path);
            message = sr.ReadToEnd();
            sr.Close();
        }
        public void load_mob(StreamReader sr,gamemain main)
        {
             int j = 0;
            string ligne;
            while ((ligne = sr.ReadLine()) != null)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    if (ligne[i] != cursor.vec_to_id(new Vector2(15, 15)))
                    {
                        switch ((int)cursor.id_to_vec(ligne[i]).X)
                        {
                            case 0:
                                monstre.Add(new NPC(32, 48, 4, 3, 1, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 1:
                                monstre.Add(new NPC(32, 48, 4, 3, 4, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 2:
                                monstre.Add(new NPC(32, 48, 4, 3, 7, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 3:
                                monstre.Add(new NPC(32, 48, 4, 3, 10, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 5:
                                monstre.Add(new NPC(32, 48, 4, 3, 13, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 6:
                                monstre.Add(new NPC(32, 48, 4, 3, 16, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 7:
                                monstre.Add(new NPC(32, 48, 4, 3, 19, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 8:
                                monstre.Add(new NPC(32, 48, 4, 3, 22, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 9:
                                monstre.Add(new NPC(32, 48, 4, 3, 25, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 10:
                                monstre.Add(new NPC(32, 48, 4, 3, 28, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 11:
                                monstre.Add(new NPC(32, 48, 4, 3, 31, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 12:
                                monstre.Add(new NPC(32, 48, 4, 3, 34, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 13:
                                monstre.Add(new NPC(32, 48, 4, 3, 37, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 14:
                                monstre.Add(new NPC(32, 48, 4, 3, 40, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                        }
                    }
                }
                j += 1;
            }
            sr.Close();

        }
        public void load_mob(string path, gamemain main)
        {
            int j = 0;
            StreamReader sr = new StreamReader(path);
            string ligne;
            while ((ligne = sr.ReadLine()) != null)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    if (ligne[i] != cursor.vec_to_id(new Vector2(15, 15)))
                    {
                        switch ((int)cursor.id_to_vec(ligne[i]).X)
                        {
                            case 0:
                                monstre.Add(new NPC(32, 48, 4, 3, 1, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 1:
                                monstre.Add(new NPC(32, 48, 4, 3, 4, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 2:
                                monstre.Add(new NPC(32, 48, 4, 3, 7, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 3:
                                monstre.Add(new NPC(32, 48, 4, 3, 10, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 5:
                                monstre.Add(new NPC(32, 48, 4, 3, 16, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 6:
                                monstre.Add(new NPC(32, 48, 4, 3, 19, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 7:
                                monstre.Add(new NPC(32, 48, 4, 3, 22, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 8:
                                monstre.Add(new NPC(32, 48, 4, 3, 25, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 9:
                                monstre.Add(new NPC(32, 48, 4, 3, 28, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 10:
                                monstre.Add(new NPC(32, 48, 4, 3, 31, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 11:
                                monstre.Add(new NPC(32, 48, 4, 3, 34, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 12:
                                monstre.Add(new NPC(32, 48, 4, 3, 37, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 13:
                                monstre.Add(new NPC(32, 48, 4, 3, 40, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                            case 14:
                                monstre.Add(new NPC(32, 48, 4, 3, 43, 15, 2, new Vector2(i * 32, j * 32), ressource.mob, main.player, this));
                                break;
                        }
                    }
                }
                j += 1;
            }
            sr.Close();

        }
        public void Update(GameTime gametime, string path, string path_coll, string path_message, string path_mob, string path_box, string path_coffre, textbox text)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            if (Data.mouseState.RightButton == ButtonState.Pressed &&
                Data.prevMouseState.RightButton == ButtonState.Released &&
                new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(0, 0, 16 * 25, 16 * 18))
                && text.Is_shown == false)
            {
                if (Coffres[Data.mouseState.X / 16, Data.mouseState.Y / 16] != null)
                {
                    cursor.position = false;
                    cursor.selected = false;
                    cursor.selec_obj = false;
                    if (active_coffre != null)
                        active_coffre.is_open = false;
                    prev_coffre = active_coffre;
                    cursor.selec_obj = false;
                    cursor.selected_mob = false;
                    Coffres[Data.mouseState.X / 16, Data.mouseState.Y / 16].is_open = true;
                    active_coffre = Coffres[Data.mouseState.X / 16, Data.mouseState.Y / 16];
                }
            }
            if (Data.mouseState.LeftButton == ButtonState.Pressed &&
                Data.prevMouseState.LeftButton == ButtonState.Released &&
                !new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(100, 100, 32 * 5, 32 * 5))
                && !new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(27 * 16, 48, 32 * 7, 32 * 7))
                && text.Is_shown == false && cursor.position == false && active_coffre != null && active_coffre.is_open == true)
            {
                active_coffre.is_open = false;
            }
            else
                if (Data.mouseState.LeftButton == ButtonState.Pressed &&
                    Data.prevMouseState.LeftButton == ButtonState.Released &&
                    new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(0, 0, 16 * 25, 16 * 18))
                    && text.Is_shown == false && cursor.position == false && cursor.selected == true)
                {
                    objet[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = cursor.iD;
                    if (cursor.iD != new Vector2(0, 2) && cursor.iD != new Vector2(1, 2) &&
                        cursor.iD != new Vector2(0, 4) && cursor.iD != new Vector2(0, 7) &&
                        cursor.iD != new Vector2(0, 5) && cursor.iD != new Vector2(1, 4) &&
                        cursor.iD != new Vector2(0, 6) && cursor.iD != new Vector2(1, 7) &&
                        cursor.iD != new Vector2(1, 6) && cursor.iD != new Vector2(1, 5) &&
                        cursor.iD != new Vector2(1, 0) && cursor.iD != new Vector2(1, 4) &&
                        cursor.iD != new Vector2(2, 0))
                    {
                        // tilelist[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = new Tile((int)cursor.iD.X, (int)cursor.iD.Y, 1);
                        colision[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = 1;
                        if (cursor.iD == new Vector2(0, 0))
                        {
                            Coffres[Data.mouseState.X / 16, Data.mouseState.Y / 16] = new Coffre(new Vector2(Data.mouseState.X - Data.mouseState.X % 32, Data.mouseState.Y - Data.mouseState.Y % 32));
                            cursor.ecrire_coffre(path_coffre, this);
                        }
                    }
                    else
                    {
                        // tilelist[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = new Tile((int)cursor.iD.X, (int)cursor.iD.Y, 0);
                        colision[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = 0;
                    }
                    cursor.ecrire_coffre(path_coffre, this);
                    ecrire_objet(path);
                    ecrire_coll(path_coll);
                    ecrire_message(path_message);
                    ecrire_box(path_box);
                }
                else
                    if (Data.mouseState.LeftButton == ButtonState.Pressed &&
                       Data.prevMouseState.LeftButton == ButtonState.Released &&
                       new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(0, 0, 16 * 25, 16 * 18))
                       && text.Is_shown == false && cursor.position == false && cursor.selected_mob == true)
                    {
                        mob[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = cursor.iD;
                        ecrire_mob(path_mob);
                    }
        }
        public void Draw(SpriteBatch spriteBatch, int x)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
                for (int i = 0; i < tiles.GetLength(0); i++)
                    spriteBatch.Draw(ressource.tile, new Rectangle(i * x, j * x, x, x), Tile.tile(tiles[i, j]), Color.White);
            for (int j = 0; j < tiles.GetLength(1); j++)
                for (int i = 0; i < tiles.GetLength(0); i++)
                    if (objet[i, j] != new Vector2(15, 15))
                        spriteBatch.Draw(ressource.objet_map, new Rectangle(i * x, j * x, x, x), Tile.tile(objet[i, j]), Color.White);

            for (int i = 0; i < 25; i++)
                for (int j = 0; j < 18; j++)
                    if (Coffres[i, j] != null)
                    {
                        Coffres[i, j].Draw(spriteBatch, i * x + x, j * x + x);
                        spriteBatch.Draw(ressource.pixel, new Rectangle(i * x, j * x, x, x), Color.FromNonPremultiplied(250, 250, 250, 100));
                    }
        }
        public bool ValidCoordinate(int x, int y)
        {
            if (x < 0 || y < 0 || x >= tilelist.GetLength(0) || y >= tilelist.GetLength(1))
                return false;
            else
                return true;
        }
    }
}
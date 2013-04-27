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
    public class Map
    {
        #region variable
        KeyboardState keyboardState;
        KeyboardState lastKeyboardState;
        Vector2[,] tiles;
        public Vector2[,] objet;
        Tile[,] tilelist;
        public int[,] colision;
        bool iscreate;
        # endregion
        #region fields
        public bool isCreate
        {
            get { return iscreate; }
            set { iscreate = value; }
        }
        public Tile[,] Tilelist
        {
            get { return tilelist; }
        }
        public Vector2[,] Tiles
        {
            get { return tiles; }
        }
        #endregion
        public Map()
        {
            tiles = new Vector2[25, 18];
            objet = new Vector2[25, 18];
            for (int i = 0; i < objet.GetLength(0); i++)
            {
                for (int j = 0; j < objet.GetLength(1); j++)
                {
                    objet[i, j] = new Vector2(15, 15);
                }
            }
            tilelist = new Tile[25, 18];
            colision = new int[25, 18];
            iscreate = false;
        }
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
                                tiles[i, j] = new Vector2(3, 4);
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
        public void ecrire_objet(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    if (objet[i, j] != new Vector2(15, 15))
                        sw.Write(cursor.vec_to_id(objet[i, j]));
                    else
                        sw.Write(cursor.vec_to_id(new Vector2(15, 15)));
                }
                sw.WriteLine();
            }
            sw.Close();
        }

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
                    {
                        tiles[i, j] = (cursor.id_to_vec(ligne[i]));
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
                            objet[i, j] = (cursor.id_to_vec(ligne[i]));
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
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    tilelist[i, j] = new Tile(i, j, Convert.ToInt32(ligne[i]));
                    colision[i, j] = Convert.ToInt32(Convert.ToString(ligne[i]));
                }

                j += 1;
            }
            sr.Close();
        }
        public void Update(GameTime gametime, string path, string path_coll, textbox text)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            if (Data.mouseState.LeftButton == ButtonState.Pressed && Data.prevMouseState.LeftButton == ButtonState.Released &&
                new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(0, 0, 16 * 32, 16 * 32))
                && text.Is_shown == false)
            {
        
                objet[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = cursor.iD;

                if (cursor.iD != new Vector2(0, 2) && cursor.iD != new Vector2(0, 3) &&
                    cursor.iD != new Vector2(0, 4) && cursor.iD != new Vector2(0, 7) &&
                    cursor.iD != new Vector2(0, 5) && cursor.iD != new Vector2(1, 4) && cursor.iD != new Vector2(0, 6) &&
                    cursor.iD != new Vector2(1, 7) && cursor.iD != new Vector2(1, 6) && cursor.iD != new Vector2(1, 5))
                {
                    tilelist[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = new Tile((int)cursor.iD.X, (int)cursor.iD.Y, 1);
                    colision[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = 1;
                }
                else
                {
                    tilelist[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = new Tile((int)cursor.iD.X, (int)cursor.iD.Y, 0);
                    colision[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = 0;
                }
                ecrire_objet(path);
                ecrire_coll(path_coll);
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

        }
        public bool ValidCoordinate(int x, int y)
        {
            if (x < 0 || y < 0 || x >= tilelist.GetLength(0) || y >= tilelist.GetLength(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
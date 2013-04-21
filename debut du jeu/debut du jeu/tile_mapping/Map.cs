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
                    if (j == 0)
                        if (i == 0)
                            tiles[i, j] = new Vector2(0, 1);
                        else
                            if (i == tiles.GetLength(0) - 1)
                                tiles[i, j] = new Vector2(2, 1);
                            else
                                tiles[i, j] = new Vector2(1, 1);
                    else if (j == tiles.GetLength(1) - 1)
                        if (i == 0)
                            tiles[i, j] = new Vector2(0, 3);
                        else
                            if (i == tiles.GetLength(0) - 1)
                                tiles[i, j] = new Vector2(2, 3);
                            else
                                tiles[i, j] = new Vector2(1, 3);
                    else if (i == tiles.GetLength(0) - 1 && j != tiles.GetLength(1) - 1 && j != 0)
                        tiles[i, j] = new Vector2(2, 2);
                    else
                        if (i == 0 && j != tiles.GetLength(1) - 1 && j != 0)
                            tiles[i, j] = new Vector2(0, 2);

                        else
                            tiles[i, j] = new Vector2(1, 2);
                    sw.Write(cursor.vec_to_id(tiles[i, j]));
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
        public void ecrire(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    sw.Write(cursor.vec_to_id(tiles[i, j]));
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
                tiles[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = cursor.iD;

                if (cursor.iD != new Vector2(0, 1) && cursor.iD != new Vector2(2, 3))
                {
                    tilelist[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = new Tile((int)cursor.iD.X, (int)cursor.iD.Y, 1);
                    colision[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = 1;
                }
                else
                {
                    tilelist[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = new Tile((int)cursor.iD.X, (int)cursor.iD.Y, 0);
                    colision[(int)(Data.mouseState.X) / 16, (int)(Data.mouseState.Y) / 16] = 0;
                }
                ecrire(path);
                ecrire_coll(path_coll);
            }
        }
        public void Draw(SpriteBatch spriteBatch, int x)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
                for (int i = 0; i < tiles.GetLength(0); i++)
                    spriteBatch.Draw(ressource.tile, new Rectangle(i * x, j * x, x, x), Tile.tile(tiles[i, j]), Color.White);
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
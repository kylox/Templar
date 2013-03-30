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
    class Map
    {
        KeyboardState keyboardState;

        KeyboardState lastKeyboardState;
        //va sotcker les ID des tiles-
        int[,] tiles;
        Tile[,] tilelist;
        public Tile[,] Tilelist
        {
            get { return tilelist; }
        }
        Cursor cursor = new Cursor();
        KeyboardState keyboard;

        public int[,] Tiles
        {
            get { return tiles; }
        }

        public Map(string path)
        {
            tiles = new int[25, 19];
            tilelist = new Tile[25, 19];
            init();
            keyboard = new KeyboardState();
        }

        public void init()
        {
            StreamWriter sw = new StreamWriter("map_1.txt");

            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    tiles[i, j] = 1;
                    sw.Write(tiles[i,j]);
                    tilelist[i, j] = new Tile(i, j, tiles[i, j]);
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
                    sw.Write(tiles[i, j]);
                }
                sw.WriteLine();
            }
            sw.Close();
        }

        public void load(string path)
        {
            int j = 0;
            //instanci un nouveau lecteur
            StreamReader sr = new StreamReader(path);
            string ligne;

            //lis les lignes et stocke chaque caractere de la ligne dans la matrice 
            while ((ligne = sr.ReadLine()) != null)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    tiles[i, j] = (ligne[i] - 48);
                    tilelist[i, j] = new Tile(i, j, tiles[i, j]);
                }

                j += 1;
            }
            sr.Close();
        }

        public void Update(GameTime gametime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            cursor.Update(gametime, new Vector2(800, 1200));

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                tiles[(int)cursor.Position.X / 32, (int)cursor.Position.Y / 32] = cursor.iD;
                ecrire("map_1.txt");
                
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                spriteBatch.Draw(cursor._texture, cursor.Position, Color.White);
            }

            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    spriteBatch.Draw(ressource.tile, new Vector2(i * 32, j * 32), Tile.tile(tiles[i, j]), Color.White);
                }
            }
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
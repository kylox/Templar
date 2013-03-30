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

        Vector2[,] tiles;

        Tile[,] tilelist;

        public Tile[,] Tilelist
        {
            get { return tilelist; }
        }
        
        //initialise un nouveau curseur sur la map 
        Cursor cursor = new Cursor();

        //matrice de stockage des tile
        public Vector2[,] Tiles
        {
            get { return tiles; }
        }

        public Map(string path)
        {
            tiles = new Vector2[25, 19];
            tilelist = new Tile[25, 19];
            init(path); 
        }

        #region method
        //initialise la map
        public void init(string path)
        {
            StreamWriter sw = new StreamWriter(path);

            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    tiles[i, j] = new Vector2(1, 0);
                    tilelist[i, j] = new Tile(i, j, 1);//penser a modifier ca voir avec louis comment faire
                    sw.Write("1");
                }
                sw.WriteLine();
            }
            sw.Close();
        }

        //ecrit dans le fichier .txt les nouveau tile
        public void ecrire(string path)
        {
            StreamReader sr = new StreamReader(path);

            for (int i = 0; i < cursor.Position.Y; i++)
            {
                for (int j = 0; j < cursor.Position.X; j++)
                {
                    sr.Read();
                }
            }

            sr.Close();
            StreamWriter sw = new StreamWriter(path);
            sw.Write(cursor.iD);
            sw.Close();
        }

        /* public void load(string path)
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
         */

        #endregion

        public void Update(GameTime gametime, string path,Cursor cursor)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            
            
            //cursor.Update(gametime, new Vector2(800, 1200));

            //ajoute dans la tiles vector2 les ID du cursor en fonction de sa position et ecrit l'id du tile dans le path
            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                tiles[(int)cursor.Position.X / 32, (int)cursor.Position.Y / 32] = cursor.iD;
                //ecrire(path);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //dessine la matrice a l'ecaran
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    spriteBatch.Draw(ressource.tile, new Vector2(i * 32, j * 32),Tile.tile(tiles[i,j]),
                       Color.White);
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
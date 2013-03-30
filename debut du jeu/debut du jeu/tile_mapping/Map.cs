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
        #region variable
        KeyboardState keyboardState;
        KeyboardState lastKeyboardState;
        Vector2[,] tiles;
        Tile[,] tilelist;
        # endregion

        #region fields
        //retourne la matrice de tile
        public Tile[,] Tilelist
        {
            get { return tilelist; }
        }

        //matrice de stockage des tile
        public Vector2[,] Tiles
        {
            get { return tiles; }
        }
        #endregion

        public Map(string path)
        {
            tiles = new Vector2[25, 19];
            tilelist = new Tile[25, 19];
        }

        #region methods
        //initialise la map
        public void init(string path)
        {
            StreamWriter sw = new StreamWriter(path);

            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    tiles[i, j] = new Vector2(1,0);
                    tilelist[i, j] = new Tile(i, j, 1);
                    sw.Write(cursor.vec_to_id(tiles[i, j]));
                }
                sw.WriteLine();
            }
            sw.Close();
        }

        //ecrit dans le fichier .txt les nouveau tile
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
                //instanci un nouveau lecteur
                StreamReader sr = new StreamReader(path);

                string ligne;

                //lis les lignes et stocke chaque caractere de la ligne dans la matrice 
                while ((ligne = sr.ReadLine()) != null)
                {
                    for (int i = 0; i < tiles.GetLength(0); i++)
                    {
                        tiles[i, j] = (cursor.id_to_vec(ligne[i]));
                        tilelist[i, j] = new Tile(i, j, 1);
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
       

        #endregion

        #region update & draw
        public void Update(GameTime gametime, string path, textbox text)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();


            if (keyboardState.IsKeyDown(Keys.Enter) && text.Is_shown == false)
            {
                tiles[(int)cursor.Position.X / 32, (int)cursor.Position.Y / 32] = cursor.iD;
                ecrire(path);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    spriteBatch.Draw(ressource.tile, new Vector2(i * 32, j * 32), Tile.tile(tiles[i, j]),
                       Color.White);
                }
            }
        }
        #endregion

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
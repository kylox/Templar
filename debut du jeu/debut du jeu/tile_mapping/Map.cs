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
        //va sotcker les ID des tiles
        int[,] tiles;
        Cursor cursor = new Cursor(ressource.ARBRE);
        KeyboardState keyboard;
        public Map()
        {
            tiles = new int[25, 19];
            int j = 0;
            keyboard = new KeyboardState();
            //instanci un nouveau lecteur
             StreamReader sr = new StreamReader(@"C:\Users\Louis\MAP.txt");
             string ligne;

             //lis les lignes et stocke chaque caractere de la ligne dans la matrice 
             while ((ligne = sr.ReadLine()) != null)
             {
                 for (int i = 0; i < tiles.GetLength(0); i++)
                     tiles[i, j] = (ligne[i] - 48);
                
                 j += 1;
             }
        }
        public void Update(GameTime gametime)
        {
            cursor.Update(gametime, new Vector2(800, 1200));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                spriteBatch.Draw(cursor._texture,cursor.Position,Color.White);
            }

            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    spriteBatch.Draw(ressource.tile, new Vector2(i * 32, j * 32), Tile.tile(tiles[i, j]),
                       Color.White);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Templar
{
    public class Tile
    {
        //enumerationdes type de tile
        public enum TileType
        {
            wall = -1,
            normal = 0,
        };

        int x;
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        int y;
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        TileType type;

        //permet de retounre le type du tyle
        public TileType Type
        {
            get { return type; }
        }

        //constructeur de la classe
        public Tile(int x, int y, int type)
        {

            this.x = x;
            this.y = y;
            switch (type)
            {
                case 0:
                    this.type = TileType.wall;
                    break;
                default:
                    this.type = TileType.normal;
                    break;
            }

        }
        //retourne le tile en fonction de sa position x,y dans la fiche de tile et de 32 par 32
        static public Rectangle tile(Vector2 vect)
        {
            return new Rectangle(32 * (int)vect.X,32 * (int)vect.Y, 32, 32);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Templar
{
    class Node
    {
        Tile tile;
        public Tile Tile
        {
            get { return tile; }
        }
        Node parent;
        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        int heuristic;
        public int Heuristic
        {
            get { return heuristic; }
        }




        public Node(Tile tile, Node Parent, Tile destination)
        {
            this.tile = tile;
            this.Parent = parent;
            this.heuristic = Math.Abs(tile.X - destination.X) + Math.Abs(tile.Y - destination.Y) + (int)tile.Type;
        }
        public List<Node> GetPossibleNode(Map map, Tile Destination)
        {
            List<Node> result = new List<Node>();
            // Bottom
             if (map.ValidCoordinate(tile.X, tile.Y + 1) && map.Tilelist[tile.X, tile.Y + 1].Type != Templar.Tile.TileType.wall)
            {
                result.Add(new Node(map.Tilelist[tile.X, tile.Y + 1], this, Destination));
            }
            // Right
            if (map.ValidCoordinate((tile.X  + 1), tile.Y ) && map.Tilelist[tile.X + 1, tile.Y].Type != Templar.Tile.TileType.wall)
            {
                // result.Add(new Node(map.Tilelist[tile.Y, tile.X+1], this, Destination));
                result.Add(new Node(map.Tilelist[tile.X + 1, tile.Y], this, Destination));
            }

            // Top
            if (map.ValidCoordinate(tile.X, tile.Y - 1) && map.Tilelist[tile.X, tile.Y - 1].Type != Templar.Tile.TileType.wall)
            {
                //result.Add(new Node(map.Tilelist[tile.Y-1, tile.X], this, Destination));
                result.Add(new Node(map.Tilelist[tile.X, tile.Y - 1], this, Destination));
            }
            //Left
            if (map.ValidCoordinate(tile.X - 1, tile.Y) && map.Tilelist[tile.X - 1, tile.Y].Type != Templar.Tile.TileType.wall)
            {
                //result.Add(new Node(map.Tilelist[tile.Y , tile.X - 1], this, Destination));
                result.Add(new Node(map.Tilelist[tile.X - 1, tile.Y], this, Destination));
            }

            return result;

        }

    }
}

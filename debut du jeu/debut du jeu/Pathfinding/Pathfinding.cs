using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Templar
{
    class Pathfinding
    {
        public static List<Tile> Astar(Map map, Tile Start, Tile End)
        {
            
            Nodelist<Node> openlist = new Nodelist<Node>();
            Nodelist<Node> closelist = new Nodelist<Node>();
            List<Node> possibleNode;
            int possibleNodeCount;
            List<Tile> sol = new List<Tile>();
            Node StartNode = new Node(Start, null, End);

            openlist.Add(StartNode);
            possibleNode = StartNode.GetPossibleNode(map, End);
            possibleNodeCount = possibleNode[0].Heuristic;
            int result = 0;
            for (int i = 1; i < possibleNode.Count; i++)
            {
                if (possibleNode[i].Heuristic<possibleNodeCount)
                {
                    result = i;
                    possibleNodeCount = possibleNode[i].Heuristic;
                }
            }
            sol.Add(possibleNode[result].Tile);
            return sol;
            /*
          while (openlist.Count>0)
            {
                Node current = openlist[0];
                closelist.Add(current);
                possibleNode = current.GetPossibleNode(map, End);
                possibleNodeCount = possibleNode.Count;
                for (int i = 0; i < possibleNodeCount; i++)
                {
                    openlist.DichotomicInsertion(possibleNode[i]);
                }
                List<Tile> sol = new List<Tile>();
                if (openlist.Count != 0)
                {
                    sol.Add(openlist[0].Tile);
                }
                else
                {
                    sol.Add(current.Tile);
                }
                
                return sol;
            }
          */
        }
    }
}

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
            Node StartNode = new Node(Start, null, End);
            List<Tile> sol = new List<Tile>();
            openlist.Add(StartNode);

            
          while (openlist.Count>0)
            {
                Node current = openlist[0];
                openlist.RemoveAt(0);
                closelist.Add(current);
                
                if (current.Tile.X==End.X && current.Tile.Y == End.Y)
                {
                    while (current.Parent != null)
                    {
                        sol.Insert(0, current.Tile);
                        current = current.Parent;
                        
                    }
                    return sol;
                }
                possibleNode = current.GetPossibleNode(map, End);
                possibleNodeCount = possibleNode.Count;
                for (int i = 0; i < possibleNodeCount; i++)
                {
                    if (!closelist.Contains(possibleNode[i]))
                    {
                        if (openlist.Contains(possibleNode[i]))
                        {
                            if (possibleNode[i].Heuristic < openlist[possibleNode[i]].Heuristic)
                                openlist[possibleNode[i]].Parent = current;
                        }
                        else
                            openlist.DichotomicInsertion(possibleNode[i]);
                    }
                }

            }
           sol.Add(Start);
           return sol;
          
        }
    }
}

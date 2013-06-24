using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Templar
{
    class Nodelist<T> : List<T> where T : Node
    {
        public new bool Contains(T node)
        {
            return this[node] != null;
        }

        public T this[T node]
        {
            get
            {
                int count = this.Count;
                for (int i = 0; i < count; i++)
                {
                    if (this[i].Tile == node.Tile)
                    {
                        return this[i];
                    }
                }
                return default(T);
            }
        }

        public void DichotomicInsertion(T node)
        {
            int left = 0;
            int right = this.Count - 1;
            int center = 0;
            while (left <= right)
            {
                center = (left + right) / 2;
                if (node.Heuristic < this[center].Heuristic)
                {
                    right = center - 1;
                }
                else if (node.Heuristic > this[center].Heuristic)
                {
                    left = center + 1;
                }
                else
                {
                    left = center;
                    break;
                }
            }
            this.Insert(left, node);
        }
    }
}

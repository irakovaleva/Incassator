using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    class RealisticAlg : ABranching
    {

        public override Vertex chooseVertex(Task task, List<Vertex> curVertexes)
        {
            if (curVertexes.Count() == 1)
            {
                return curVertexes.ElementAt(0);
            }
            else
            {
                int minTopScore = Selection.tree.findMin();
                int minIndex = -1;
                for (int i = curVertexes.Count - 1; i >= 0; i--)
                {
                    if (curVertexes[i].topScore == minTopScore)
                    {
                        minIndex = i;
                        break;
                    }
                }
                //int minTopScore = -1;
                //int minIndex = -1;
                /*for (int i = 0; i < curVertexes.Count(); i++)
                {
                    int curTopScore = curVertexes[i].topScore;
                    if ((minTopScore == -1 || curTopScore < minTopScore))
                    {
                        minTopScore = curTopScore;
                        minIndex = i;
                    }
                }*/
                return (minIndex == -1) ? null : curVertexes.ElementAt(minIndex);
            }
        }
    }
}

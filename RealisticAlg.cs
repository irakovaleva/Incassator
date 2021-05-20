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
                int minTopScore = -1;
                int minIndex = -1;
                for (int i = 0; i < curVertexes.Count(); i++)
                {
                    int curTopScore = curVertexes.ElementAt(i).getTopScore();
                    if ((minTopScore == -1 || curTopScore < minTopScore) && curTopScore != -1)
                    {
                        minTopScore = curTopScore;
                        minIndex = i;
                    }
                }
                return (minIndex == -1) ? null : curVertexes.ElementAt(minIndex);
            }
        }
    }
}

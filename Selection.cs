using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    class Selection
    {
        public static void getSelection(List<Vertex> vertexes, AGettingScore lowScoreAlg, AGettingScore topScoreAlg)
        {
            int minTopScore = -1;
            int[] curTopScore = new int[vertexes.Count()];
            int[] curMinScore = new int[vertexes.Count()];
            for (int i = 0; i < vertexes.Count(); i++)
            {
                curTopScore[i] = vertexes.ElementAt(i).getTopScore(topScoreAlg);
                if (curTopScore[i] != -1 && (minTopScore == -1 || curTopScore[i] < minTopScore))
                {
                    minTopScore = curTopScore[i];
                }
            }

            List<int> toRemove = new List<int>();
            for (int i = 0; i < vertexes.Count(); i++)
            {
                curMinScore[i] = vertexes.ElementAt(i).getLowScore(lowScoreAlg);
                if (curMinScore[i] >= minTopScore && minTopScore != -1 || curMinScore[i] == -1 || curTopScore[i] == -1)
                {
                    toRemove.Add(i);
                }
            }

            for (int i = 0; i < vertexes.Count(); i++)
            {
                if (curMinScore[i] == curTopScore[i])
                {
                    if(!toRemove.Contains(i))
                    {
                        toRemove.Add(i);
                    }
                    if (curMinScore[i] != -1 && (MainAlgorithm.tempMin == -1 || curMinScore[i] < MainAlgorithm.tempMin))
                    {
                        MainAlgorithm.tempMin = curMinScore[i];
                        MainAlgorithm.bestSolution.setOrder(vertexes.ElementAt(i).fixedOrder);
                    }
                }
            }

            //toRemove.Sort();
            //toRemove.Reverse();

            for (int i = toRemove.Count() - 1; i >= 0; i--)
            {
                //Vertex curVertex = vertexes[toRemove[i]];
                //string removedVertex = string.Join(" ", curVertex.fixedOrder);
                //removedVertexes.Add(removedVertex);
                vertexes.RemoveAt(toRemove[i]); 
            }
        }
    }
}

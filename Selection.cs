using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    class Selection
    {
        public static int numOfNewVertexes;
        public static int minTopScore;
        public static BinaryTree tree;
        public static void getSelection(List<Vertex> vertexes, AGettingScore lowScoreAlg, AGettingScore topScoreAlg)
        {
            int vertexesCount = vertexes.Count;
            //int minTopScore = -1;
            //int[] curMinScore = new int[vertexesCount];
            //int[] curTopScore = new int[numOfNewVertexes];
            //int[] curMinScore = new int[numOfNewVertexes];
            for (int i = vertexesCount - numOfNewVertexes; i < vertexesCount; i++)
            //for (int i = 0; i < vertexes.Count(); i++)
            {
                int topScore = vertexes[i].getTopScore(topScoreAlg);
                //int indexForTop = i - vertexesCount + numOfNewVertexes;
                //curTopScore[indexForTop] = vertexes[i].getTopScore(topScoreAlg);
                if (topScore != -1)
                {
                    tree.add(topScore);
                }
            }


            minTopScore = tree.findMin();


            List<int> toRemove = new List<int>();
            for (int i = 0; i < vertexes.Count(); i++)
            {
                int lowScore = vertexes[i].getLowScore(lowScoreAlg);
                int topScore = vertexes[i].topScore;
                //curMinScore[i] = vertexes.ElementAt(i).getLowScore(lowScoreAlg);
                if (minTopScore != -1 && lowScore >= minTopScore  || lowScore == -1 || topScore == -1)
                {
                    toRemove.Add(i);
                }
                if (lowScore == topScore)
                {
                    if (!toRemove.Contains(i))
                    {
                        toRemove.Add(i);
                    }
                    if (lowScore != -1 && (MainAlgorithm.tempMin == -1 || lowScore < MainAlgorithm.tempMin))
                    {
                        MainAlgorithm.tempMin = lowScore;
                        MainAlgorithm.bestSolution.setOrder(vertexes.ElementAt(i).fixedOrder);
                    }
                }
            }

           /* string str = "----------------------\n";
            for (int i = 0; i < vertexes.Count; i++)
            {
                str += "Order: ";
                for (int j = 0; j < vertexes[i].fixedOrder.Count; j++)
                {
                    str += vertexes[i].fixedOrder[j];
                }
                str += "\t\tlow = " + vertexes[i].lowScore + "\t\ttop=" + vertexes[i].topScore + "\n";
            }
            str += "minTopScore = " + minTopScore + "\n";
            Console.WriteLine(str);*/


            for (int i = toRemove.Count() - 1; i >= 0; i--)
            {
                int index = toRemove[i];
                int topScore = vertexes[index].topScore;
                if (topScore != -1)
                {
                    tree.remove(topScore);
                }
                vertexes.RemoveAt(index);
            }
        }
    }
}


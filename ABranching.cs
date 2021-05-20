using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    public abstract class ABranching
    {
        protected AGettingScore lowScoreAlg;
        protected AGettingScore topScoreAlg;
        public static int numOfBranches;


        public ABranching(AGettingScore lowScoreAlg, AGettingScore topScoreAlg)
        {
            this.lowScoreAlg = lowScoreAlg;
            this.topScoreAlg = topScoreAlg;
        }

        public void getParentNextVertexes(Task task, List<Vertex> curVertexes)
        {
            Vertex curVertex;
            curVertex = chooseVertex(task, curVertexes);  //выбор вершины ветвления
            if (curVertex != null)
            {
                List<int> remainedPoints = getRemainedPoints(task, curVertex.fixedOrder);
                for (int i = 0; i < remainedPoints.Count(); i++)   //ветвление, составление вариантов последовательности обхода
                {
                    if (task.times[curVertex.fixedOrder.ElementAt(curVertex.fixedOrder.Count() - 1), remainedPoints.ElementAt(i)] > 0)
                    {
                        List<int> curOrder = curVertex.fixedOrder.ToList();
                        curOrder.Add(remainedPoints.ElementAt(i));
                        Vertex nextVertex = new Vertex(task, curOrder);
                        curVertexes.Add(nextVertex);
                        numOfBranches++;
                    }
                }
                curVertexes.Remove(curVertex);
            }

        }

        public abstract Vertex chooseVertex(Task task, List<Vertex> curVertexes);

        public static List<int> getRemainedPoints(Task task, List<int> fixedOrder)  // add to list remainedPoints banks which are not included in fixedOrder
        {
            List<int> remainedPoints = new List<int>();
            for (int i = 0; i < task.numOfLocations; i++)
            {
                if (!fixedOrder.Contains(i))
                {
                    remainedPoints.Add(i);
                }
            }
            return remainedPoints;
        }
    }
}

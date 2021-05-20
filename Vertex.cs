using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    public class Vertex
    {
        public Task task;
        public List<int> fixedOrder;
        private int lowScore;
        private int topScore;

        public Vertex(Task task, List<int> fixedOrder)
        {
            this.task = task;
            this.fixedOrder = fixedOrder;
            this.topScore = -2;
            this.lowScore = -2;
        }

        public int getLowScore(AGettingScore lowScoreAlg=null)
        {
            if (lowScore == -2)
            {
                if (lowScoreAlg == null)
                {
                    Console.WriteLine("ERROR: Need to set low score algorithm as a parametr\n");
                    throw new Exception();
                }
                lowScore = lowScoreAlg.getScore(task, fixedOrder);
            }
            return lowScore;
        }

        public int getTopScore(AGettingScore topScoreAlg=null)
        {
            if (topScore == -2)
            {
                if (topScoreAlg == null)
                {
                    Console.WriteLine("ERROR: Need to set top score algorithm as a parametr\n");
                    throw new Exception();
                }
                topScore = topScoreAlg.getScore(task, fixedOrder);
            }
            return topScore;
        }

    }
}

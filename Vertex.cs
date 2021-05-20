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

        public int getLowScore(AGettingScore lowScoreAlg)
        {
            if (lowScore == -2)
                lowScore = lowScoreAlg.getScore(task, fixedOrder);
            return lowScore;
        }

        public int getTopScore(AGettingScore topScoreAlg)
        {
            if (topScore == -2)
                topScore = topScoreAlg.getScore(task, fixedOrder);
            return topScore;
        }

    }
}

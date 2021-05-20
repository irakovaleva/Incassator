using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    public abstract class AGettingScore
    {
        protected List<int> extendOrder;
        public abstract int getScore(Task task, List<int> fixedOrder);
        public abstract List<int> getExtendOrder();

        public int getFixedValue(Task task, List<int> fixedOrder)
        {
            int summaryTime = 0;
            int directiveTimesFaults = 0;
            int safety = 0;
            int curSum = task.initialSum;

            for (int i = 1; i < fixedOrder.Count(); i++)
            {
                // Check if we have needed sum
                if (curSum + task.profitOnVertex[fixedOrder.ElementAt(i)] < 0)
                {
                    return -1;
                }
                int curTime = task.times[fixedOrder.ElementAt(i - 1), fixedOrder.ElementAt(i)];
                summaryTime += curTime;
                if (curTime == -1)
                {
                    return -1;
                }
                if (summaryTime > task.directiveTime[fixedOrder.ElementAt(i)])
                {
                    directiveTimesFaults++;
                }
                int curSafety = curSum * curTime;
                safety += curSafety;
                curSum += task.profitOnVertex[fixedOrder.ElementAt(i)];
            }
            if (directiveTimesFaults > task.directiveFaultsMax)
            {
                return -1;
            }
            return safety;
        }

        public int getSumTime(Task task, List<int> fixedOrder)
        {
            int sumTime = 0;
            for (int i = 1; i < fixedOrder.Count(); i++)
            {
                sumTime = sumTime + task.times[fixedOrder.ElementAt(i - 1), fixedOrder.ElementAt(i)];
            }
            return sumTime;
        }

        public int getCurrentSum(Task task, List<int> fixedOrder)
        {
            int curSum = task.initialSum;
            for (int i = 1; i < fixedOrder.Count(); i++)
            {
                curSum += task.profitOnVertex[fixedOrder.ElementAt(i)];
            }
            return curSum;
        }

        public int getDirectiveFaults(Task task, List<int> someOrder)
        {
            int sumTime = 0;
            int directiveFaults = 0;
            for (int i = 1; i < someOrder.Count(); i++)
            {
                sumTime = sumTime + task.times[someOrder.ElementAt(i - 1), someOrder.ElementAt(i)];
                if (sumTime > task.directiveTime[someOrder.ElementAt(i)] && someOrder.ElementAt(i) != 0)
                {
                    directiveFaults++;
                }
            }
            return directiveFaults;
        }
    }
}

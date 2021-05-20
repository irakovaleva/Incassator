using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    class SoftLowScore : AGettingScore
    {
        public override int getScore(Task task, List<int> fixedOrder)
        {
            int result = getFixedValue(task, fixedOrder);

            if (result != -1)
            {
                List<int> remainedPoints = ABranching.getRemainedPoints(task, fixedOrder);
                int curSum = getCurrentSum(task, fixedOrder);
                if (curSum < 0)
                {
                    return -1;
                }
                // Get min value of curSum that can be reached
                int minCurSum = getMinPossibleCurSum(task, remainedPoints, curSum);

                remainedPoints.Add(0);
                for (int i = 0; i < remainedPoints.Count(); i++)
                {
                    int curTime = task.times[fixedOrder.ElementAt(fixedOrder.Count() - 1), remainedPoints.ElementAt(i)];  //смотрим расстояние от последнего элемента зафиксированного порядка до нового
                    result += minCurSum * curTime;
                }
            }
            return result;
        }

        private int getMinPossibleCurSum(Task task, List<int> remainedPoints, int curSum)
        {
            int result = curSum;
            for (int i = 0; i < remainedPoints.Count(); i++)
            {
                int curValue = task.profitOnVertex[remainedPoints.ElementAt(i)];
                if (curValue < 0)
                {
                    result += curValue;
                    if (result < 0)
                    {
                        return 0;
                    }
                }
            }
            return result;
        }

        private List<int> getSortListByGivenMoney(Task task, List<int> remainedPoints)
        {
            List<int> sortedPoints = new List<int>();
            while (sortedPoints.Count() != remainedPoints.Count())
            {
                int minValue = 0;
                int minIndex = -1;
                for (int i = 0; i < remainedPoints.Count(); i++)
                {
                    int curIndex = remainedPoints.ElementAt(i);
                    if (!sortedPoints.Contains(curIndex))
                    {
                        int curValue = task.profitOnVertex[curIndex];
                        if (minValue == 0 || curValue < minValue)
                        {
                            minValue = curValue;
                            minIndex = curIndex;
                        }
                    }
                }
                sortedPoints.Add(minIndex);
            }
            return sortedPoints;
        }


        public override List<int> getExtendOrder()
        {
            throw new NotImplementedException();
        }
    }
}

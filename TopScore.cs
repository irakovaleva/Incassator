using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    class TopScore : AGettingScore
    {
        public override int getScore(Task task, List<int> fixedOrder)
        {
            // If curSum is more that average then go to available vertex with minimal value of benefits, if less - go to available with max value of benefits
            int result = getFixedValue(task, fixedOrder);
            if (result != -1)
            {
                extendOrder = fixedOrder.ToList();   
                List<int> remainedPoints = ABranching.getRemainedPoints(task, fixedOrder);
                int sumTime = getSumTime(task, fixedOrder);
                int curSum = getCurrentSum(task, fixedOrder);
                if (curSum < 0)
                {
                    return -1;
                }
                int averageSum = getAverageValueOfBenefits(task, remainedPoints);
                while (extendOrder.Count() != task.numOfLocations)
                {
                    int curPoint = extendOrder.ElementAt(extendOrder.Count() - 1);
                    int nextPoint = (curSum < averageSum) ? getIndexOfNextVertexLess(task, remainedPoints, curSum, extendOrder) : getIndexOfNextVertexMore(task, remainedPoints, curSum, extendOrder);
                    if (nextPoint == -1)
                    {
                        return -1;
                    }

                    int curDist = task.times[curPoint, nextPoint];
                    extendOrder.Add(nextPoint);    //достраиваем порядок в fixedOrder, чтобы все вершины были включены
                    result += curDist * curSum;
                    curSum += task.profitOnVertex[nextPoint];
                    remainedPoints.Remove(nextPoint);
                }
                int dist = task.times[extendOrder.ElementAt(extendOrder.Count() -1), 0];
                result += dist * curSum;
                extendOrder.Add(0);
            }
            return result;
        }

        public int getIndexOfNextVertexLess(Task task, List<int> remainedPoints, int curSum, List<int> fixedOrder)
        {
            int resultIndex = -1;
            int maxValue = 0;
            int curDirectiveFaults = getDirectiveFaults(task, fixedOrder);
            List<int> indexes = new List<int>();
            List<int> normindexes = new List<int>();
            for (int i = 0; i < remainedPoints.Count(); i++)
            {
                int curIndex = remainedPoints[i];
                int curValue = task.profitOnVertex[curIndex];
                int newDirectiveFaults = checkForDirectiveFaults(task, fixedOrder, curIndex);
                if (curSum + curValue >= 0 && newDirectiveFaults <= task.directiveFaultsMax)
                {
                    indexes.Add(curIndex);
                    if (newDirectiveFaults == curDirectiveFaults)
                    {
                        normindexes.Add(curIndex);
                    }
                }
            }
            //List<int> arrayToFind = (normindexes.Count == 0 || task.directiveFaultsMax == task.numOrders) ? indexes : normindexes;
            List<int> arrayToFind = normindexes.Count == 0 ? indexes : normindexes;
            for (int i = 0; i < arrayToFind.Count; i++)
            {
                int curIndex = arrayToFind[i];
                int curValue = task.profitOnVertex[curIndex];
                if (curValue > maxValue)
                {
                    maxValue = curValue;
                    resultIndex = curIndex;
                }
            }
            return resultIndex;
        }

        public int getIndexOfNextVertexMore(Task task, List<int> remainedPoints, int curSum, List<int> fixedOrder)
        {
            int resultIndex = -1;
            int minValue = 0;
            int curDirectiveFaults = getDirectiveFaults(task, fixedOrder);
            List<int> indexes = new List<int>();
            List<int> normindexes = new List<int>();
            for (int i = 0; i < remainedPoints.Count(); i++)
            {
                int curIndex = remainedPoints[i];
                int curValue = task.profitOnVertex[curIndex];
                int newDirectiveFaults = checkForDirectiveFaults(task, fixedOrder, curIndex);
                if (curSum + curValue >= 0 && newDirectiveFaults <= task.directiveFaultsMax)
                {
                    indexes.Add(curIndex);
                    if (newDirectiveFaults == curDirectiveFaults)
                    {
                        normindexes.Add(curIndex);
                    }
                }
            }
            //List<int> arrayToFind = (normindexes.Count == 0 || task.directiveFaultsMax == task.numOrders) ? indexes : normindexes;
            List<int> arrayToFind = normindexes.Count == 0 ? indexes : normindexes;
            for (int i = 0; i < arrayToFind.Count; i++)
            {
                int curIndex = arrayToFind[i];
                int curValue = task.profitOnVertex[curIndex];
                if (minValue == 0 || curValue < minValue)
                {
                    minValue = curValue;
                    resultIndex = curIndex;
                }
            }
            return resultIndex;
        }

        public int checkForDirectiveFaults(Task task, List<int> fixedOrder, int nextPointIndex)
        {
            List<int> newOrder = fixedOrder.ToList<int>();
            newOrder.Add(nextPointIndex);
            int directiveFaults = getDirectiveFaults(task, newOrder);
            return directiveFaults;
        }

        public int getAverageValueOfBenefits(Task task, List<int> remainedPoints)
        {
            int result = 0;
            if (remainedPoints.Count() == 0)
            {
                return result;
            }
            for (int i = 0; i < remainedPoints.Count(); i++)
            {
                int curValue = task.profitOnVertex[remainedPoints.ElementAt(i)];
                result += curValue;
            }
            return result / remainedPoints.Count();
        }

        public override List<int> getExtendOrder()
        {
            return extendOrder;
        }
    }
}

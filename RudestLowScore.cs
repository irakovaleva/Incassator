using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    class RudestLowScore : AGettingScore
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
                // Get min sum of matrix
                int remainedTime = getMinSumOnMatrix(task, fixedOrder);
                if (remainedTime == -1)
                {
                    remainedTime = task.times[fixedOrder[fixedOrder.Count - 1], 0];
                }
                int remainedSum;
                //int averageRemainedSum = getAverageRemainedSum(task, remainedPoints);
                int sumOfRemained = getSumOfRemainedSum(task, remainedPoints);
                if (sumOfRemained >= 0)
                {
                    remainedSum = curSum;
                }
                else
                {
                    remainedSum = getMaxProfitLessThanCurrent(task, curSum, fixedOrder);
                }
                result += remainedSum * remainedTime;
            }
            return result;
        }

        private int getMaxProfitLessThanCurrent(Task task, int curSum, List<int> fixedOrder)
        {
            int result = 0;
            for (int i = 1; i < task.numOfLocations; i++)
            {
                if (!fixedOrder.Contains(i))
                {
                    int curValue = task.profitOnVertex[i];
                    if (curValue < curSum && curValue > result)
                    {
                        result = curValue;
                    }
                }
            }
            return (result == 0) ? curSum : result;
        }

        private int getAverageRemainedSum(Task task, List<int> remainedPoints)
        {
            if (remainedPoints.Count == 0)
            {
                return 0;
            }
            int result = 0;
            for (int i = 0; i < remainedPoints.Count; i++)
            {
                result += task.profitOnVertex[remainedPoints[i]];
            }
            result = Convert.ToInt32(result / remainedPoints.Count);
            return result;
        }

        private int getSumOfRemainedSum(Task task, List<int> remainedPoints)
        {
            if (remainedPoints.Count == 0)
            {
                return 0;
            }
            int result = 0;
            for (int i = 0; i < remainedPoints.Count; i++)
            {
                result += task.profitOnVertex[remainedPoints[i]];
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

        private int getMinSumOnMatrix(Task task, List<int> fixedOrder)
        {
            List<int> usedValues = new List<int>();
            for (int i = 1; i < fixedOrder.Count; i++)
            {
                usedValues.Add(fixedOrder[i]);
            }
            int minRow = 0;
            int minColumn = 0;
            for (int i = 0; i < task.numOfLocations; i++)
            {
                if (!usedValues.Contains(i))
                {
                    int curMinRow = -1;
                    int curMinColumn = -1;
                    for (int j = 0; j < task.numOfLocations; j++)
                    {
                        if (!usedValues.Contains(j))
                        {
                            int curValueRow = task.times[i, j];
                            int curValueColumn = task.times[j, i];
                            if (curMinRow == -1 || (curValueRow != -1 && curValueRow < curMinRow))
                            {
                                curMinRow = curValueRow;
                            }
                            if (curMinColumn == -1 || (curValueColumn != -1 && curValueColumn < curMinColumn))
                            {
                                curMinColumn = curValueColumn;
                            }
                        }
                    }
                    minRow += curMinRow;
                    minColumn += curMinColumn;
                }
            }

            return (minRow < minColumn) ? minColumn : minRow;
        }

        private int findNextVertex(Task task, List<int> sortedPoints, int curSum)
        {
            int result = -1;
            for (int i = 0; i < sortedPoints.Count; i++)
            {
                int sumOnVertex = task.profitOnVertex[sortedPoints[i]];
                if (sumOnVertex > 0)
                {
                    break;
                }
                if (curSum + sumOnVertex < 0)
                {
                    continue;
                }
                else
                {
                    result = i;
                    break;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    class BruteForce  : AGettingScore
    {
        private Solution solution;
        private Task task;
        public long time;

        public override List<int> getExtendOrder()
        {
            throw new NotImplementedException();
        }

        public override int getScore(Task task, List<int> fixedOrder)
        {
            throw new NotImplementedException();
        }

        public Solution getSolution(Task task)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            this.task = task;
            this.task.directiveFaultsMax = this.task.numOrders;
            solution = new Solution(task);
            LinkedList<int> initOrder = new LinkedList<int>();
            initOrder.AddFirst(1);
            extendWith(task.numOrders, initOrder, 2);
            watch.Stop();
            time = watch.ElapsedMilliseconds;
            return solution;
        }

        private List<int> getInitOrder(int numOfLocations)
        {
            List<int> order = new List<int>();
            order.Add(0);
            for (int i = 1; i < numOfLocations; i++)
            {
                order.Add(i);
            }
            order.Add(0);
            return order;
        }

        private void investigateSolution(LinkedList<int> curOrder)
        {
            curOrder.AddFirst(0);
            curOrder.AddLast(0);
            List<int> order = new List<int>(curOrder);
            int curScore = getFixedValue(task, order);
            int optimum = solution.getOptimum();
            if (curScore != -1 && (solution.getOrderNumber() == null || optimum >= curScore))
            {
                int curDirectiveFaults = getDirectiveFaults(task, order);
                if (solution.getOrderNumber() == null || optimum > curScore)
                {
                    solution.setOptimum(curScore);
                    solution.setOrder(order);
                    solution.setDirectiveFaults(curDirectiveFaults);
                }
                else
                {
                    if (curDirectiveFaults < solution.getDirectiveFaults())
                    {
                        solution.setOptimum(curScore);
                        solution.setOrder(order);
                        solution.setDirectiveFaults(curDirectiveFaults);
                    }
                }
            }
        }

        private void extendWith(int numOfVertexes, LinkedList<int> fixedOrder, int curIndexToExtend)
        {
            for (int i = 0; i < fixedOrder.Count + 1; i++)
            {
                LinkedList<int> newOrder = new LinkedList<int>(fixedOrder);
                LinkedListNode<int> before = getNodeBeforeInsert(newOrder, i);
                if (before == null)
                {
                    newOrder.AddLast(curIndexToExtend);
                } else
                {
                    newOrder.AddBefore(before, curIndexToExtend);
                }
                if (newOrder.Count == numOfVertexes)
                {
                    investigateSolution(newOrder);
                }
                else
                {
                    extendWith(numOfVertexes, newOrder, curIndexToExtend + 1);
                }
            }
        }

        private LinkedListNode<int> getNodeBeforeInsert(LinkedList<int> order, int index)
        {
            LinkedListNode<int> before = order.First;
            for (int i = 0; i < index; i++)
            {
                before = before.Next;
            }
            return before;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    class Solution
    {
        private Task task;
        private List<int> orderNumber;
        private int numSteps;
        private int numBranches;
        private int optimum;
        private int directiveFaults;

        public Solution(Task task)
        {
            this.task = task;
        }

        public void setOrder(List<int> orderNumber)
        {
            this.orderNumber = orderNumber;
        }

        public void setNumSteps(int numSteps)
        {
            this.numSteps = numSteps;
        }

        public void setOptimum(int optimum)
        {
            this.optimum = optimum;
        }

        public void setNumBranches(int numBranches)
        {
            this.numBranches = numBranches;
        }

        public List<int> getOrderNumber()
        {
            return orderNumber;
        }

        public void setDirectiveFaults(int numOfdirectiveFaults)
        {
            this.directiveFaults = numOfdirectiveFaults;
        }

        public int getDirectiveFaults()
        {
            return this.directiveFaults;
        }

        public int getOptimum()
        {
            return optimum;
        }

        public Solution Clone()
        {
            Solution copy = new Solution(this.task);
            copy.numBranches = this.numBranches;
            copy.numSteps = this.numSteps;
            copy.orderNumber = this.orderNumber.ToList();
            copy.optimum = this.optimum;
            copy.directiveFaults = this.directiveFaults;

            return copy;
        }

        public string getPrint()
        {
            String result = "Order is: 0";
            for (int i = 1; i < orderNumber.Count; i++)
            {
                result += " -> " + orderNumber[i];
            }
            result += ":\n0. 0 point - bank, initial sum = " + task.initialSum + "\n";
            int sumTime = 0;
            int curSum = task.initialSum;
            for (int i = 1; i < orderNumber.Count - 1; i++)
            {
                int curTime = task.times[orderNumber.ElementAt(i - 1), orderNumber.ElementAt(i)];
                sumTime += curTime;
                result += (i) + ". " + orderNumber.ElementAt(i) +
                        " point: \n    dest for point = " + curTime +
                        ";\n    current sum we have = " + curSum +
                        ";\n    profit from point = " + task.profitOnVertex[orderNumber.ElementAt(i)] +
                        ";\n    safety value from this segment = " + (curSum * curTime) +
                        ";\n    summary time we spent = " + sumTime +
                        ";\n    directive time for point = " + task.directiveTime[orderNumber.ElementAt(i)];
                curSum += task.profitOnVertex[orderNumber.ElementAt(i)];
                if (sumTime > task.directiveTime[orderNumber.ElementAt(i)])
                {
                    result += " BAD";
                }
                result += "\n";
            }
            // for the last bank
            int last_index = orderNumber.Count() - 1;
            int time = task.times[orderNumber.ElementAt(last_index), orderNumber.ElementAt(last_index - 1)];
            sumTime += time;
            result += (last_index + 1) + ". " + orderNumber.ElementAt(last_index) +
                      " point (bank): \n    dest for point = " + time +
                      ";\n    current sum we have = " + curSum +
                      ";\n    safety value from this segment = " + (curSum * time) +
                      ";\n    summary time we spent = " + sumTime + "\n";
            result += "\nSum value of safety is = " + optimum +
                      "\nNum of directive times faults = " + directiveFaults + "\n\n";
                      //"\nNum of steps is = " + numSteps +
                      //"\nNum of vertexes is = " + numBranches + "\n\n";
            return result;
        }

        public string getShortPrint()
        {
            String result = "Order is: 0";
            for (int i = 1; i < orderNumber.Count; i++)
            {
                result += " -> " + orderNumber[i];
            }
            result += ":\nSum value of safety is = " + optimum +
                      "\nNum of directive times faults = " + directiveFaults + "\n\n"; ;
            return result;
        }


    }
}

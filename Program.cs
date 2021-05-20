using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Incassator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static private AGettingScore lowScoreAlg;
        static private AGettingScore topScoreAlg;
        static private ABranching branchingAlg;
        public static int globalMin;
        public static int tempMin;
        public static Solution bestSolution;
        public static int numBranches;
        public static bool ifTimeCounts;
        //public static Delivery.Task task;
        public static List<Solution> allSolutions;

        public static Task OpenTask(string fileName)
        {
            lowScoreAlg = new RudestLowScore();
            topScoreAlg = new BaseTopScore();
            branchingAlg = new OptimisticAlg(lowScoreAlg, topScoreAlg);
            globalMin = -1;
            tempMin = -1;
            ifTimeCounts = false;
            Task task = new Task(fileName);
            bool check = task.checkForTriangleRuleAndCorrect();
            return task;
        }

        public static Solution getSolution(Task task)
        {
            bestSolution = new Solution(task);
            int numSteps = 0;
            numBranches = 0;
            List<int> fixedOrder = new List<int>();
            fixedOrder.Add(0);
            List<Vertex> curVertexes = new List<Vertex>();
            Vertex top = new Vertex(task, fixedOrder);
            curVertexes.Add(top);
            numBranches++;
            while (curVertexes.Count() != 0)
            {
                numSteps++;
                //Console.Write(numSteps + "\n");
                branchingAlg.getParentNextVertexes(task, curVertexes);
                //for (int i = 0; i < curVertexes.Count(); i++) {
                //    Console.WriteLine(string.Join(" ", curVertexes[i].fixedOrder) + "\n");
                //}
                Selection.getSelection(curVertexes, lowScoreAlg, topScoreAlg);
            }
            if (tempMin == -1)
            {
                return null;
            }
            bestSolution.setNumSteps(numSteps);
            bestSolution.setOptimum(topScoreAlg.getScore(task, bestSolution.getOrderNumber()));
            bestSolution.setOrder(topScoreAlg.getExtendOrder());
            bestSolution.setNumBranches(numBranches);
            bestSolution.setDirectiveFaults(topScoreAlg.getDirectiveFaults(task, bestSolution.getOrderNumber()));
            return bestSolution.Clone();

        }

        public static int tryToGetSolutionWithLessDirectiveFaults(Task task)
        {
            int solutionIndex = -1;
            Solution curSolution = bestSolution;
            globalMin = tempMin;
            int maxDirValue = bestSolution.getDirectiveFaults();
            int minDirValue = 0;
            while (maxDirValue - minDirValue > 1)
            {
                tempMin = -1;
                int curDirValue = (int)Math.Ceiling(Convert.ToDouble(maxDirValue + minDirValue) / Convert.ToDouble(2));
                task.directiveFaultsMax = curDirValue;
                Solution result = getSolution(task);
                if (result == null || tempMin > curSolution.getOptimum())
                {
                    minDirValue = curDirValue;
                }
                else
                {
                    curSolution = result;
                    maxDirValue = curDirValue;
                    solutionIndex = allSolutions.Count;
                }
                if (result != null)
                {
                    allSolutions.Add(result.Clone());
                }
            }
            return solutionIndex;
        }
    }
}

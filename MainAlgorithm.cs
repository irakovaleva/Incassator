using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Incassator
{
    static class MainAlgorithm
    {
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
        public static List<Solution> allSolutions;

        public static Task OpenTask(string fileName)
        {
            lowScoreAlg = new RudestLowScore();
            topScoreAlg = new BaseTopScore();
            branchingAlg = new OptimisticAlg();
            globalMin = -1;
            tempMin = -1;
            Task task = new Task(fileName);
            bool check = task.checkForTriangleRuleAndCorrect();
            return task;
        }

        public static int getSolution(Task task)
        {
            int bestSolutionIndex = 0;
            Solution solution = runMVG(task);
            allSolutions.Add(solution);
            int anotherSolutionIndex = MainAlgorithm.tryToGetSolutionWithLessDirectiveFaults(task);
            if (anotherSolutionIndex != -1)
            {
                bestSolutionIndex = anotherSolutionIndex;
            }
            return bestSolutionIndex;
        }

        public static Solution runMVG(Task task)
        {
            bestSolution = new Solution(task);
            int numSteps = 0;
            List<int> fixedOrder = new List<int>();
            fixedOrder.Add(0);
            List<Vertex> curVertexes = new List<Vertex>();
            Vertex top = new Vertex(task, fixedOrder);
            curVertexes.Add(top);
            while (curVertexes.Count() != 0)
            {
                numSteps++;
                branchingAlg.getParentNextVertexes(task, curVertexes);
                Selection.getSelection(curVertexes, lowScoreAlg, topScoreAlg);
            }
            if (tempMin == -1)
            {
                return null;
            }
            bestSolution.setNumSteps(numSteps);
            bestSolution.setOptimum(topScoreAlg.getScore(task, bestSolution.getOrderNumber()));
            bestSolution.setOrder(topScoreAlg.getExtendOrder());
            bestSolution.setNumBranches(branchingAlg.getNumOfBranches());
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
                Solution result = runMVG(task);
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

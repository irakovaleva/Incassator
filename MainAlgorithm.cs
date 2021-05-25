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
        public static bool runBinarySearch = true;
        public static long timeMVG;
        public static long timeBinary;

        public static Task openTask(string fileName)
        {
            lowScoreAlg = new LowScore();
            topScoreAlg = new TopScore();
            branchingAlg = new RealisticAlg();
            globalMin = -1;
            tempMin = -1;
            Task task = new Task(fileName);
            bool check = task.checkForTriangleRuleAndCorrect();
            return task;
        }

        public static int getSolution(Task task)
        {
            int bestSolutionIndex = 0;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Solution solution = runMVG(task);
            watch.Stop();
            timeMVG = watch.ElapsedMilliseconds;
            allSolutions.Add(solution);
            globalMin = tempMin;
            if (runBinarySearch)
            {
                int anotherSolutionIndex = MainAlgorithm.binarySearch(task);
                if (anotherSolutionIndex != -1)
                {
                    bestSolutionIndex = anotherSolutionIndex;
                }
            }
            return bestSolutionIndex;
        }

        public static Solution runMVG(Task task)
        {
            Selection.minTopScore = -1;
            Selection.tree = new BinaryTree();
            bestSolution = new Solution(task);
            int numSteps = 0;
            List<int> fixedOrder = new List<int>();
            fixedOrder.Add(0);
            List<Vertex> curVertexes = new List<Vertex>();
            Vertex top = new Vertex(task, fixedOrder);
            curVertexes.Add(top);
            //string writePath = @"D:\Anya\log.txt";
            //Selection.sw = new System.IO.StreamWriter(writePath, true, System.Text.Encoding.Default);
            while (curVertexes.Count() != 0)
            {
                numSteps++;
                int oldNumOfVertex = curVertexes.Count;
                branchingAlg.getParentNextVertexes(task, curVertexes);
                Selection.numOfNewVertexes = curVertexes.Count - oldNumOfVertex + 1;
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

        public static int binarySearch(Task task)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
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
            watch.Stop();
            timeBinary = watch.ElapsedMilliseconds;
            return solutionIndex;
        }

        public static string getTime(long time)
        {
            string result = "";
            if (time < 1000)
            {
                result = Convert.ToString(time) + "ms";
            }
            else if (time < 100000)
            {
                int seconds = Convert.ToInt32(time) / 1000;
                int millisecond = Convert.ToInt32(time) - (seconds * 1000);
                result = Convert.ToString(seconds) + "s" + Convert.ToString(millisecond) + "ms";
            }
            else
            {
                long minute = time / 60000;
                long second = (time - (minute * 60000)) / 1000;
                long millisecond = time - (minute * 60000) - (second * 1000);
                result = Convert.ToString(minute) + "m" + Convert.ToString(second) + "s" + Convert.ToString(millisecond) + "ms";
            }
            return result;
        }
    }
}

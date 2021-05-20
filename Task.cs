using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Incassator
{
    public class Task
    {
        // Number of vertexes
        public int numOrders;
        // Number of locations (vertexes + start location (bank))
        public int numOfLocations;
        // Directive times for every vertex
        public int[] directiveTime;
        // Matrix of distance between vertexes
        public int[,] times;
        // Money that should be taken from the vertex
        public int[] profitOnVertex;
        // Money that we have initially
        public int initialSum;
        // Max value of directive times faults
        public int directiveFaultsMax;

        public Task(string fileName)
        {
            string info = File.ReadAllText(fileName);
            int counter = 0;
            int[] helpArray = info.Split(' ', '\t', '\n', '\r').Where(str => str != "").Select(n => Convert.ToInt32(n)).ToArray();
            numOrders = helpArray[counter];
            numOfLocations = numOrders + 1;
            counter++;
            directiveTime = new int[numOfLocations];
            directiveTime[0] = 0;
            for (int i = 1; i < numOfLocations; i++)
            {
                directiveTime[i] = helpArray[counter];
                counter++;
            }
            times = new int[numOfLocations, numOfLocations];
            for (int i = 0; i < numOfLocations; i++)
            {
                for (int j = 0; j < numOfLocations; j++)
                {
                    times[i, j] = helpArray[counter];
                    counter++;
                }
                
            }
            profitOnVertex = new int[numOfLocations];
            profitOnVertex[0] = 0;
            for (int i = 1; i < numOfLocations; i ++)
            {
                profitOnVertex[i] = helpArray[counter];
                counter++;
            }
            initialSum = helpArray[counter];
            directiveFaultsMax = numOrders;
        }

        // Сhecks that the task meets the triangle condition (dist(i -> j) <= dist (i -> k -> j) and correct if it is false
        public bool checkForTriangleRuleAndCorrect()
        {
            bool result = true;
            for (int i = 0; i < numOfLocations - 1; i++)
            {
                for (int j = i + 1; j < numOfLocations; j++)
                {
                    int curDist = this.times[i, j];
                    for (int k = 0; k < numOfLocations; k++)
                    {
                        if (k != j && k != i)
                        {
                            int anotherDist = this.times[i, k] + this.times[k, j];
                            if (anotherDist <= curDist)
                            {
                                result = false;
                                this.times[i, j] = anotherDist - 1;
                                this.times[j, i] = anotherDist - 1;
                            }
                        }
                    }
                }
            }
            return result;
        }
    }

    //public class TimeSafetyValues
    //{
    //    public int directiveTimesFaults;
    //    public int summaryTime;
    //    public int safety;

    //    public TimeSafetyValues()
    //    {
    //        directiveTimesFaults = 0;
    //        summaryTime = 0;
    //        safety = 0;
    //    }
    //}
}

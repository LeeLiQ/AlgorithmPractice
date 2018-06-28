using System;
using System.Collections.Generic;

namespace class_schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = CanFinish(2, new int[,] { { 0, 1 } });
            Console.WriteLine(result);
        }

        private static bool CanFinish(int numCourses, int[,] prerequisites)
        {
            if (numCourses <= 0)
                return false;

            var graph = new List<int>[numCourses];

            for (var i = 0; i < graph.Length; i++)
                graph[i] = new List<int>();

            var finishedCourses = 0;

            var inDegree = new int[numCourses];

            var canFinish = new Queue<int>();

            for (var i = 0; i < prerequisites.GetLength(0); i++)
            {
                var toDo = prerequisites[i, 0];
                var firstNeedTo = prerequisites[i, 1];
                inDegree[toDo]++;
                graph[firstNeedTo].Add(toDo);
            }

            for (var i = 0; i < inDegree.Length; i++)
                if (inDegree[i] == 0)
                    canFinish.Enqueue(i);

            while (canFinish.Count != 0)
            {
                var curCourse = canFinish.Dequeue();
                finishedCourses++;

                foreach (var dependent in graph[curCourse])
                {
                    inDegree[dependent]--;
                    if (inDegree[dependent] == 0)
                        canFinish.Enqueue(dependent);
                }
            }

            return finishedCourses == numCourses;
        }
    }
}

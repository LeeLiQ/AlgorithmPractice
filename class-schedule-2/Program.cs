using System;
using System.Collections.Generic;

namespace class_schedule_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = FindOrder(2, new int[,] { { 0, 1 } });
        }

        public static int[] FindOrder(int numCourses, int[,] prerequisites)
        {
            var result = new List<int>();
            if (numCourses <= 0)
                return result.ToArray();
            if (numCourses > 0 && prerequisites.GetLength(0) == 0)
            {
                var temp = new int[numCourses];
                for (var i = numCourses - 1; i >= 0; i--)
                    temp[i] = i;
                return temp;
            }

            var inDegree = new int[numCourses];

            var courseRel = new List<int>[numCourses];
            for (var i = 0; i < numCourses; i++)
                courseRel[i] = new List<int>();

            var readyCourse = new Queue<int>();
            for (var i = 0; i < prerequisites.GetLength(0); i++)
            {
                var course = prerequisites[i, 0];
                var pre = prerequisites[i, 1];
                inDegree[course]++;
                courseRel[pre].Add(course);
            }

            for (var i = 0; i < numCourses; i++)
                if (inDegree[i] == 0)
                    readyCourse.Enqueue(i);
            var finished = 0;
            while (readyCourse.Count != 0)
            {
                var course = readyCourse.Dequeue();
                result.Add(course);
                finished++;
                foreach (var elem in courseRel[course])
                {
                    inDegree[elem]--;
                    if (inDegree[elem] == 0)
                        readyCourse.Enqueue(elem);
                }
            }

            if (finished != numCourses)
                return new int[0];
            else
                return result.ToArray();
        }
    }
}

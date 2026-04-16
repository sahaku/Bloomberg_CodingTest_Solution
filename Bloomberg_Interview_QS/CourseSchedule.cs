using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
     public class CourseSchedule
    {
        public int[] CanFinish(int numCourses, int[][] prerequisites)
        {
            var graph = new List<int>[numCourses];
            var indegree = new int[numCourses];

            for (int i = 0; i < numCourses; i++)
                graph[i] = new List<int>();

            foreach (var p in prerequisites)
            {
                int course = p[0], pre = p[1];
                graph[pre].Add(course);
                indegree[course]++;
            }

            var q = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
                if (indegree[i] == 0)
                    q.Enqueue(i);

            int taken = 0;
            var order = new List<int>();

            while (q.Count > 0)
            {
                int cur = q.Dequeue();
                order.Add(cur);

                foreach (var next in graph[cur])
                {
                    indegree[next]--;
                    if (indegree[next] == 0)
                        q.Enqueue(next);
                }
            }

            return order.Count==numCourses? order.ToArray():(new List<int>()).ToArray();
        }
    }

}

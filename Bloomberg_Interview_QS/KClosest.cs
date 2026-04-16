using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class KClosestProblem
    {

        public int[][] KClosest(int[][] points, int k)
        {
            // Max-heap: store (distance, point)
            var pq = new PriorityQueue<int[], int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

            foreach (var p in points)
            {
                int dist = p[0] * p[0] + p[1] * p[1];

                // Push point with priority = distance
                pq.Enqueue(p, dist);

                // If heap grows beyond k, remove the farthest point
                if (pq.Count > k)
                    pq.Dequeue();
            }

            // Extract K closest points
            var result = new int[k][];
            for (int i = 0; i < k; i++)
                result[i] = pq.Dequeue();

            return result;

        }
    }
}

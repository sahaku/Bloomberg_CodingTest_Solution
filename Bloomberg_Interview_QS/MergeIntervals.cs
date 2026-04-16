using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return intervals;

            // Step 1: Sort by start time
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            var result = new List<int[]>();
            int[] current = intervals[0];

            foreach (var interval in intervals)
            {
                // If overlapping: merge
                if (interval[0] <= current[1])
                {
                    current[1] = Math.Max(current[1], interval[1]);
                }
                else
                {
                    // No overlap: push current and move on
                    result.Add(current);
                    current = interval;
                }
            }

            // Add the last interval
            result.Add(current);

            return result.ToArray();
        }
    }
}

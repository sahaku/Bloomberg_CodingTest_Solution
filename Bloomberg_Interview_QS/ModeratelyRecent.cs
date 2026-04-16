using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    
    public class ModeratelyRecent
    {
        public int FindMostRecentCommon(List<List<int>> lists)
        {
            int k = lists.Count;
            int[] idx = new int[k];
            int result = -1;

            while (true)
            {
                // Check if any list is exhausted
                for (int i = 0; i < k; i++)
                {
                    if (idx[i] >= lists[i].Count)
                        return result;
                }

                // Read current values
                int minVal = int.MaxValue;
                int maxVal = int.MinValue;

                for (int i = 0; i < k; i++)
                {
                    int val = lists[i][idx[i]];
                    minVal = Math.Min(minVal, val);
                    maxVal = Math.Max(maxVal, val);
                }

                // If all equal → common timestamp
                if (minVal == maxVal)
                {
                    result = minVal; // or maxVal, same
                    for (int i = 0; i < k; i++)
                        idx[i]++;

                    continue;
                }

                // Otherwise advance the pointer(s) with the smallest value
                for (int i = 0; i < k; i++)
                {
                    if (lists[i][idx[i]] == minVal)
                        idx[i]++;
                }
            }
        }

      
    }

}

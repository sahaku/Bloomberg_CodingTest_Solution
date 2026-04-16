using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class KMostFrequentElements
    {
        public int[] KTopFrequentElements(int[] nums, int k)
        {
            var freq = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (!freq.ContainsKey(num))
                {
                    freq[num] = 0;
                }
                freq[num]++;
            }

            var pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));
            foreach (var f in freq)
            {
                pq.Enqueue(f.Key, f.Value);

                if (pq.Count > k)
                    pq.Dequeue();
            }
            var result = new int[k];

            for(int i=0;i<k; i++)
            {
                result[i] = pq.Dequeue();
            }

            return result;
        }

        
    }
}

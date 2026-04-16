using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class Subarrays
    {
        //nums = [2, -1, 1, 2], k = 2
        public int SubarraySum(int[] nums, int k)
        {
            var prefixCount = new Dictionary<int, int>();
            prefixCount[0] = 1; // prefix sum 0 occurs once (empty prefix)

            int sum = 0;
            int result = 0;

            foreach (int num in nums)
            {
                sum += num;

                int needed = sum - k;
                if (prefixCount.ContainsKey(needed))
                    result += prefixCount[needed];

                if (!prefixCount.ContainsKey(sum))
                    prefixCount[sum] = 0;

                prefixCount[sum]++;
            }

            return result;
        }

    }
}

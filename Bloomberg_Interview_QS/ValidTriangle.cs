using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class ValidTriangle
    {
        public int TriangleNumber(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int count = 0;

            for (int k = n - 1; k >= 2; k--)
            {
                int i = 0;
                int j = k - 1;
                while (i < j)
                {
                    if (nums[i] + nums[j] > nums[k])
                    {
                        count += (j - i);
                        j--;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return count;
        }
    }
}

   

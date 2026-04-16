using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class MergedSortedList
    {
        public void MergeLists(int[] nums1, int[] nums2, int m, int n)
        {
            
            int k = m + n - 1;
            int i = m - 1;
            int j= n - 1;

            while (j >= 0)
            {
                if(i>=0 && nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    j--;
                }
                k--;
            }
        }
    }
}

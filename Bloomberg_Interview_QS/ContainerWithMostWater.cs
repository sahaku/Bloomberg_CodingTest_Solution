using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int maxArea = 0;

            while (left < right)
            {
                var h = Math.Min(height[left], height[right]);
                var w = right - left;
                var area = h * w;
                maxArea = Math.Max(maxArea, area);
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }

            }

            return maxArea;
        }
    }
}

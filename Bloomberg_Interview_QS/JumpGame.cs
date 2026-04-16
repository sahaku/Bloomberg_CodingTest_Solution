using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
  
    public class JumpGame
    {
        //2   3   1   1   4
        public bool CanJump(int[] nums)
        {
            int maxReach = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > maxReach)
                {
                    return false;
                }
                maxReach = Math.Max(maxReach, i + nums[i]);
                if (maxReach >= nums.Length - 1)
                {
                    return true;
                }
            }
            return true;
        }
    }

}

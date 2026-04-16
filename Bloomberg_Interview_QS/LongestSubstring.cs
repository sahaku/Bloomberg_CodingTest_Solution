using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var lastSeen = new Dictionary<char, int>();
            int left = 0;
            int maxLen = 0;

            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];

                // If we've seen this char and it's inside the current window
                if (lastSeen.ContainsKey(c) && lastSeen[c] >= left)
                {
                    left = lastSeen[c] + 1; // shrink window
                }

                lastSeen[c] = right; // update last seen index

                maxLen = Math.Max(maxLen, right - left + 1);
            }

            return maxLen;
        }

    }
}

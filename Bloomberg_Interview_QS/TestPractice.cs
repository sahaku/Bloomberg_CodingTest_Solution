using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class TestPractice
    {
        public int[] KTopMostFreq(int[] nums,int k)
        {
            var freq = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            { 
                if(!freq.ContainsKey(nums[i]))
                {
                    freq[nums[i]] = 0;
                }
                freq[nums[i]]++;
            }

            var pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));
            var result = new int[k];

            foreach (var f in freq)
            {
                pq.Enqueue(f.Key,f.Value);

                if (pq.Count > k)
                    pq.Dequeue();
            }
            for (int i = 0;i < k; i++)
            {
                var p = pq.Dequeue();
                result[i] = p;
            }
            return result;
        }

        public int LongestSubstring(string s)
        {
            int left = 0;
            int maxLen = 0;
            var lastSeen = new Dictionary<char, int>();

            for(int right = 0; right < s.Length; right++)
            {
                var c = s[right];
                if(lastSeen.ContainsKey(c))
                {
                    left += lastSeen[c] + 1;
                }
                lastSeen[c] = right;
                maxLen = Math.Max(maxLen, right - left + 1);
               
            }
            return maxLen;
        }

        public bool CanAttendTheMeeting11(int[][] meetings)
        {
            Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));
            var prevEnd = meetings[0][1];
            var pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));
            //pq.Enqueue()
            pq.Enqueue(prevEnd, prevEnd);
            for (int i = 1; i < meetings.Length; i++)
            {
                var start = meetings[i][0];
                var end = meetings[i][1];

                if (start < prevEnd)
                    return false;

                pq.Enqueue(end, end);

               
            }
            return true;
        }

        //[ [0, 5], [5, 10] ]
        //[[1,30],[20,40][30.45]]
        public int MinMeetingRoomII(int[][] meetings)
        {
            Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));
            
            var pq = new PriorityQueue<int, int>();
            
            pq.Enqueue(meetings[0][1], meetings[0][1]);
            for (int i = 1; i < meetings.Length; i++)
            {
                var start = meetings[i][0];
                var end = meetings[i][1];

                if (pq.TryPeek(out int _earliestEnd, out _) && _earliestEnd <= start)
                {
                    pq.Dequeue();
                }


                pq.Enqueue(end, end);


            }
            return pq.Count;
        }

        //[1,3] and [2,6],[7,10]
        //[1,3], [4,6],[5,7]

        //step 0->
        public int[][] MergeInterval(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            var current = intervals[0];
            var result = new List<int[]>();

            foreach(var interval in intervals)
            {
                if (current[1] >= interval[0])
                {
                    current[1] = Math.Max(current[1], interval[1]);
                }
                else
                {
                    result.Add(current);
                    current = interval;
                }

            }
            result.Add(current);
            return result.ToArray();
        }

        public IList<List<int>> BinaryOrderLevel(TreeNode root)
        {
            var result = new List<List<int>>();
            if(root == null)
                return result;

            var q=new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var levelSize = q.Count;
                var level = new List<int>();
                for(int i=0; i<levelSize;i++)
                {
                    var node = q.Dequeue();
                    level.Add(node.Value);

                    if (node.Left!=null)
                    {
                        q.Enqueue(node.Left);
                    }

                    if(node.Right!=null)
                    {
                        q.Enqueue(node.Right);
                    }
                }
                result.Add(level);
            }
    }
}

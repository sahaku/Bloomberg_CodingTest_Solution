using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bloomberg_Interview_QS
{
    public class Practice
    {
        public int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return intervals;

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            var current = intervals[0];
            var result = new List<int[]>();

            foreach (var interval in intervals)
            {
                if (interval[0] <= current[1])
                {
                    current[1] = Math.Max(current[1], interval[1]);
                }
                else
                {
                    result.Add(interval);
                    current = interval;
                }
            }

            result.Add(current);

            return result.ToArray();
        }

        public bool FindDupsMeeting(int[][] intervals)
        {

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            var preEnd = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
            {
                var start = intervals[i][0];
                var end = intervals[i][1];

                if (start < preEnd)
                    return false;

                preEnd = end;
            }

            return true;
        }

        public int MinMeetingRooms(int[][] intervals)
        {

            if (intervals == null || intervals.Length == 0)
                return 0;

            var minHeap = new PriorityQueue<int, int>();
            minHeap.Enqueue(intervals[0][1], intervals[0][1]);

            for (int i = 1; i < intervals.Length; i++)
            {
                var start = intervals[i][0];
                var end = intervals[i][1];

                if (minHeap.TryPeek(out int earliestEnd, out _) && earliestEnd <= start)
                {
                    minHeap.Dequeue();
                }
                minHeap.Enqueue(end, end);
            }

            return minHeap.Count;
        }

        public int LogestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var lastSeen = new Dictionary<char, int>();
            int left = 0;
            int right = 0;
            int maxLen = 0;
            string substring = string.Empty;

            for (right = 0; right < s.Length; right++)
            {
                char c = s[right];
                if (lastSeen.ContainsKey(c)
                    //&& lastSeen[c] <= left
                    )
                {
                    left = lastSeen[c] + 1;
                    var tempstring = substring.Replace(c.ToString(), "");
                    substring = tempstring + c.ToString();
                }
                else
                {
                    substring += c.ToString();
                }
                lastSeen[c] = right;

                maxLen = Math.Max(maxLen, right - left + 1);


            }
            Console.WriteLine(substring);
            return maxLen;
        }

        public int SubarraySum(int[] nums, int k)
        {
            int sum = 0;
            Dictionary<int, int> prefixCount = new Dictionary<int, int>();
            prefixCount[0] = 1;
            //int need = 0;
            int result = 0;

            foreach (var num in nums)
            {
                sum += num;
                int needed = sum - k;

                if (prefixCount.ContainsKey(needed))
                {
                    result += prefixCount[needed];
                }

                if (!prefixCount.ContainsKey(sum))
                {
                    prefixCount[sum] = 0;
                    prefixCount[sum]++;
                }
            }

            return result;
        }

        public string DecodeString(string s)
        {
            if (s == null)
                return s;

            Stack<int> countStack = new Stack<int>();
            Stack<string> stringStack = new Stack<string>();
            int currentNum = 0;
            string currentStr = string.Empty;
            string previousStr = string.Empty;

            foreach (char c in s)
            {
                if (Char.IsDigit(c))
                {
                    int.TryParse(c.ToString(), out int num);
                    currentNum = num;
                }
                else if (c == '[')
                {
                    stringStack.Push(currentStr);
                    countStack.Push(currentNum);
                    currentNum = 0;
                    currentStr = string.Empty;
                }
                else if (c == ']')
                {
                    currentNum = countStack.Pop();
                    previousStr = stringStack.Pop();
                    currentStr = previousStr + string.Concat(Enumerable.Repeat(currentStr, currentNum));
                }
                else
                {
                    currentStr += c.ToString();
                }
            }
            return currentStr;
        }

        public int[][] KClosest(int[][] points, int k)
        {
            var pQueue = new PriorityQueue<int[], int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

            foreach (var p in points)
            {
                int dist = p[0] * p[0] + p[1] * p[1];
                pQueue.Enqueue(p, dist);

                if (pQueue.Count > k)
                {
                    pQueue.Dequeue();
                }
            }

            var result = new int[k][];
            for (int i = 0; i < k; i++)
            {
                result[i] = pQueue.Dequeue();
            }
            return result;
        }

        public int[] CanFinish(int numCourses, int[][] prerequisites)
        {
            var graph = new List<int>[numCourses];
            var inDegrees = new int[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var p in prerequisites)
            {
                int course = p[0];
                int pre = p[1];
                graph[pre].Add(course);
                inDegrees[course]++;
            }
            var q = new Queue<int>();
            var order = new List<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (inDegrees[i] == 0)
                {
                    q.Enqueue(i);
                }
            }

            while (q.Count > 0)
            {
                int cure = q.Dequeue();
                order.Add(cure);

                foreach (var next in graph[cure])
                {
                    inDegrees[next]--;
                    if (inDegrees[next] == 0)
                    {
                        q.Enqueue(next);
                    }

                }
            }
            return order.Count == numCourses ? order.ToArray() : (new List<int>()).ToArray();
        }

        public IList<IList<int>> OrderLevel(TreeNodeLevel root)
        {
            var result = new List<IList<int>>();

            if (root == null)
                return result;
            var queue = new Queue<TreeNodeLevel>();
            queue.Enqueue(root);
            while ((queue.Count > 0))
            {
                int levelSize = queue.Count;
                var level = new List<int>();
                for (int i = 0; i < levelSize; i++)
                {
                    var node = queue.Dequeue();
                    level.Add(node.Value);
                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }
                }
                result.Add(level);

            }

            return result;
        }

        public ListNode AddTwoNumber(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);
            ListNode current = dummy;
            int carry = 0;
            while (l1 != null || l2 != null || carry > 0)
            {
                int x = l1 != null ? l1.val : 0;
                int y = l2 != null ? l2.val : 0;
                int sum = x + y + carry;
                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;
                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }

            return dummy.next;
        }

        public bool CanReachTarget(char[][] grid, int startFuel, int fuelGain)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int sr = 0;
            int sc = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 'S')
                    {
                        sr = i;
                        sc = j;
                        break;
                    }
                }
            }
            var bestFuel = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                bestFuel[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    bestFuel[i][j] = -1;
                }
            }

            var q = new Queue<(int r, int c, int fuel)>();
            q.Enqueue((sr, sc, startFuel));
            while (q.Count > 0)
            {
                var (r, c, fuel) = q.Dequeue();
                if (grid[r][c] == 'T')
                {
                    return true;
                }
                TryMove(grid, r + 1, c, fuel, bestFuel, fuelGain, q);
            }
            return false;
        }
        private void TryMove(char[][] grid, int nr, int nc, int fuel, int[][] bestFuel, int fuelGain, Queue<(int r, int c, int fuel)> q)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            if (nr < 0 || nc < 0 || nr >= rows || nc >= cols || grid[nr][nc] == '#')
            {
                return;
            }
            int newFuel = fuel - 1;
            if (newFuel < 0)
                return;

            if (grid[nr][nc] == 'F')
            {
                newFuel += fuelGain;
            }
            if (newFuel > bestFuel[nr][nc])
            {
                bestFuel[nr][nc] = newFuel;
                q.Enqueue((nr, nc, newFuel));
            }
        }
        public bool SamePersonCanAttendAllMeeting(int[][] meetingIntervals)
        {
            if (meetingIntervals == null || meetingIntervals.Length <= 1)
                return true;

            Array.Sort(meetingIntervals, (a, b) => a[0].CompareTo(b[0]));
            int prevEnd = meetingIntervals[0][1];

            for (int i = 1; i < meetingIntervals.Length; i++)
            {
                int start = meetingIntervals[i][0];
                int end = meetingIntervals[i][1];

                if (start < prevEnd)
                {
                    return false;

                }
                prevEnd = end;
            }
            return true;

        }

        public int MinMeetingRoomRequired(int[][] meetingIntervals)
        {
            if (meetingIntervals == null || meetingIntervals.Length == 0)
            {
                return 0;
            }
            Array.Sort(meetingIntervals, (a, b) => a[0].CompareTo(b[0]));
            var minHeap = new PriorityQueue<int, int>();
            minHeap.Enqueue(meetingIntervals[0][1], meetingIntervals[0][1]);

            for (var i = 1; i < meetingIntervals.Length; i++)
            {
                int start = meetingIntervals[i][0];
                int end = meetingIntervals[i][1];

                if (minHeap.TryPeek(out int prevEnd, out _) && prevEnd <= start)
                {
                    minHeap.Dequeue();
                }
                minHeap.Enqueue(end, end);
            }
            return minHeap.Count;
        }

        public string LongestSubstringWithoutRepeatingCharacters(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            var lastSeen = new Dictionary<char, int>();
            int maxLen = 0;
            int left = 0;
            int bestStart = 0;
            string longestSubstr = string.Empty;

            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];

                if (lastSeen.ContainsKey(c) && lastSeen[c] >= left)
                {
                    left = lastSeen[c] + 1;
                    longestSubstr = longestSubstr + c.ToString();
                    //longestSubstr = longestSubstr.Replace(c.ToString(), "") + c.ToString();
                }
                else
                {
                    longestSubstr = longestSubstr + c.ToString();
                }
                lastSeen[c] = right;
                int currentLen = right - left + 1;
                if (currentLen > maxLen)
                    bestStart = left;

                maxLen = Math.Max(maxLen, right - left + 1);

            }

            Console.WriteLine($"Length of longest substring without repeating characters: {maxLen}");

            return longestSubstr.Substring(bestStart, maxLen);
        }

        public int SubarraySumEqualsK(int[] nums, int k)
        {
            int sum = 0;
            var prefixCount = new Dictionary<int, int>();
            prefixCount[0] = 1;
            int result = 0;

            foreach(var num in nums)
            {
                sum += num;
                int needed = sum - k;

                if(prefixCount.ContainsKey(needed))
                {
                    result += prefixCount[needed];
                }

                if(!prefixCount.ContainsKey(sum))
                {
                    prefixCount[sum] = 0;
                }
                prefixCount[sum]++;
            }
            return result;
        }

        public int[][] KClosestToOrigin(int[][] points, int k)
        {
            var pq = new PriorityQueue<int[], int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

            foreach(var point in points)
            {
                int dist = point[0] * point[0] + point[1] * point[1];
                pq.Enqueue(point, dist);

                if (pq.Count > k)
                    pq.Dequeue();
            }

            var result = new int[k][];

            for(int i=0;i<k;i++)
            {
                result[i] = pq.Dequeue();
            }

            return result;
        }

        public int[] KMostFrequentElements(int[] nums, int k)
        {
            var freq = new Dictionary<int, int>();
            var pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));

            foreach(var num in nums)
            {
                if(!freq.ContainsKey(num))
                {
                    freq[num] = 0;
                }
                freq[num]++;
            }
            foreach (var f in freq)
            {
                pq.Enqueue(f.Key, f.Value);

                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }

            var result = new int[k];
            for(int i=0;i<k;i++)
            {
                result[i] = pq.Dequeue();
            }

            return result;
        }

        public int TotalIslands(char[][] grid)
        {
            int count = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            for(int i=0;i<rows;i++)
            {
                for (int j=0;j< cols;j++)
                {
                    if (grid[i][j]=='1')
                    {
                        count++;
                        DFSearch(grid, i, j);
                    }
                }
            }
            return count;
        }

        public void DFSearch(char[][] grid, int r, int c)
        {
            if (r < 0 || c < 0 || r >= grid.Length || c >= grid[0].Length || grid[r][c] == '0')
                return;
            grid[r][c] = '0';
            DFSearch(grid, r + 1, c);
            DFSearch(grid, r - 1, c);
            DFSearch(grid, r, c + 1);
            DFSearch(grid, r, c - 1);
        }

        public int AreaContainerWithMostWater(int[] heights)
        {
            int left = 0;
            int maxArea = 0;
            int right = heights.Length - 1;

            while (left < right)
            {
                int h = Math.Min(heights[left], heights[right]);
                int w = right - left;
                int area = h * w;
                maxArea = Math.Max(area, maxArea);
                if (heights[left] < heights[right])
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

        public bool WordSearch(char[][]grid, string word)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    if (DFWordSearch(grid, i, j, 0, word))
                    {
                        return true;
                    }    
                }
            }
            return false;
        }

        private bool DFWordSearch(char[][]grid, int r, int c, int index, string word)
        {
            if (index == word.Length)
                return true;

            if (r < 0 || c < 0 || r >= grid.Length || c >= grid[0].Length)
                return false;

            var temp = grid[r][c];
            grid[r][c] = '#';

            var found = DFWordSearch(grid, r + 1, c, index + 1, word) ||
                DFWordSearch(grid, r - 1, c, index + 1, word) ||
                DFWordSearch(grid, r, c + 1, index + 1, word) ||
                DFWordSearch(grid, r, c - 1, index + 1, word);

            grid[r][c] = temp;

            return found;
        }

        public bool JumpGameMaxReach(int[] nums)
        {
            int maxReach = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > maxReach)
                {
                    return false;
                }
                maxReach = Math.Max(maxReach, i + nums[i]);
            }
            return true;
        }
    }
}
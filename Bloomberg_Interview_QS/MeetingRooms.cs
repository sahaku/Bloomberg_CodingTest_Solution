using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class MeetingRooms
    {
        public bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals == null || intervals.Length <= 1)
                return true;

            // Sort by start time
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            int prevEnd = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
            {
                int start = intervals[i][0];
                int end = intervals[i][1];

                // Overlap if current start < previous end
                if (start < prevEnd)
                    return false;

                prevEnd = end;
            }

            return true;
        }

        public int MinMeetingRoomsII(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return 0;

            // Sort by start time
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            // Min-heap of end times
            var minHeap = new PriorityQueue<int, int>();

            // Add first meeting's end time
            minHeap.Enqueue(intervals[0][1], intervals[0][1]);

            for (int i = 1; i < intervals.Length; i++)
            {
                int start = intervals[i][0];
                int end = intervals[i][1];

                // If the earliest ending meeting is done before this starts, reuse that room
                if (minHeap.TryPeek(out int earliestEnd, out _)
                    && earliestEnd <= start)
                {
                    minHeap.Dequeue();
                }

                // Allocate (or reuse) room for current meeting
                minHeap.Enqueue(end, end);
            }

            // Number of rooms needed is the number of concurrent meetings at peak
            return minHeap.Count;
        }
    }
    public class MeetingRoomsII
    {
        public int MinMeetingRoomsII(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return 0;

            // Sort by start time
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            // Min-heap of end times
            var minHeap = new PriorityQueue<int, int>();

            // Add first meeting's end time
            minHeap.Enqueue(intervals[0][1], intervals[0][1]);

            for (int i = 1; i < intervals.Length; i++)
            {
                int start = intervals[i][0];
                int end = intervals[i][1];

                // If the earliest ending meeting is done before this starts, reuse that room
                if (minHeap.TryPeek(out int earliestEnd, out _)
                    && earliestEnd <= start)
                {
                    minHeap.Dequeue();
                }

                // Allocate (or reuse) room for current meeting
                minHeap.Enqueue(end, end);
            }

            // Number of rooms needed is the number of concurrent meetings at peak
            return minHeap.Count;
        }
    }

}

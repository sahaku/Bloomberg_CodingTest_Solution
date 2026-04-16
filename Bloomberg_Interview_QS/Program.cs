using Bloomberg_Interview_QS;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

int[][] intervals = new int[][]
{
    new int[] {5, 10},
    new int[] {10, 20},
    new int[] {20, 30}
};
var s = "shashtee";
int[] nums=new int[] {10,2,3,10, 4,5,6,7,5};
int k=8;
string s1 = "3[a2[c]]";
int[][] points = [[3, 3], [5, -1], [-2, 4]];
k = 3;

char[][] grid = new char[][]
        {
            new char[] { '1', '1', '0', '0', '0' },
            new char[] { '1', '1', '0', '0', '0' },
            new char[] { '0', '0', '1', '0', '0' },
            new char[] { '0', '0', '0', '1', '1' }
        };

int numCourses = 4;
int[][] prerequisites = new int[][] 
{ 
 new int[] { 1, 0 },
 new int[] { 2, 0 }, 
new int[] { 3, 1 }, 
new int[] { 3, 2 } 
};

var lists = new List<List<int>>
        {
            new List<int> {1, 4, 7, 10},
            new List<int> {2, 4, 6, 10},
            new List<int> {3, 4, 8, 10}
        };

var practice = new Practice();
//var mergedIntervals = merger.Merge(intervals);
//foreach (var inter in mergedIntervals)
//{
//    Console.WriteLine($"[{inter[0]}, {inter[1]}]");
//}

//Console.WriteLine("Practice's version output");
//var practice = new Practice();
//var results=practice.Merge(intervals);
//foreach (var inter in results)
//{
//    Console.WriteLine($"[{inter[0]}, {inter[1]}]");
//}
//var meetings=new MeetingRooms();
//var result=meetings.CanAttendMeetings(intervals);
//Console.WriteLine($"Can attend meetings: {result}");
//var minRooms=meetings.MinMeetingRoomsII(intervals);
//Console.WriteLine($"Minimum meeting rooms needed: {minRooms}");
//var minRoomPractice=practice.MinMeetingRooms(intervals);
//Console.WriteLine($"Minimum meeting rooms needed(Practice): {minRoomPractice}");
//var longestSubstring = new LongestSubstring();
//var result=longestSubstring.LengthOfLongestSubstring(s);

//Console.WriteLine(result);
//var results=practice.LogestSubstring(s);
//Console.WriteLine(results);

//var subArraysum=new Subarrays();
//var result = subArraysum.SubarraySum(nums, k);
//Console.WriteLine(result);
//result= practice.SubarraySum(nums, k);
//Console.WriteLine($"practice result:{result}");

//var decodingString = new DecodingString();
//var decoded = decodingString.DecodeString(s1);
//Console.WriteLine($"Input:{s1}");
//Console.WriteLine(decoded);
//Console.WriteLine($"Decode Practice result;{practice.DecodeString(s1)}");
//var kClosest = new KClosestProblem();
//var closestPoints = kClosest.KClosest(points, k);
//Console.WriteLine($"K closest points to the origin:");
//foreach (var point in closestPoints)
//{
//    Console.WriteLine($"[{point[0]}, {point[1]}]");
//}
//var closestPointsPractice = practice.KClosest(points, k);

//Console.WriteLine($"K closest points to the origin(Practice):");
//foreach (var point in closestPointsPractice)
//{
//    Console.WriteLine($"[{point[0]}, {point[1]}]");
//}

//var kmostfreq=new KMostFrequentElements();
//var result=kmostfreq.KTopFrequentElements(nums, k);

//var island=new Islands();
//var numIslands = island.NumIslands(grid);
//Console.WriteLine(numIslands);

//var courseSchedule = new CourseSchedule();
//var canFinish = courseSchedule.CanFinish(numCourses, prerequisites);
//var canFinishPractice = practice.CanFinish(numCourses, prerequisites);
//Console.WriteLine($"Can finish all courses: {string.Join(",", canFinish)}");
//Console.WriteLine($"Can finish all courses (Practice): {string.Join(",", canFinishPractice)}");

//var moderatelyRecent = new ModeratelyRecent();
//Console.WriteLine(moderatelyRecent.FindMostRecentCommon(lists)); // Output: 10
ContainerWithMostWater containerWithMostWater = new ContainerWithMostWater();
int[] heiight = [1, 8, 6, 2, 5, 4, 8, 3, 7];
//int maxArea = containerWithMostWater.MaxArea(heiight);
//Console.WriteLine($"Max area of water container: {maxArea}");
char[][] board = [
  ['A','B','C'],
  ['D','E','F'],
  ['G','H','I']
];
string word = "ABEHI";
WordSearch wordSearch = new WordSearch();
//bool exists = wordSearch.Exist(board, word);
//Console.WriteLine(exists);

var root = new TreeNode(3,
    new TreeNode(9),
    new TreeNode(20,
        new TreeNode(15),
        new TreeNode(7)
    )
);
//var binaryTreeLevel = new BinaryTreeLevel();
//var levels = binaryTreeLevel.LevelOrder(root);
//foreach (var level in levels)
//{
//    Console.WriteLine(string.Join(", ", level));
//}


//var rootLevel = new TreeNodeLevel(3,
//    new TreeNodeLevel(9),
//    new TreeNodeLevel(20,
//        new TreeNodeLevel(15),
//        new TreeNodeLevel(7)
//    )
//);
//var levelps = practice.OrderLevel(rootLevel);
//foreach (var level in levelps)
//{
//    Console.WriteLine(string.Join(", ", level));
//}

ListNode l1 = new ListNode(2);
l1.next = new ListNode(4);
l1.next.next = new ListNode(3);

ListNode l2 = new ListNode(5);
l2.next = new ListNode(6);
l2.next.next = new ListNode(4);

LinkedList linkedList = new LinkedList();
//ListNode result = linkedList.AddTwoNumbers(l1, l2);

//while (result != null)
//{
//    Console.Write(result.val + " ");
//    result = result.next;
//}

//var mergeSortedList = new MergedSortedList();
//int[] nums1 = { 1, 2, 3, 0, 0, 0 };
//int m = 3;

//int[] nums2 = { 2, 5, 6 };
//int n = 3;

//mergeSortedList.MergeLists(nums1, nums2, m, n);
//Console.WriteLine($"Merged sorted list: {string.Join(",", nums1)}");

char[][] grid1= {
    new [] {'S','.','F'},
    new [] {'#','.','.'},
    new [] {'.','.','T'}
};

//bool ok = GridFuelPath.CanReachTarget_NoDirectionArrays(grid1, startFuel: 4, fuelGain: 3);
//Console.WriteLine(ok); // True
var captions = "Hello-world!! #1 video";
//var tag= TagGenerator.GenerateTag(captions,3);
//Console.WriteLine($"Generated tag: {tag}");
//Merge Intervals
var numsss = new int[] { 2, 2, 3, 4 };
ValidTriangle validTriangle = new ValidTriangle();
//int triangleCount = validTriangle.TriangleNumber(numsss);
//Console.WriteLine(triangleCount);
int[][] intervals2 = [[0, 5], [5, 10], [10, 15]];
int[][] intervals3 = [[0, 30], [5, 10], [15, 20]];



//var result =practice.MinMeetingRoomRequired(intervals2);
//var result2= practice.MinMeetingRoomRequired(intervals3);

//Console.WriteLine($"Can attend all meetings (intervals2): {result}");
//Console.WriteLine($"Can attend all meetings (intervals3): {result2}");
//Console.WriteLine($"Practice result: {GenerateTag(captions)}");
//var subStr=practice.LongestSubstringWithoutRepeatingCharacters("abcabcbb");
var newNums = new int[] { 1, 2, 3 };
//Console.WriteLine(practice.SubarraySumEqualsK(newNums, 3));
//Console.WriteLine($"Longest substring:{subStr}");
var pointss = new int[][]{
new int[]{3, 3},
new int[]{5, -1 },
new int[] {-2, 4 },
new int[] {1, 1 },
new int[] {0, 2 }};
//var newResult= practice.KClosestToOrigin(pointss, 3);

//foreach (var point in newResult)
//{
//    Console.WriteLine($"Closest points: [{point[0]}, {point[1]}]");
//}
int[] knums = new int[] { 4, 4, 4, 6, 6, 1, 1, 1, 1, 2 };
//var topK= practice.KMostFrequentElements(knums, 3);
//Console.WriteLine($"Top K most frequent: {string.Join(", ", topK)}");
int[] waterHeights = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
//var waterArea = practice.AreaContainerWithMostWater(waterHeights);
//Console.WriteLine($"Expected water area:{waterArea}");
char[][] wordBoundary = new char[][] {
new char[]{ 'A' ,'B' ,'C', 'E' },
new char[]{ 'S' ,'F' ,'C', 'S' },
new char[]{ 'A' ,'D' ,'E', 'E' }

};
//var wordFound = practice.WordSearch(wordBoundary, "ABCCED");
//Console.WriteLine($"Word found: {wordFound}");
var jumpArray = new int[] {3, 2, 1, 0, 4
};

Console.WriteLine($"Found:{practice.JumpGameMaxReach(jumpArray)}");
Console.ReadKey();



HashSet<string> stopWords = new HashSet<string>
        {
            "a","an","and","or","but", "of", "to", "in", "with", "over","under",
            "from","into", "these","is","are","was","were","be","being","been","that", "this","those"
        };
string GenerateTag(string caption, int maxWords = 3)
{
    //1. Lowercase

    caption = caption.ToLowerInvariant();

    //2. Remove punctuation
    caption = Regex.Replace(caption, @"[^\w\s]", "");
    //3. Split into words
    var words = caption.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    //4. Remove stop words
    var filtered = words.Where(w => !stopWords.Contains(w)).ToList();
    if (filtered.Count == 0)
    {
        return string.Empty;
    }
    //5. Prefer words that look like nouns/verbs
    var meaningfulWords = filtered.Where(w => w.Length > 2).ToList();

    //6. Take top max words

    var selectedWords = meaningfulWords.Take(maxWords).ToList();

    return string.Join("_", selectedWords);
}
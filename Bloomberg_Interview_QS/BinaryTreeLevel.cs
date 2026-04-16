using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class TreeNode
    {
        public TreeNode Left {  get; set; }
        public TreeNode Right { get; set; }
        public int Value { get; set; }
        public TreeNode(int value=0,TreeNode left=null, TreeNode right=null)
        {
            Left = left;
            Right = right;
            Value = value;
        }
    }
    public class BinaryTreeLevel
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result=new List<IList<int>>();

            if(root==null) return result;
            var queue=new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count>0)
            {
                int levelSize=queue.Count;
                var level=new List<int>();
                for (int i = 0; i < levelSize; i++)
                { 
                    var node=queue.Dequeue();
                    level.Add(node.Value);
                    if(node.Left!=null)
                        queue.Enqueue(node.Left);
                    if(node.Right!=null)
                        queue.Enqueue(node.Right);
                }
                result.Add(level);
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class TreeNodeLevel
    {
        public int Value { get; set; }
        public TreeNodeLevel Left { get; set; }
        public TreeNodeLevel Right { get; set; }
        public TreeNodeLevel(int value=0, TreeNodeLevel left=null, TreeNodeLevel right=null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

    }
}

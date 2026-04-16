using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class MinStack
    {
        private Stack<int> stack;
        private Stack<int> minStack;
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);

            if(minStack.Count==0)
            {
                minStack.Push(x);
            }
            else
            {
                minStack.Push(Math.Min(x, minStack.Peek()));
            }
        }

        public void Pop()
        {
            if (stack.Count > 0)
            {
                Console.WriteLine($"Pop from main stack:{stack.Pop()}");
                Console.WriteLine($"Pop from minstack:{minStack.Pop()}");
            }
        }

        public int Top()
        {
            return stack.Pop();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }
}

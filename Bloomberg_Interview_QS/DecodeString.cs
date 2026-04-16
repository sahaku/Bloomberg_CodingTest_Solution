using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{

    public class DecodingString
    {
        public string DecodeString(string s)
        {
            Stack<int> countStack = new Stack<int>();
            Stack<string> stringStack = new Stack<string>();

            int currentNum = 0;
            string currentStr = "";

            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    int.TryParse(c.ToString(), out int digit);
                    //currentNum = currentNum * 10 + (c - '0');
                    currentNum=digit;
                }
                else if (c == '[')
                {
                    countStack.Push(currentNum);
                    stringStack.Push(currentStr);
                    currentNum = 0;
                    currentStr = "";
                }
                else if (c == ']')
                {
                    int repeat = countStack.Pop();
                    string prev = stringStack.Pop();

                    currentStr = prev + string.Concat(Enumerable.Repeat(currentStr, repeat));
                }
                else
                {
                    currentStr += c;
                }
            }

            return currentStr;
        }
    }

}

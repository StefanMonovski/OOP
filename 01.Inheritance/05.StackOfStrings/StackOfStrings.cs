using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Stack<string> AddRange(Stack<string> range)
        {
            while (range.Count > 0)
            {
                Push(range.Pop());
            }
            return this;
        }
    }
}

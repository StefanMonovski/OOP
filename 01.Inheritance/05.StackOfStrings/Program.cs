using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();
            string input = "";
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputData = input.Split();
                Stack<string> range = new Stack<string>(inputData);
                stackOfStrings.AddRange(range);
            }
            while (stackOfStrings.Count > 0)
            {
                Console.WriteLine($"Remove: {stackOfStrings.Pop()}");
                Console.WriteLine($"Is empty: {stackOfStrings.IsEmpty()}");
            }
        }
    }
}

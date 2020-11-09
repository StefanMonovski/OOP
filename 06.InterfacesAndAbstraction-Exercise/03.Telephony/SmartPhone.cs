using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    class SmartPhone : ICall, IBrowse
    {
        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }

        public void Browse(string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }
    }
}

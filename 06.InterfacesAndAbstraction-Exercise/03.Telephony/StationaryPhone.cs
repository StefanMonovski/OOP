using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    class StationaryPhone : ICall
    {
        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}

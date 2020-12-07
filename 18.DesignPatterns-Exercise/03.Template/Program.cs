using System;

namespace _03.Template
{
    class Program
    {
        static void Main(string[] args)
        {
            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();
            SourDough sourDough = new SourDough();
            sourDough.Make();
            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}

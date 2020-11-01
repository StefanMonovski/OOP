using System;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Lizard lizard = new Lizard(Console.ReadLine());
            Snake snake = new Snake(Console.ReadLine());
            Gorilla gorilla = new Gorilla(Console.ReadLine());
            Bear bear = new Bear(Console.ReadLine());
            Console.WriteLine(lizard.Name);
            Console.WriteLine(snake.Name);
            Console.WriteLine(gorilla.Name);
            Console.WriteLine(bear.Name);
        }
    }
}

using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person(Console.ReadLine(), int.Parse(Console.ReadLine()));
            bool isValidEntity = Validator.IsValid(person);
            Console.WriteLine(isValidEntity);
        }
    }
}

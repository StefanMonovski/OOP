using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Elf elf = new Elf(Console.ReadLine(), int.Parse(Console.ReadLine()));
            MuseElf museElf = new MuseElf(Console.ReadLine(), int.Parse(Console.ReadLine()));
            Wizard wizard = new Wizard(Console.ReadLine(), int.Parse(Console.ReadLine()));
            DarkWizard darkWizard = new DarkWizard(Console.ReadLine(), int.Parse(Console.ReadLine()));
            SoulMaster soulMaster = new SoulMaster(Console.ReadLine(), int.Parse(Console.ReadLine()));
            Knight knight = new Knight(Console.ReadLine(), int.Parse(Console.ReadLine()));
            DarkKnight darkKnight = new DarkKnight(Console.ReadLine(), int.Parse(Console.ReadLine()));
            BladeKnight bladeKnight = new BladeKnight(Console.ReadLine(), int.Parse(Console.ReadLine()));
            Console.WriteLine(elf);
            Console.WriteLine(museElf);
            Console.WriteLine(wizard);
            Console.WriteLine(darkWizard);
            Console.WriteLine(soulMaster);
            Console.WriteLine(knight);
            Console.WriteLine(darkWizard);
            Console.WriteLine(bladeKnight);
        }
    }
}

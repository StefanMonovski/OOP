using FestivalManager.Entities;
using System;

namespace _02.FestivalManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var song1 = new Song("Ветрове", new TimeSpan(0, 3, 30));
            var song2 = new Song("Бурни Нощи", new TimeSpan(0, 2, 30));

            var performer = new Performer("Ivan", "Ivanov", 19);
            Stage stage = new Stage();

            stage.AddSong(song1);
            stage.AddSong(song2);
            stage.AddPerformer(performer);

            Console.WriteLine(stage.AddSongToPerformer("Ветрове", "Ivan Ivanov"));
            Console.WriteLine(stage.Play());
        }
    }
}

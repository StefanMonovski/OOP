using System;

namespace _01.StreamProgressInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamProgressInfo fileStream = new StreamProgressInfo(new File("demoFile", 1250563, 45709));
            StreamProgressInfo musicStream = new StreamProgressInfo(new Music("demoArtist", "demoAlbum", 1837940, 649347));
            Console.WriteLine(fileStream.CalculateCurrentPercent());
            Console.WriteLine(musicStream.CalculateCurrentPercent());
        }
    }
}

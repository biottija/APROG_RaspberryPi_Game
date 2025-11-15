using System.Text;

namespace The_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(AsciiArt.logo);
            Console.WriteLine(AsciiArt.mario);
            Console.WriteLine(AsciiArt.marioF);

            Console.WriteLine("Welcome to The GAME!!!");
            Console.WriteLine("Press Enter when you see \"Click\" Appear");

            ReactionTester tester = new ReactionTester();
            if (tester.run())
            {
                Console.WriteLine($"\n--- Results ---");
                Console.WriteLine($"Time taken to press ENTER: {tester.PlayerOne.Points} ms");
                
                // PlayerOne.Points can be written to the file here.
                // ...

            }

        }
    }
}

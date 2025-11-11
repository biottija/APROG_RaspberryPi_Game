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
        }
    }
}

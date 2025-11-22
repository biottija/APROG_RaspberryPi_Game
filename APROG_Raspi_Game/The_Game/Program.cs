using System.Text;

namespace The_Game {
    internal class Program {
        static void Main(string[] args) {
            GameMode mode = parseArguments(args);
            if (mode == GameMode.None)
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Expected Input:  TheGame [method]");
                Console.WriteLine("[method]: console, raspberry");
                return;
            }

            TheGame game = new TheGame(mode);
            game.run();
        }

        static GameMode parseArguments(string[] args)
        {
            GameMode mode = GameMode.Console;
            if (args.Length == 0) 
            {
                return mode;
            }
            else if (args.Length == 1)
            {
                if (args[0].ToLower() == "raspberry")
                {
                    mode = GameMode.Raspberry;
                }
                else if (args[0].ToLower() == "console")
                {
                    mode = GameMode.Console;
                }
                else
                {
                    mode = GameMode.None;
                }
            }
            else
            {
                mode = GameMode.None;
            }
            return mode;
        }
    }
}

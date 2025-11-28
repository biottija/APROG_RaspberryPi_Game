using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Game
{
    public enum GameMode
    {
        None,
        Console,
        Raspberry
    }

    public class TheGame
    {
        private GameMode _mode;
        private string _scores;
        public TheGame(GameMode mode) 
        {
            _scores = "Scores.txt";
            _mode = mode;
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu.Print(_scores);
        }

        public IGame createReactionTester(GameMode mode, string playerName)
        {
            switch (mode)
            {
                case GameMode.Console:
                    return new ReactionTesterConsole(playerName);
                case GameMode.Raspberry:
                    return new ReactionTesterRaspberry(playerName);
                default:
                    return new ReactionTesterConsole(playerName);
            }
        }

        public void run()
        {

            while (true)
            {
                ConsoleKey k = Console.ReadKey(true).Key;
                switch (k)
                {
                    case ConsoleKey.S: // When s-key pressed

                        string name = "";
                        Menu.Center("Please type your Name and ENTER");

                        do
                        {
                            name = Console.ReadLine();
                        } while (String.IsNullOrEmpty(name));

                        IGame tester = createReactionTester(_mode, name);

                        if (tester.run())
                        { // Run reaction tester
                            Menu.Center($"\n--- Results ---");
                            Menu.Center($"Time taken to press ENTER: {tester.Player.Points} ms");

                            PlayerHandler.Handle(tester.Player, _scores);

                            Menu.Center("Press any Key to continue");
                            Console.ReadKey();
                            Menu.Print(_scores);
                        }
                        break;
                    case ConsoleKey.H: // when h-Key pressed
                        Menu.PrintHelp();
                        while (true)
                        {
                            ConsoleKey consoleKey = Console.ReadKey(true).Key;
                            if (consoleKey == ConsoleKey.Escape)
                            {
                                Menu.Print(_scores);
                                break;
                            }
                            else if (consoleKey == ConsoleKey.Q)
                            {
                                Console.Clear();
                                Console.WriteLine(AsciiArt.marioF);
                                Thread.Sleep(50);
                                Menu.Print(_scores);
                                return;
                            }
                        }
                        break;
                    case ConsoleKey.Q: // when q-Key pressed
                        Console.Clear();
                        Console.WriteLine(AsciiArt.marioF);
                        Thread.Sleep(50);
                        Menu.Print(_scores);
                        return;
                    default:
                        Console.WriteLine("Key not defined try again");
                        break;
                }
                Thread.Sleep(100);

            }
        }
    }
}

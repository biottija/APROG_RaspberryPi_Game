using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Game
{
    public class TheGame
    {
        private string _scores;
        public TheGame() 
        {
            _scores = "Scores.txt";
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu.Print(_scores);
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

                        IGame tester = new ReactionTesterConsole(name);

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
                                Thread.Sleep(200);
                                Menu.Print(_scores);
                                return;
                            }
                        }
                        break;
                    case ConsoleKey.Q: // when q-Key pressed
                        Console.Clear();
                        Console.WriteLine(AsciiArt.marioF);
                        Thread.Sleep(200);
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

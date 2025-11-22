using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace The_Game {
    internal class Menu {

        string _scores;

        internal Menu() {
            _scores = "Scores.txt";
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu.Print(_scores);
        }

        public void run() {
            
            while (true) {
                ConsoleKey k = Console.ReadKey(true).Key;
                switch (k) {
                    case ConsoleKey.S: // When s-key pressed

                        string name = "";
                        Menu.Center("Please type your Name and ENTER");

                        do {
                            name = Console.ReadLine();
                        } while (String.IsNullOrEmpty(name));

                        IGame tester = new ReactionTesterConsole(name);

                        if (tester.run()) { // Run reaction tester
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
                        while (true) {
                            ConsoleKey consoleKey = Console.ReadKey(true).Key;
                            if (consoleKey == ConsoleKey.Escape) {
                                Menu.Print(_scores);
                                break;
                            }
                            else if (consoleKey == ConsoleKey.Q) {
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

        public static void Print(string scores) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(AsciiArt.logo);
            line();
            Center("Welcome to the Game");
            line();
            Scoreboard(scores);
            line();
            Center("APROG Project by:");
            Center("Jannis Biotti and Luca Heger");
            line();
            string keyLegend = "";
            keyLegend = "~ Press 'h' to get help ";
            keyLegend += "~ Press 's' to start the Game ";
            keyLegend += "~ Press 'q' to quit the Game ";
            keyLegend += "~";
            Center(keyLegend);
            line();


        }
        public static void PrintHelp() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(AsciiArt.help);
            line();
            Console.WriteLine();
            Center("Press Enter when you see Super Mario Appear");
            Console.WriteLine();
            Console.WriteLine(AsciiArt.mario);
            line();
            string keyLegend = "";
            keyLegend += "~ Press 'esc' to get Back ";
            keyLegend += "~ Press 'q' to quit the Game ";
            keyLegend += "~";
            Center(keyLegend);
            line();

        }
        //this writes a line as wide as the logo with '~'
        public static void line() {
            Console.Write(new string('~', 108) + "\n");
        }

        //this centers a text beneeth the logo
        public static void Center(string s) {
            s = s.Trim();
            int n = 54 - (s.Length / 2);
            Console.Write(new string(' ', n));
            Console.Write(s + "\n");
        }
        //print the scoreboard
        private static void Scoreboard(string scores) {
            var players = new List<Player>();
            players = PlayerHandler.LoadPlayer(scores); //load the scorelist
            players = players.OrderByDescending(p => p.Points).ToList(); //sort the list
            players.Reverse(); //make the person with the lowes time #1
            //remove if more than 10 players in list
            if (players.Count > 10) {
                players.RemoveRange(10, players.Count - 10);
            }
            //print
            /*Center(new string('*', 40));
            Center('*' + new string(' ', 38) + '*');
            Center('*' + new string(' ', 14) + "Highscores" + new string(' ', 14) + '*');
            Center('*' + new string(' ', 38) + '*');
            Center(new string('*', 40));*/
            Console.WriteLine(AsciiArt.highscores);

            int rank = 1;
            foreach (Player p in players) {
                ScrbrdPlayer(rank++, p);
            }
            Center('*' + new string(' ', 28) + '*' + new string(' ', 9) + '*');
            Center(new string('*', 40));
        }
        //print one player in the scoreboard
        private static void ScrbrdPlayer(int rank, Player p) {
            string line = "*  " + rank + ".  " + p.Name;
            line += new string(' ', (29 - line.Length)) + '*';
            line += "  ";
            line += p.Points.ToString("D5");
            line += "  *";
            Center(line);

        }

    }
}

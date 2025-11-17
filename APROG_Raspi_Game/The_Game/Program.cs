using System.Text;

namespace The_Game {
    internal class Program {
        static void Main(string[] args) {
            // TODO: filePath should be defined
            string src = "Scores.txt";


            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.DarkRed;

            
            
            
           
            Menu.Print(src);
            


            while (true) {
                ConsoleKey k = Console.ReadKey(true).Key;
                switch (k) {
                    case ConsoleKey.S:

                        ReactionTester tester = new ReactionTester();
                        if (tester.run()) {
                            Console.WriteLine($"\n--- Results ---");
                            Console.WriteLine($"Time taken to press ENTER: {tester.PlayerOne.Points} ms");

                            string name = "";
                            Console.WriteLine("Please type your Name and ENTER");
                            do {
                                name = Console.ReadLine();
                            } while (String.IsNullOrEmpty(name));
                            Player test = new Player(name, tester.PlayerOne.Points);
                            PlayerHandler.Handle(test, src);
                                                  



                            Console.ReadKey();
                            Console.Clear();
                            Menu.Print(src);
                        }
                        break;
                    case ConsoleKey.H:
                        Menu.PrintHelp();
                        while (true) {
                           ConsoleKey consoleKey = Console.ReadKey(true).Key;
                            if (consoleKey == ConsoleKey.Escape) {
                                Menu.Print(src);
                                break;
                            } else if (consoleKey == ConsoleKey.Q) {
                                Console.Clear();
                                Console.WriteLine(AsciiArt.marioF);
                                Thread.Sleep(200);
                                Menu.Print(src);
                                return;
                            }
                        }
                        break;
                    case ConsoleKey.Q:
                        Console.Clear();
                        Console.WriteLine(AsciiArt.marioF);
                        Thread.Sleep(200);
                        Menu.Print(src);
                        return;
                    default:
                        Console.WriteLine("Key not defined try again");
                        break;
                }
                Thread.Sleep(1000);

            }



        }
    }
}

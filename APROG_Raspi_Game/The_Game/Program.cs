using System.Text;

namespace The_Game {
    internal class Program {
        static void Main(string[] args) {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            //Console.WriteLine(AsciiArt.logo);
            //Console.WriteLine(AsciiArt.mario);
            //Console.WriteLine(AsciiArt.marioF);

            Menu.Print();
            //Create the Score file
            // \TODO: filePath should be defined
            FileStream Fs = new FileStream("Scores.txt", FileMode.Create);
            Fs.Close();
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

                            
                            // PlayerOne.Points can be written to the file here.
                            // ...
                            Console.ReadKey();
                            Console.Clear();
                            Menu.Print();
                        }
                        break;
                    case ConsoleKey.H:
                        Console.WriteLine("Press Enter when you see \"Click\" Appear");
                        break;
                    case ConsoleKey.Q:
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

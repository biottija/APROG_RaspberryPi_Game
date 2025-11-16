using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace The_Game {
    internal class Menu {
        public static void Print() { 
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(AsciiArt.logo);
            line();
            Center("Welcome to the Game");
            line();
            Center("APROG Project by:");
            Center("Jannis Biotti and Luca Heger");
            line();
            Console.Write("~ Press 'h' to get help ");
            Console.Write("~ Press 's' to start the Game ");
            Console.Write("~ Press 'q' to quit the Game ");
            Console.Write("~\n");
            line();
            

        }
        //this writes a line as wide as the logo with '~'
        private static void line() {
            Console.Write(new string('~', 108) + "\n");
        }

        //this centers a text beneeth the logo
        private static void Center(string s) {
            s = s.Trim();
            int n = 54 - (s.Length / 2);
            Console.Write(new string(' ',n));
            Console.Write(s + "\n");
        }

        

    }
}

using GpioHat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Game
{
    public class ReactionTesterConsole : ReactionTester
    {
        public ReactionTesterConsole(string playerName) : base(playerName){}

        protected override bool checkUserInput()
        {
            Console.Read();
            return true;
        }

        protected override void sendReactSignal()
        {
            Console.WriteLine(AsciiArt.mario);
        }
    }
    }

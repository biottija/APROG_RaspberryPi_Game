using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Game
{
    internal class ReactionTester : IGame
    {
        public ReactionTester (string playerName)
        {
            
            this.PlayerOne = new Player(playerName, 0);
        }

        public Player PlayerOne { get; }

        public bool run()
        {
            bool exit = false;
            bool exitSuccess = true;

            Random random = new Random();
            int randomDelay = random.Next(0, 1000);

            int delayCounter = 0;

            Stopwatch stopwatch = new Stopwatch();

            while (!exit)
            {
                if (delayCounter >= randomDelay)
                {
                    stopwatch.Start();
                    Console.WriteLine("Click");
                    Console.Read();
                    stopwatch.Stop();
                    TimeSpan elapsed = stopwatch.Elapsed;
                    PlayerOne.Points = (int)elapsed.TotalMilliseconds;
                    exit = true;
                }

                Thread.Sleep(10);
                delayCounter++;
            }
            return exitSuccess;
        }
    }
}

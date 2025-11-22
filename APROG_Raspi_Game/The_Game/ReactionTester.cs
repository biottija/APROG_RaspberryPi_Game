using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GpioHat;

namespace The_Game
{
    public abstract class ReactionTester : IGame
    {

        public ReactionTester(string playerName)
        {

            this.Player = new Player(playerName, 0);
            _raspberry = Raspberry.Instance;
            _state = TesterStates.StateIdle;
            onInitialization();
        }

        public Player Player { get; }
        private Raspberry _raspberry;
        private TesterStates _state;

        public bool run()
        {
            bool exit = false;
            bool exitSuccess = true;

            Random random = new Random();
            int randomDelay = random.Next(0, 10000); // Generate delay between 0 and 10'000 ms
            int delayCounter = 0;

            Stopwatch stopwatch = new Stopwatch();

            Console.Clear();
            Console.WriteLine(AsciiArt.logo);
            Menu.line();


            while (!exit)
            {
                exit = handleState(_state, randomDelay, (delayCounter * 10), stopwatch);

                Thread.Sleep(10);
                delayCounter++;
            }
            return exitSuccess;
        }

        private bool handleState(TesterStates state, int delay, int elapsedTime, Stopwatch stopwatch)
        {
            bool exit = false;
            switch (_state)
            {
                case TesterStates.StateIdle:
                    _state = TesterStates.StateWaitingForGo;
                    break;
                case TesterStates.StateWaitingForGo:
                    if (elapsedTime >= delay)
                    {
                        _state = TesterStates.StateReact;

                        stopwatch.Start();

                        sendReactSignal();
                    }
                    break;
                case TesterStates.StateReact:
                    if (checkUserInput())
                    {
                        stopwatch.Stop();
                        _state = TesterStates.StateFinished;
                    }
                    break;
                case TesterStates.StateFinished:
                    // store timer data
                    TimeSpan elapsed = stopwatch.Elapsed;
                    Player.Points = (int)elapsed.TotalMilliseconds;
                    exit = true;
                    break;
            }
            return exit;
        }

        protected abstract bool checkUserInput();

        protected abstract void sendReactSignal();
        protected virtual void onInitialization() { /* Do Nothing */ }

        private enum TesterStates
        {
            StateIdle,
            StateWaitingForGo,
            StateReact,
            StateFinished
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GpioHat;

namespace The_Game
{
    public class ReactionTesterRaspberry : ReactionTester
    {

        public ReactionTesterRaspberry(string playerName) : base(playerName)
        {
            Raspberry.Instance.Init(HardwareAccess.Raspberry);
            _raspberry = Raspberry.Instance;
        }

        private Raspberry _raspberry;

        protected override bool checkUserInput()
        {
            if (_raspberry.Joystick.State == JoystickButtons.Center)
            {
                return true;
            }
            return false;
        }

        protected override void sendReactSignal()
        {
            _raspberry.LedRed.Enabled = true;
            _raspberry.LedGrn.Enabled = true;
            _raspberry.LedYlw.Enabled = true;
        }

        protected override void onRun()
        {
            _raspberry.LedRed.Enabled = false;
            _raspberry.LedGrn.Enabled = false;
            _raspberry.LedYlw.Enabled = false;
        }
    }
}

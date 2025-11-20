using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpioHat {
    
    public class Raspberry {        
        private Raspberry() { }
        private static Raspberry raspberry = new Raspberry();
        public static Raspberry Instance { get{ return raspberry; } }
        public IJoystick Joystick { get; private set; }
        public ILed LedGrn { get; set; }
        public ILed LedYlw { get; set; }
        public ILed LedRed { get; set; }
        public void Init(HardwareAccess acc) {
            if (acc == HardwareAccess.Raspberry) {
                GpioController controller = new GpioController();
                LedRed = new LedDirect(LedColor.Red, controller);
                LedYlw = new LedDirect(LedColor.Yellow, controller);
                LedGrn = new LedDirect(LedColor.Green, controller);
                Joystick = new JoystickDirect(controller);

            }
            else {
            throw new NotImplementedException();
            }
            LedRed.Enabled = false;
            LedYlw.Enabled = false;
            LedGrn.Enabled = false;

        }

        

    }
}

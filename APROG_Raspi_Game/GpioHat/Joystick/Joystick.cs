using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpioHat {
    public abstract class Joystick : IJoystick {
        public abstract JoystickButtons State {get;}
    }
}

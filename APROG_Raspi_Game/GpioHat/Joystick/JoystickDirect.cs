using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Gpio;

namespace GpioHat {
    public class JoystickDirect : Joystick {
        
        internal GpioController controller { get; }
        public JoystickDirect(GpioController ctrl) {
            controller = ctrl;

            foreach (JoystickPins pin in (JoystickPins[])Enum.GetValues(typeof(JoystickPins))) {
                controller.OpenPin((int)pin, PinMode.InputPullUp);
            }
        }
        
        public override JoystickButtons State { 
            get { JoystickButtons buttons = JoystickButtons.None;
                if (controller.Read((int)JoystickPins.Center) == PinValue.Low) { buttons |= JoystickButtons.Center; }
                if (controller.Read((int)JoystickPins.Left) == PinValue.Low) { buttons |= JoystickButtons.Left; }
                if (controller.Read((int)JoystickPins.Right) == PinValue.Low) { buttons |= JoystickButtons.Right; }
                if (controller.Read((int)JoystickPins.Up) == PinValue.Low) { buttons |= JoystickButtons.Up; }
                if (controller.Read((int)JoystickPins.Down) == PinValue.Low) { buttons |= JoystickButtons.Down; }
                return buttons;

            } 
        }
    }
}

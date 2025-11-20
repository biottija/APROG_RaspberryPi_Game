using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpioHat {
    public abstract class Led : ILed {
        public Led(LedColor clr) {
            LedColor = clr;
        }
        public abstract bool Enabled {get; set;}

        public LedColor LedColor { get;}

        public void Toggle() {
            Enabled = !Enabled;
        }
    }
}

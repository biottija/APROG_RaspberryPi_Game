using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GpioHat {
    public interface ILed {
        bool Enabled {  get; set; }
        void Toggle();

        LedColor LedColor { get; }

    }
}

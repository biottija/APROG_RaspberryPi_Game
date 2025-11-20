using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpioHat {
    public class LedDirect : Led {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        private int pinNr;
        private GpioController controller;
        private bool enabled;
        public LedDirect(LedColor color, GpioController gpio) : base(color) {
            controller = gpio;
            pinNr = (int)color;
            controller.OpenPin(pinNr, PinMode.Output);
            Enabled = false;
            log.Trace("New Led: " + color);
        }
        public override bool Enabled {
            get { return controller.Read(pinNr) == PinValue.High; }
            set {
                { controller.Write(pinNr, value); }
            }
        }
    }


}


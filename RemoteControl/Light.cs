using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    internal class Light
    {
        private string location;
        private bool IsOn { get; set; }

        public Light(string location)
        {
            this.IsOn = false;
            this.location = location;
        }

        public void On()
        {
            IsOn = true;
            Console.WriteLine($"{location} Light is on");
        }

        public void Off()
        {
            IsOn = false;
            Console.WriteLine($"{location} Light is off");
        }
    }
}

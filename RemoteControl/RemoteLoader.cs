using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    internal class RemoteLoader
    {
        private List<string> locations = new List<string>();
        public RemoteLoader(RemoteControl controller, List<string> newLocations)
        {
            this.locations = new List<string>(newLocations);
            foreach (string location in locations)
            {
                controller.SetCommand(true, onButton(new Light(location)));
                controller.SetCommand(false, offButton(new Light(location)));
            }
        }

        public LightOnCommand onButton(Light light)
        {
            return new LightOnCommand(light);
        }

        public LightOffCommand offButton(Light light)
        {
            return new LightOffCommand(light);
        }
    }
}

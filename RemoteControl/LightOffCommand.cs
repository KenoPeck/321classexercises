using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    internal class LightOffCommand : Command
    {
        private Light reciever;
        private int count;
        public LightOffCommand(Light reciever)
        {
            this.reciever = reciever;
            this.count = 0;
        }

        public void Execute()
        {
            reciever.Off();
            count++;
        }

        public void Unexecute()
        {
            if (count > 0)
            {
                count--;
                reciever.On();
            }
            else
            {
                Console.WriteLine("No more undos available for this command.");
            }
        }
    }
}

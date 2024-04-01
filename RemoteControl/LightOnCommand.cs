using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    internal class LightOnCommand : Command
    {
        private Light reciever;
        private int count;
        public LightOnCommand(Light newReciever)
        {
            this.reciever = newReciever;
            count = 0;
        }

        public void Execute()
        {
            reciever.On();
            count++;
        }

        public void Unexecute()
        {
            if (count > 0)
            {
                count--;
                reciever.Off();
            }
            else
            {
                Console.WriteLine("No more undos available for this command.");
            }
        }
    }
}

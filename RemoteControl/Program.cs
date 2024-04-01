using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RemoteControl controller = new RemoteControl();
            List<string> locations = new List<string> { "Living Room", "Kitchen", "Bedroom", "Front Door" };
            RemoteLoader loader = new RemoteLoader(controller, locations);
            string? userInput;
            int i = 1, j = 0;
            while (true)
            {
                Console.WriteLine("Enter the location you want to turn on or off the light, u to undo, r to redo, or q to quit");
                foreach (string location in locations)
                {
                    Console.WriteLine($"{i}: {location}");
                    i++;
                }
                userInput = Console.ReadLine();
                if (userInput == "q")
                {
                    break;
                }
                else if (userInput == "u")
                {
                    try
                    {
                        controller.UndoButtonWasPushed();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (int.TryParse(userInput, out j) && j > 0 && j <= locations.Count)
                {
                    Console.WriteLine("Enter 1 to turn on the light, or 2 to turn off the light");
                    userInput = Console.ReadLine();
                    if (userInput == "1")
                    {
                        controller.AddUndoCommand(controller.onCommands[j - 1]);
                        controller.OnButtonWasPushed(j - 1);
                    }
                    else if (userInput == "2")
                    {
                        controller.AddUndoCommand(controller.offCommands[j - 1]);
                        controller.OffButtonWasPushed(j - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                i = 1;
                j = 0;
            }
        }
    }
}

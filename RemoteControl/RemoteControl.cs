using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    internal class RemoteControl
    {
        public List<Command> onCommands = new List<Command>();
        public List<Command> offCommands = new List<Command>();
        public Stack<Command> undoCommands = new Stack<Command>();
        
        public RemoteControl() { }

        internal void SetCommand(bool on, Command newCommand)
        {
            if (on)
            {
                onCommands.Add(newCommand);
            }
            else
            {
                offCommands.Add(newCommand);
            }
        }

        public void OnButtonWasPushed(int buttonIndex)
        {
            onCommands[buttonIndex].Execute();
        }

        public void OffButtonWasPushed(int buttonIndex)
        {
            offCommands[buttonIndex].Execute();
        }

        public void AddUndoCommand(Command newCommand)
        {
            undoCommands.Push(newCommand);
        }

        public void UndoButtonWasPushed()
        {
            if (undoCommands.Count > 0)
            {
                Command undoCommand = undoCommands.Pop();
                undoCommand.Unexecute();
            }
            else
            {
                throw new InvalidOperationException("No more undos available.");
            }
        }

    }
}

using MarsRover.Commands;
using MarsRover.Common;
using MarsRover.Enums;
using MarsRover.Interfaces;

namespace MarsRover
{
    public class RemoteControl
    {
        ICommand command;

        public void SetCommand(IRover rover, string commandText)
        {
            Movements movement = EnumExtensions.GetValueFromDescription<Movements>(commandText);
            ICommand command = CommandFactory.Create(movement, rover);
            this.command = command;
        }

        public void Execute()
        {
            command.Execute();
        }
    }
}
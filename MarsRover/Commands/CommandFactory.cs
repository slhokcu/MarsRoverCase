using System;
using System.Collections.Generic;
using MarsRover.Enums;

namespace MarsRover.Commands
{
    public static class CommandFactory
    {
        static readonly Dictionary<Movements, Type> registeredCommands = new Dictionary<Movements, Type>
        {
            {Movements.Forward, typeof(MoveForward)},
            {Movements.Left, typeof(MoveLeft)},
            {Movements.Right, typeof(MoveRight)},
        };

        public static ICommand Create(Movements movement, params object[] constructorArguments)
        {
            Type type;
            ICommand command = null;
            if (registeredCommands.TryGetValue(movement, out type))
            {
                command = (ICommand)Activator.CreateInstance(type, constructorArguments);
            }
            return command;
        }
    }
}
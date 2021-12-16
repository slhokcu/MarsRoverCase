using System;
using MarsRover.Enums;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau plateau = new Plateau(5, 5);
            Rover firstRover = new Rover(new Position(1, 2), Directions.N, plateau);

            RemoteControl remoteControl = new RemoteControl();
            string commandText = "LMLMLMLMM";
            foreach (char commandChar in commandText)
            {
                remoteControl.SetCommand(firstRover, commandChar.ToString());
                remoteControl.Execute();
            }

            Rover secondRover = new Rover(new Position(3, 3), Directions.E, plateau);
            commandText = "MMRMMRMRRM";
            foreach (char commandChar in commandText)
            {
                remoteControl.SetCommand(secondRover, commandChar.ToString());
                remoteControl.Execute();
            }

            Console.WriteLine(firstRover.ToString());
            Console.WriteLine(secondRover.ToString());
        }
    }
}

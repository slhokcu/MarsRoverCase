using System;
using MarsRover;
using MarsRover.Commands;
using MarsRover.Common;
using MarsRover.Enums;
using MarsRover.Exceptions;
using Xunit;

namespace MarsRoverTest
{
    public class MarsRoverUnitTests
    {
        [Fact]
        public void Rover_Movement_Test()
        {
            RemoteControl remoteControl = new RemoteControl();
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(1, 2), Directions.N, plateau);

            string commandText = "LMLMLMLMM";
            foreach (char commandChar in commandText)
            {
                remoteControl.SetCommand(rover, commandChar.ToString());
                remoteControl.Execute();
            }

            Assert.Equal(1, rover.Position.X);
            Assert.Equal(3, rover.Position.Y);
            Assert.Equal(Directions.N, rover.Direction);
        }

        [Fact]
        public void When_TurnLeft_CompassShouldPointCorrectly()
        {
            RemoteControl remoteControl = new RemoteControl();
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(1, 2), Directions.N, plateau);

            remoteControl.SetCommand(rover, "L");
            remoteControl.Execute();
            Assert.Equal(Directions.W, rover.Direction);

            remoteControl.SetCommand(rover, "L");
            remoteControl.Execute();
            Assert.Equal(Directions.S, rover.Direction);
        }

        [Fact]
        public void When_TurnRight_CompassShouldPointCorrectly()
        {
            RemoteControl remoteControl = new RemoteControl();
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(1, 2), Directions.N, plateau);

            remoteControl.SetCommand(rover, "R");
            remoteControl.Execute();
            Assert.Equal(Directions.E, rover.Direction);

            remoteControl.SetCommand(rover, "R");
            remoteControl.Execute();
            Assert.Equal(Directions.S, rover.Direction);
        }

        [Fact]
        public void Should_ThrowException_When_OutofArea()
        {
            RemoteControl remoteControl = new RemoteControl();
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(1, 5), Directions.N, plateau);

            remoteControl.SetCommand(rover, "M");
            void act() => remoteControl.Execute();

            var exception = Assert.Throws<OutOfAreaException>(act);
        }

        [Fact]
        public void Convert_MovementsEnum()
        {
            Movements movement = EnumExtensions.GetValueFromDescription<Movements>("R");
            Assert.Equal(Movements.Right, movement);
        }

        [Fact]
        public void Convert_MovementsEnum_Fail()
        {
            void act() => EnumExtensions.GetValueFromDescription<Movements>("X");
            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Should_ThrowException_When_LandingOutOfRange()
        {
            Plateau plateau = new Plateau(5, 5);
            void act() => new Rover(new Position(1, 8), Directions.N, plateau);
            var exception = Assert.Throws<OutOfAreaException>(act);
        }

        [Fact]
        public void Create_Command()
        {
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(1, 2), Directions.N, plateau);

            ICommand command = CommandFactory.Create(Movements.Left, rover);

            Assert.NotNull(command as MoveLeft);
        }
    }
}

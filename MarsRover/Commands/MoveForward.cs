using MarsRover.Enums;
using MarsRover.Exceptions;

namespace MarsRover.Commands
{
    public class MoveForward : ICommand
    {
        private Rover rover;

        public MoveForward(Rover rover)
        {
            this.rover = rover;
        }

        public void Execute()
        {
            Position newPosition = forward(rover.Position);
            if (rover.Plateau.CheckPosition(newPosition))
                rover.Position = newPosition;
            else
                throw new OutOfAreaException();
        }

        private Position forward(Position position)
        {
            Position newPosition = new Position(position.X, position.Y);
            switch (rover.Direction)
            {
                case Directions.E:
                    newPosition.X += 1;
                    break;
                case Directions.N:
                    newPosition.Y += 1;
                    break;
                case Directions.S:
                    newPosition.Y -= 1;
                    break;
                case Directions.W:
                    newPosition.X -= 1;
                    break;
            }

            return newPosition;
        }
    }
}
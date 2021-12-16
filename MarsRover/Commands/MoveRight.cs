using MarsRover.Enums;

namespace MarsRover.Commands
{
    public class MoveRight : ICommand
    {
        private Rover rover;

        public MoveRight(Rover rover)
        {
            this.rover = rover;
        }

        public void Execute()
        {
            rover.Direction = (Directions)(((int)rover.Direction + 1 + 4) % 4);
        }
    }
}
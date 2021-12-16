using MarsRover.Enums;
using MarsRover.Exceptions;
using MarsRover.Interfaces;

namespace MarsRover
{
    public class Rover : IRover
    {
        private Position _position;
        private Directions _direction;
        private IPlateau _plateau;

        public Rover(Position position, Directions direction, IPlateau plateau)
        {
            _position = position;
            _direction = direction;
            _plateau = plateau;

            if (!_plateau.CheckPosition(position))
                throw new OutOfAreaException();
        }

        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Directions Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public IPlateau Plateau
        {
            get { return _plateau; }
            set { _plateau = value; }
        }

        public override string ToString()
        {
            return $"{Position.X} {Position.Y} {Direction}";
        }
    }
}
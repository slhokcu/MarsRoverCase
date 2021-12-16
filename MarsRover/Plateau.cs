using MarsRover.Interfaces;

namespace MarsRover
{
    public class Plateau : IPlateau
    {
        private int width { get; set; }
        private int height { get; set; }

        public Plateau(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public bool CheckPosition(Position position)
        {
            return position.X >= 0 && position.X <= width && position.Y >= 0 && position.Y <= height;
        }
    }
}
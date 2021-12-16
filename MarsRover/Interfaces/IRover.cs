using MarsRover.Enums;

namespace MarsRover.Interfaces
{
    public interface IRover
    {
        Position Position { get; set; }
        Directions Direction { get; set; }
        IPlateau Plateau { get; set; }
    }
}
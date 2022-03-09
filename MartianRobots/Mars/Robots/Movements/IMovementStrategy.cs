using MartianRobots.Mars.Terrain;

namespace MartianRobots.Mars.Robots.Movements
{
    internal interface IMovementStrategy
    {
        RobotDirection DirectionBeforeMovement { get; }

        Coordinates CalculateForwardEndCoordinates(Coordinates currentCoordinates, int howManySquares);

        RobotDirection GetDirectionIfTurnsLeft();

        RobotDirection GetDirectionIfTurnsRight();
    }
}
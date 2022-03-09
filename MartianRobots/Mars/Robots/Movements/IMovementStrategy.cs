using MartianRobots.Mars.Terrain;

namespace MartianRobots.Mars.Robots.Movements
{
    internal interface IMovementStrategy
    {
        RobotDirection DirectionBeforeMovement { get; }

        Coordinates CalculateForwardEndCoordinates(Coordinates currentCoordinates);

        RobotDirection GetDirectionIfTurnsLeft();

        RobotDirection GetDirectionIfTurnsRight();
    }
}
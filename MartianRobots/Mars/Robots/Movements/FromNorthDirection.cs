using MartianRobots.Mars.Terrain;

namespace MartianRobots.Mars.Robots.Movements
{
    internal class FromNorth : IMovementStrategy
    {
        public RobotDirection DirectionBeforeMovement => RobotDirection.North;

        public Coordinates CalculateForwardEndCoordinates(Coordinates currentCoordinates)
            => new Coordinates
            {
                X = currentCoordinates.X,
                Y = currentCoordinates.Y + 1
            };

        public RobotDirection GetDirectionIfTurnsLeft() => RobotDirection.West;

        public RobotDirection GetDirectionIfTurnsRight() => RobotDirection.East;
    }
}
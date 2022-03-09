using MartianRobots.Mars.Terrain;

namespace MartianRobots.Mars.Robots.Movements
{
    internal class FromNorth : IMovementStrategy
    {
        public RobotDirection DirectionBeforeMovement => RobotDirection.North;

        public Coordinates CalculateForwardEndCoordinates(Coordinates currentCoordinates, int howManySquares)
            => new Coordinates
            {
                X = currentCoordinates.X,
                Y = currentCoordinates.Y + howManySquares
            };

        public RobotDirection GetDirectionIfTurnsLeft() => RobotDirection.West;

        public RobotDirection GetDirectionIfTurnsRight() => RobotDirection.East;
    }
}
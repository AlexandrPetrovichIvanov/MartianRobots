using MartianRobots.Mars.Terrain;

namespace MartianRobots.Mars.Robots.Movements
{
    internal class FromWest : IMovementStrategy
    {
        public RobotDirection DirectionBeforeMovement => RobotDirection.West;

        public Coordinates CalculateForwardEndCoordinates(Coordinates currentCoordinates)
            => new Coordinates
            {
                X = currentCoordinates.X - 1,
                Y = currentCoordinates.Y
            };

        public RobotDirection GetDirectionIfTurnsLeft() => RobotDirection.South;

        public RobotDirection GetDirectionIfTurnsRight() => RobotDirection.North;
    }
}
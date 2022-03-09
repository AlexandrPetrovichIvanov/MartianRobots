using MartianRobots.Mars.Terrain;

namespace MartianRobots.Mars.Robots.Movements
{
    internal class FromEast : IMovementStrategy
    {
        public RobotDirection DirectionBeforeMovement => RobotDirection.East;

        public Coordinates CalculateForwardEndCoordinates(Coordinates currentCoordinates)
            => new Coordinates
            {
                X = currentCoordinates.X + 1,
                Y = currentCoordinates.Y
            };

        public RobotDirection GetDirectionIfTurnsLeft() => RobotDirection.North;

        public RobotDirection GetDirectionIfTurnsRight() => RobotDirection.South;
    }
}
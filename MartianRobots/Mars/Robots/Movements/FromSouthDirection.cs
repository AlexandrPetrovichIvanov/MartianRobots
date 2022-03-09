using MartianRobots.Mars.Terrain;

namespace MartianRobots.Mars.Robots.Movements
{
    internal class FromSouth : IMovementStrategy
    {
        public RobotDirection DirectionBeforeMovement => RobotDirection.South;

        public Coordinates CalculateForwardEndCoordinates(Coordinates currentCoordinates)
            => new Coordinates
            {
                X = currentCoordinates.X,
                Y = currentCoordinates.Y - 1
            };

        public RobotDirection GetDirectionIfTurnsLeft() => RobotDirection.East;

        public RobotDirection GetDirectionIfTurnsRight() => RobotDirection.West;
    }
}
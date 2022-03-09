using MartianRobots.Mars.Terrain;

namespace MartianRobots.Mars.Robots.Movements
{
    internal class FromEast : IMovementStrategy
    {
        public RobotDirection DirectionBeforeMovement => RobotDirection.East;

        public Coordinates CalculateForwardEndCoordinates(Coordinates currentCoordinates, int howManySquares)
            => new Coordinates
            {
                X = currentCoordinates.X + howManySquares,
                Y = currentCoordinates.Y
            };

        public RobotDirection GetDirectionIfTurnsLeft() => RobotDirection.North;

        public RobotDirection GetDirectionIfTurnsRight() => RobotDirection.South;
    }
}
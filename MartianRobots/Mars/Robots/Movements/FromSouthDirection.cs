using MartianRobots.Mars.Terrain;

namespace MartianRobots.Mars.Robots.Movements
{
    internal class FromSouth : IMovementStrategy
    {
        public RobotDirection DirectionBeforeMovement => RobotDirection.South;

        public Coordinates CalculateForwardEndCoordinates(Coordinates currentCoordinates, int howManySquares)
            => new Coordinates
            {
                X = currentCoordinates.X,
                Y = currentCoordinates.Y - howManySquares
            };

        public RobotDirection GetDirectionIfTurnsLeft() => RobotDirection.East;

        public RobotDirection GetDirectionIfTurnsRight() => RobotDirection.West;
    }
}
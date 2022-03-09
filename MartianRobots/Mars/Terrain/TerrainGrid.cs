using System.Collections.Generic;
using MartianRobots.Mars.Robots;

namespace MartianRobots.Mars.Terrain
{
    internal class TerrainGrid : ITerrainGrid
    {
        private readonly int _maximumX;

        private readonly int _maximumY;

        private const int _minimumX = 0;

        private const int _minimumY = 0;

        private readonly HashSet<RobotPosition> _scents = new HashSet<RobotPosition>();

        internal TerrainGrid(int maximumX, int maximumY)
        {
            _maximumX = maximumX;
            _maximumY = maximumY;
        }

        public bool IsReachableFromTheBase(Coordinates position)
            => position.X <= _maximumX && position.X >= _minimumX
                && position.Y <= _maximumY && position.Y >= _minimumY;

        public bool PositionHasScent(RobotPosition position)
            => _scents.Contains(position);

        public void LeaveScent(RobotPosition position)
        {
            if (!_scents.Contains(position)) _scents.Add(position);
        }
    }
}
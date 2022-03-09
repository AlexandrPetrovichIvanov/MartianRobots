using System.Collections.Generic;

namespace MartianRobots.Mars.Terrain
{
    internal class TerrainGrid : ITerrainGrid
    {
        private readonly int _maximumX;

        private readonly int _maximumY;

        private const int _minimumX = 0;

        private const int _minimumY = 0;

        private readonly HashSet<Coordinates> _scents = new HashSet<Coordinates>();

        internal TerrainGrid(int maximumX, int maximumY)
        {
            _maximumX = maximumX;
            _maximumY = maximumY;
        }

        public bool IsReachableFromTheBase(Coordinates position)
            => position.X <= _maximumX && position.X >= _minimumX
                && position.Y <= _maximumY && position.Y >= _minimumY;

        public bool PositionHasScent(Coordinates position)
            => _scents.Contains(position);

        public void LeaveScent(Coordinates position)
        {
            if (!_scents.Contains(position)) _scents.Add(position);
        }
    }
}
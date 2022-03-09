using MartianRobots.Mars.Robots;

namespace MartianRobots.Mars.Terrain
{
    internal interface ITerrainGrid
    {
        bool PositionHasScent(Coordinates position);

        bool IsReachableFromTheBase(Coordinates position);
    }
}
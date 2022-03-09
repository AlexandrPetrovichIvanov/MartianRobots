using MartianRobots.Mars.Robots;

namespace MartianRobots.Mars.Terrain
{
    internal interface ITerrainGrid
    {
        bool PositionHasScent(RobotPosition position);

        bool IsReachableFromTheBase(Coordinates position);

        void LeaveScent(RobotPosition position);
    }
}
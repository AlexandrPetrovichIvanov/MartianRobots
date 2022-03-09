using System.Collections.Generic;
using MartianRobots.Mars.Robots;
using MartianRobots.Mars.Robots.Commands;
using MartianRobots.Mars.Terrain;

namespace MartianRobots.Mars
{
    /// <summary>
    ///     It is a facade to work with all robots on Mars.
    /// </summary>
    internal interface IMartianBase
    {
        void LocateNewRobotOnTerrain(IRobot robot, ITerrainGrid grid);

        void InstructRobot(IRobot robot, IEnumerable<IRobotCommand> instructions);

        RobotPosition GetRobotLastReachablePosition(IRobot robot);

        bool IsCurrentRobotPositionUnreachable(IRobot robot);
    }
}
using System.Collections.Generic;
using MartianRobots.Mars.Robots;
using MartianRobots.Mars.Robots.Commands;
using MartianRobots.Mars.Terrain;

namespace MartianRobots.Mars
{
    internal class MartianBase : IMartianBase
    {
        public RobotPosition GetRobotLastReachablePosition(IRobot robot)
        {
            throw new System.NotImplementedException();
        }

        public void InstructRobot(IRobot robot, IEnumerable<IRobotCommand> instructions)
        {
            throw new System.NotImplementedException();
        }

        public bool IsCurrentRobotPositionUnreachable(IRobot robot)
        {
            throw new System.NotImplementedException();
        }

        public void LocateNewRobotOnTerrain(IRobot robot, ITerrainGrid grid)
        {
            throw new System.NotImplementedException();
        }
    }
}
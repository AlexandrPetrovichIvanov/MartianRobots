using MartianRobots.Mars.Robots;

namespace MartianRobots.Earth.Commands
{
    internal interface IRobotCommand
    {
        void Execute(IRobot target);
    }
}
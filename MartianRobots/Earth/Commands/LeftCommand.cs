using MartianRobots.Mars.Robots;

namespace MartianRobots.Earth.Commands
{
    internal class LeftCommand : IRobotCommand
    {
        public void Execute(IRobot target)
        {
            target.TurnLeft();
        }
    }
}
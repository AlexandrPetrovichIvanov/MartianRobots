using MartianRobots.Mars.Robots;

namespace MartianRobots.Earth.Commands
{
    internal class ForwardCommand : IRobotCommand
    {
        public void Execute(IRobot target)
        {
            target.MoveForward();
        }
    }
}
using MartianRobots.Mars.Robots;

namespace MartianRobots.Earth.Commands
{
    internal class RightCommand : IRobotCommand
    {
        public void Execute(IRobot target)
        {
            target.TurnRight();
        }
    }
}
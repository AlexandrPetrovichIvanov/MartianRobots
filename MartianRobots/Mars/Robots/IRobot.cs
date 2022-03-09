namespace MartianRobots.Mars.Robots
{
    internal interface IRobot
    {
        void TurnLeft();

        void TurnRight();

        void MoveForward();

        RobotPosition CurrentPosition { get; }

        RobotPosition LastReachablePosition { get; }
    }
}
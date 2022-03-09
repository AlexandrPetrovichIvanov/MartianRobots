namespace MartianRobots.Mars.Robots
{
    internal interface IRobot
    {
        void TurnLeft();

        void TurnRight();

        void MoveForward(int howManySquaresForward);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using MartianRobots.Mars.Robots.Movements;
using MartianRobots.Mars.Terrain;

namespace MartianRobots.Mars.Robots
{
    internal class Robot : IRobot
    {
        private readonly ITerrainGrid _grid;

        private readonly IEnumerable<IMovementStrategy> _movementStrategies;

        private RobotPosition _position;

        internal Robot(
            ITerrainGrid gridToLocate,
            RobotPosition initialPosition,
            IEnumerable<IMovementStrategy> movementStrategies)
        {
            if (!gridToLocate.IsReachableFromTheBase(initialPosition.Coordinates))
                throw new ArgumentException("Can not locate a robot in an unreachable position.");
                
            _grid = gridToLocate;
            _position = initialPosition;
            _movementStrategies = movementStrategies;
        }

        public RobotPosition CurrentPosition => _position;

        private IMovementStrategy CurrengMovementStrategy =>
            _movementStrategies.Single(strategy
                => strategy.DirectionBeforeMovement == _position.Direction);

        public void MoveForward(int howManySquaresForward)
        {
            if (_grid.PositionHasScent(_position.Coordinates))
                return; // ignore a dangerous command

            var nextSupposedCoordinates = CurrengMovementStrategy
                .CalculateForwardEndCoordinates(_position.Coordinates, howManySquaresForward);

            var previousPosition = _position;

            // move
            _position = new RobotPosition
            {
                Coordinates = nextSupposedCoordinates,
                Direction = previousPosition.Direction
            };

            if (!_grid.IsReachableFromTheBase(_position.Coordinates))
            {
                _grid.LeaveScent(previousPosition.Coordinates);
            }
        }

        public void TurnLeft()
        {
            Turn(CurrengMovementStrategy.GetDirectionIfTurnsLeft());
        }

        public void TurnRight()
        {
            Turn(CurrengMovementStrategy.GetDirectionIfTurnsRight());
        }

        private void Turn(RobotDirection targetDirection)
        {
            _position.Direction = targetDirection;
        }
    }
}
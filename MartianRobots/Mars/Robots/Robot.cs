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

        private RobotPosition _previousPosition;

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
            _previousPosition = initialPosition; // the same position
            _movementStrategies = movementStrategies;
        }

        public RobotPosition CurrentPosition => _position;

        public RobotPosition LastReachablePosition =>
            _grid.IsReachableFromTheBase(_position.Coordinates)
                ? _position
                : _previousPosition;

        private IMovementStrategy CurrengMovementStrategy =>
            _movementStrategies.Single(strategy
                => strategy.DirectionBeforeMovement == _position.Direction);

        public void MoveForward()
        {
            if (_grid.PositionHasScent(_position))
                return; // ignore a dangerous command

            var nextSupposedCoordinates = CurrengMovementStrategy
                .CalculateForwardEndCoordinates(_position.Coordinates);

            _previousPosition = _position;

            // move
            _position = new RobotPosition
            {
                Coordinates = nextSupposedCoordinates,
                Direction = _previousPosition.Direction
            };

            if (!_grid.IsReachableFromTheBase(_position.Coordinates))
            {
                _grid.LeaveScent(_previousPosition);
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
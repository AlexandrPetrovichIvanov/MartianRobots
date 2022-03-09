using System;
using System.Collections.Generic;
using System.Linq;
using MartianRobots.Earth.Commands;
using MartianRobots.Mars.Robots;
using MartianRobots.Mars.Robots.Movements;
using MartianRobots.Mars.Terrain;

namespace MartianRobots.Earth
{
    internal class EarthControlCenter : IEarthControlCenter
    {
        private readonly Dictionary<string, RobotDirection> _directions = new Dictionary<string, RobotDirection>()
        {
            { "S", RobotDirection.South },
            { "N", RobotDirection.North },
            { "E", RobotDirection.East },
            { "W", RobotDirection.West }
        };

        private readonly Dictionary<char, IRobotCommand> _commands = new Dictionary<char, IRobotCommand>()
        {
            { 'L', new LeftCommand() },
            { 'R', new RightCommand() },
            { 'F', new ForwardCommand() },
        };

        private readonly IEnumerable<IMovementStrategy> _movementStrategies = new[]
        {
            (IMovementStrategy) new FromEast(),
            new FromWest(),
            new FromNorth(),
            new FromSouth()
        };

        public string SendInstructionsToMarsSinchronously(string instructions)
        {
            var lines = instructions.Split(Environment.NewLine);

            var gridCoordinates = lines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(str => int.Parse(str)).ToArray();
            var grid = new TerrainGrid(gridCoordinates[0], gridCoordinates[1]);

            var output = string.Empty;

            for (int i = 1; i < lines.Length; i += 2)
            {
                var robot = CreateRobot(grid, lines[i]);
                MoveRobot(robot, grid, lines[i + 1].Trim());
                output += ComposeOutputResult(robot, grid);
                if (i < lines.Length - 2) output+= Environment.NewLine;
            }

            return output;
        }

        private IRobot CreateRobot(ITerrainGrid grid, string initialPositionString)
        {
            var initialPosition = initialPositionString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return new Robot(grid, new RobotPosition
            {
                Coordinates = new Coordinates
                {
                    X = int.Parse(initialPosition[0]),
                    Y = int.Parse(initialPosition[1])
                },
                Direction = _directions[initialPosition[2]]
            },
            _movementStrategies);
        }

        private void MoveRobot(IRobot robot, ITerrainGrid grid, string movementInstructions)
        {
            for (int i = 0; i < movementInstructions.Length; i++)
            {
                if (grid.IsReachableFromTheBase(robot.CurrentPosition.Coordinates))
                {
                    _commands[movementInstructions[i]].Execute(robot);
                }
            }
        }

        private string ComposeOutputResult(IRobot robot, ITerrainGrid grid)
        {
            var output = robot.LastReachablePosition.Coordinates.X
                + " " + robot.LastReachablePosition.Coordinates.Y
                + " " + _directions.Single(d => d.Value == robot.CurrentPosition.Direction).Key;

            if (!robot.CurrentPosition.Equals(robot.LastReachablePosition))
                output += " LOST";

            return output;
        }
    }
}
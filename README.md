# Design overview
IRobot - a martian vehicle that can move/operate on martian terrain. Has a position (RobotPosition - RobotDirection and Coordinates) and is able to move and turn itself to different directions (where and how to move is decided by implementations of IMovementStrategy). Can report its current position, also can inform the terrain coordinates system (ITerrainGrid) about dangerous positions after the robot moves outside of the reachable area.

ITerrainGrid - martian terrain coordinates system on which the robots move. Contains information about dangerous positions from which robots went outside the reachable area. Also contains extreme coordinates of the reachable area.

EarthControlCenter - the center from which operations on Mars is controlled. It is responsible for several things:
1. Controls all the operations on Mars - moving martian robots on martian terrain.
2. Parses string commands and returns output in string format.
3. Serves as an IOC-container and as a factory to create objects and resolve their dependencies.
In future it can be separated into different classes, but now timing ("deadline") does not allow it.


# Tests:
There is only one functional test available - the test from the requirements. There was no time to add new functional tests or write unit tests.
To run the test here is used a custom-written tests framework.


# Initial assumptions (including technical and business ones)
1. Robots can send signal to the base where they are. The control center is not able to send any signals to unreachable ("lost") robots.
2. Potential dangerous squares are marked after the robot has gone outside the reachable area.
3. One robot operates on only one terrain coordinates system. If there are many terrain coordinates systems, they do not overlap.
4. The earth control center is the only source of instructions for the robots. Robots can not move by their own.
5. All numerics restrictions and restrictions on input strings in the requirements are considered as trusted.
6. We can reload assembly whenever we want (related to using "const" field).
7. It is acceptable to use built-in GetHashCode method for custom value types (structs). (otherwise, we would have used bijective algorithm).


# Initial time estimation
- 30min - planning and designing. Making some assumptions
- 20min - setting up GitHub
- 1h - making the scaffolds (interfaces, classes without implementation, testing framework)
- 1h - implementation
- 1h - functional tests, debugging
- 30m - composing Readme, sending the result to the company
- 30m - reserve


# Actual time spent
- 30min - planning and designing. Making some assumptions
- 15min - setting up GitHub
- 1.5h - making the scaffolds (interfaces, classes without implementation, testing framework)
- 2h - implementation
- 30m - functional test (only one), debugging
- 45m - composing Readme, sending the result to the company

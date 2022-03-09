using MartianRobots.Earth;
using MartianRobots.Tests.Framework;

namespace MartianRobots.Tests
{
    [TestClass]
    public class FunctionalTests
    {
        [TestMethod]
        public static void SampleFromRequirements()
        {
            var input = @"5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL";

            var earthControlCenter = new EarthControlCenter();

            var output = earthControlCenter.SendInstructionsToMarsSinchronously(input);

            var expectedOutput = @"1 1 E
3 3 N LOST
2 3 S";

            if (output != expectedOutput)
                throw new TestsException(
                    "Sample data from the requirements is not processed correctly");
        }
    }
}
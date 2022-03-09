namespace MartianRobots.Earth
{
    internal interface IEarthControlCenter
    {
        /// <summary>
        ///    Performs the instructions on Martian base according to the input
        ///    sent from the Earth. 
        /// </summary>
        /// <param name="instructions">String instructions according to the rules.</param>
        /// <returns>String output according to the rules.</returns>
        string SendInstructionsToMarsSinchronously(string instructions);
    }
}
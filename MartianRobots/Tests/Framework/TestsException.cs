using System;

namespace MartianRobots.Tests.Framework
{
    public class TestsException : Exception
    {        
        public TestsException(string message) : base(message) {}
    }
}
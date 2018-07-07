using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space;
using System;

namespace UnitTest
{
    [TestClass]
    public class MovingAndRotatingAllAround
    {
        [TestMethod]
        public void CanMoveAndRotateAllAround()
        {
            // arrange  
            var rover = new PlutoRover(0, 0, CardinalDirection.North);
            //act
            rover.MakeCommand("FFRFF");
            //assert
            Assert.AreEqual("22East", rover.GetRoverCoordinatesAndDirection());
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException), "Command not supported")]

        public void CanMoveAllAround_WhenCommandNotRecognized_ShouldThrowException()
        {
            // arrange  
            var rover = new PlutoRover(0, 0, CardinalDirection.North);
            //act
            rover.MakeCommand("MickeyMouse");
        }
    }
}

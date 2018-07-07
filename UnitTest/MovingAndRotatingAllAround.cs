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
        public void TryMoveOneField_WhenObstacleOnThatField_ShouldReportIt()
        {
            // arrange  
            var rover = new PlutoRover(0, 0, CardinalDirection.North);
            rover.Surface[0, 1] = 1;
            //act
            rover.MakeCommand("F");
            //assert
            Assert.AreEqual("00North", rover.GetRoverCoordinatesAndDirection());
            Assert.IsTrue(rover.ObstacleDetected);
        }

        [TestMethod]
        public void TryMoveTwoField_WhenObstacleOnSecondField_CanMoveOneFieldAndReportObstacle()
        {
            // arrange  
            var rover = new PlutoRover(0, 0, CardinalDirection.North);
            rover.Surface[0, 2] = 1;
            //act
            rover.MakeCommand("FF");
            //assert
            Assert.AreEqual("01North", rover.GetRoverCoordinatesAndDirection());
            Assert.IsTrue(rover.ObstacleDetected);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException), "Command not supported")]

        public void CanMoveAllAround_WhenCommandNotSupported_ShouldThrowException()
        {
            // arrange  
            var rover = new PlutoRover(0, 0, CardinalDirection.North);
            //act
            rover.MakeCommand("MickeyMouse");
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space;
using System;

namespace UnitTest
{
    [TestClass]
    public class MovingForwardBackWordTest
    {
        [TestMethod]
        public void CanMoveForwardOneField()
        {
            // arrange  
            var rover = new PlutoRover(0, 0, CardinalDirection.North);
            //act
            rover.MakeCommand("F");
            //assert
            Assert.AreEqual("01North", rover.GetRoverCoordinatesAndDirection());
        }

        [TestMethod]
        public void CanMoveBackWardOneField()
        {
            // arrange  
            var rover = new PlutoRover(0, 1, CardinalDirection.North);
            //act
            rover.MakeCommand("B");
            //assert
            Assert.AreEqual("00North", rover.GetRoverCoordinatesAndDirection());
        }

        [TestMethod]
        public void CanMoveForward_WhenAtEdgeFacingNorth_CoordinateYEquals0()
        {
            // arrange  
            var rover = new PlutoRover(PlutoRover.SURFACE_SIZE-1, PlutoRover.SURFACE_SIZE - 1, CardinalDirection.North);
            //act
            rover.MakeCommand("F");
            //assert
            Assert.AreEqual(Convert.ToUInt32(0), rover.CoordinateY);
        }

        [TestMethod]
        public void CanMoveForward_WhenAt00FacingSouth_CoordinateXEquals0()
        {
            // arrange  
            var rover = new PlutoRover(0, 0, CardinalDirection.East);
            //act
            rover.MakeCommand("B");
            //assert
            Assert.AreEqual(Convert.ToUInt32(99), rover.CoordinateX);
        }
    }
}

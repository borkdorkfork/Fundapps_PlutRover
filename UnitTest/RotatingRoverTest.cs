using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space;

namespace UnitTest
{
    [TestClass]
    public class RotatingRoverTest
    {
        public void InitTest() { }
        [TestMethod]
        public void CanRotateRight_WhenDirectionIsNorth_OrientationShouldBeEast()
        {
            // arrange  
            var rover = new PlutoRover(0, 0, CardinalDirection.North, new int[100, 100] );
            //act
            rover.MakeCommand("R");
            //assert
            Assert.AreEqual(CardinalDirection.East, rover.RoverDirection);
        }


        [TestMethod]
        public void CanRotateLeft_WhenDirectionIsNorth_OrientationShouldBeEast()
        {
            // arrange  
            var rover = new PlutoRover(0, 0, CardinalDirection.North, new int[100, 100]);
            //act
            rover.MakeCommand("L");
            //assert
            Assert.AreEqual(CardinalDirection.West, rover.RoverDirection);
        }

        [TestMethod]
        public void CanRotateFullClockWise_WhenDirectionIsNorth_OrientationShouldBeNorth()
        {
            // arrange  
            var rover = new PlutoRover(0, 0, CardinalDirection.North, new int[100, 100]);
            //act
            rover.MakeCommand("RRRR");
            //assert
            Assert.AreEqual(CardinalDirection.North, rover.RoverDirection);
        }

        [TestMethod]
        public void CanRotateFullCounterClockWise_WhenDirectionIsNorth_OrientationShouldBeNorth()
        {
            // arrange  
            var rover = new PlutoRover(0, 0, CardinalDirection.North, new int[100, 100]);
            //act
            rover.MakeCommand("LLLL");
            //assert
            Assert.AreEqual(CardinalDirection.North, rover.RoverDirection);
        }
    }
}

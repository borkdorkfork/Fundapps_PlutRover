using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space;

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
    }
}

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
            var rover = new Space.PlutoRover(0, 0, CardinalDirection.North);
            //act
            rover.MakeCommand("F");
            //assert
            Assert.AreEqual("01North", rover.GetRoverCoordinatesAndDirection());
        }
    }
}

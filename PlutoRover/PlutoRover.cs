using System;

namespace Space
{
    public enum CardinalDirection { North, East, South, West };
    /// <summary>
    /// PlutoRover is vehicle for exploring surface of plantes. 
    /// It has position defined by ordered pair (x,y) Cartesian coordinate system which are properties CoordinateX, CoordinateY
    /// NOTE: Position can only be positive. Reason for this is that we are on surface which we transform to grid, so
    /// if our vehicle reaches the end of eny direction it will go back to beginning
    /// As well it has Orientation which can be north, west, east, south defined by Property CardinalDirection
    /// </summary>
   public class PlutoRover
    {
        /// <summary>
        /// In constructor we are setting default values for our rover. 
        /// Default direction, and orientation is 0,0,N
        /// </summary>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        /// <param name="direction"></param>
        public PlutoRover(uint coordinateX=0, uint coordinateY=0, CardinalDirection direction= CardinalDirection.North)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = CoordinateY;
            this.RoverDirection = direction;
        }

        /// <summary>
        /// Process input commands
        /// </summary>
        /// <param name="commands"></param>
        public void MakeCommand(string commands)
        {
            foreach (var command in commands)
            {
                if (command == 'F')
                    MoveForward();
            }
        }
        /// <summary>
        /// Move rover forward. Depending on direction rover can move either by X or by Y.
        /// </summary>
        private void MoveForward()
        {
            //Depending on orienatation and coordinates (x,y) rover moves accordingly
            //NORTH: (x,y) => (x, y+1)
            if (this.RoverDirection == CardinalDirection.North)
            {
                this.CoordinateY = this.CoordinateY+1;
            }
            //EAST: (x,y) => (x+1)
            else if (this.RoverDirection == CardinalDirection.East)
            {
                this.CoordinateX = this.CoordinateX + 1;
            }
            //SOUTH: (x,y) => (x, y-1)
            if (this.RoverDirection == CardinalDirection.South)
            {
                this.CoordinateY = this.CoordinateY + 1;
            }
            //WEST: (x,y) => (x-1, y)
            if (this.RoverDirection == CardinalDirection.West)
            {
                this.CoordinateX = this.CoordinateX - 1;
            }
        }
        
        /// <summary>
        /// Get rover coordinates and direction
        /// </summary>
        public string GetRoverCoordinatesAndDirection() => $"{this.CoordinateX}{this.CoordinateY}{this.RoverDirection}";

        private uint CoordinateX { get; set; }
        private uint CoordinateY { get; set; }
        private CardinalDirection RoverDirection { get; set; }
    }
}

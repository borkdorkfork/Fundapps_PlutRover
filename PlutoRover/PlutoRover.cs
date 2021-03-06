﻿using System;

namespace Space
{
    public enum CardinalDirection { North, East, South, West };
    /// <summary>
    /// PlutoRover is vehicle for exploring surface of plantes. 
    /// It has position defined by ordered pair (x,y) Cartesian coordinate system which are properties CoordinateX, CoordinateY
    /// NOTE: Position can only be positive. Reason for this is that we are on surface which we transform to grid, so
    /// if our vehicle reaches the end of eny direction it will go back to beginning
    /// As well it has direction which can be north, west, east, south defined by Property CardinalDirection
    /// </summary>
    public class PlutoRover
    {
        /// <summary>
        /// In constructor we are setting default values for our rover. 
        /// </summary>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        /// <param name="direction"></param>
        public PlutoRover(uint coordinateX, uint coordinateY, CardinalDirection direction)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
            this.RoverDirection = direction;
            this.Surface = new int[SURFACE_SIZE, SURFACE_SIZE];
        }

        /// <summary>
        /// Process input commands
        /// </summary>
        /// <param name="commands"></param>
        public void MakeCommand(string commands)
        {
            foreach (var command in commands)
            {
                if (ObstacleDetected == false)
                {
                    if (command == 'F')
                    {
                        MoveForward();
                    }
                    else if (command == 'B')
                    {
                        MoveBackWard();
                    }
                    //else we want to change direction of rover
                    else if (command == 'L' || command == 'R')
                    {
                        ChangeDirection(command);
                    }
                    else
                    {
                        throw new NotSupportedException($"Command not supported");
                    }

                    // If we detected obstacle on current field 
                    if (ObstacleDetected)
                    {
                        Console.WriteLine("Obstacle detected");
                    }
                }
                else
                {
                    if (ObstacleDetected)
                    {
                        Console.WriteLine("Obstacle detected");
                    }
                }

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
                if (!IsObstacleOnField(this.CoordinateX, CalculateNextCoordinateY()))
                {
                    this.CoordinateY = CalculateNextCoordinateY();
                }
            }
            //EAST: (x,y) => (x+1)
            else if (this.RoverDirection == CardinalDirection.East)
            {
                if (!IsObstacleOnField(CalculateNextCoordinateX(), this.CoordinateY))
                {
                    this.CoordinateX = CalculateNextCoordinateX();
                }
            }
            //SOUTH: (x,y) => (x, y-1)
            else if (this.RoverDirection == CardinalDirection.South)
            {
                if (!IsObstacleOnField(this.CoordinateX, CalculatePreviousCoordinateY()))
                {
                    this.CoordinateY = CalculatePreviousCoordinateY();
                }
            }
            //WEST: (x,y) => (x-1, y)
            else if (this.RoverDirection == CardinalDirection.West)
            {
                if (!IsObstacleOnField(CalculatePreviousCoordinateX(), this.CoordinateY))
                {
                    this.CoordinateX = this.CalculatePreviousCoordinateX();
                }
            }
        }

        /// <summary>
        /// Move rover backward. Depending on direction rover can move either by X or by Y.
        /// </summary>
        private void MoveBackWard()
        {
            //Depending on orienatation and coordinates (x,y) rover moves accordingly
            //NORTH: (x,y) => (x, y-1)
            if (this.RoverDirection == CardinalDirection.North)
            {
                if (!IsObstacleOnField(this.CoordinateX, CalculatePreviousCoordinateY()))
                {
                    this.CoordinateY = CalculatePreviousCoordinateY();
                }
            }
            //EAST: (x,y) => (x-1, y)
            else if (this.RoverDirection == CardinalDirection.East)
            {
                if (!IsObstacleOnField(CalculatePreviousCoordinateX(), this.CoordinateY))
                {
                    this.CoordinateX = this.CalculatePreviousCoordinateX();
                }
            }
            //SOUTH: (x,y) => (x, y+1)
            else if (this.RoverDirection == CardinalDirection.South)
            {
                if (!IsObstacleOnField(this.CoordinateX, CalculateNextCoordinateY()))
                {
                    this.CoordinateY = CalculateNextCoordinateY();
                }
            }
            //WEST: (x,y) => (x+1, y)
            else if (this.RoverDirection == CardinalDirection.West)
            {
                if (!IsObstacleOnField(CalculateNextCoordinateX(), this.CoordinateY))
                {
                    this.CoordinateX = CalculateNextCoordinateX();
                }
            }
        }
        /// <summary>
        /// Changing direction of rover
        /// </summary>
        private void ChangeDirection(Char command)
        {
            // ENUMS in C#  by default have values 0, 1, 2, 3. In our case North= 0, East = 1, South = 2, West = 3
            // so if we are for example on North and we Right expected direction is East 
            // which means we have to add + 1 to our direction
            if (command == 'R')
            {
                // If we are on the west and we want to move right expected direction should be North
                // since West = 3 and adding + 1 to direction we would get 4 condition is required
                if (this.RoverDirection + 1 > CardinalDirection.West)
                {
                    this.RoverDirection = CardinalDirection.North;
                }
                else
                {
                    this.RoverDirection = this.RoverDirection + 1;
                }
            }
            // else we want to move Left. 
            else
            {
                //  If we are on the North and want to move left expected direction is West
                // since North = 0 and North -1 would give us -1 we use condition to calculate West.
                if (this.RoverDirection - 1 < CardinalDirection.North)
                {
                    this.RoverDirection = CardinalDirection.West;
                }
                // if we are on East our direction = 1 and -1 would give as 0. Same goes for other direction
                else
                {
                    this.RoverDirection = this.RoverDirection - 1;
                }
            }

        }
        /// <summary>
        /// Get rover coordinates and direction
        /// </summary>
        public string GetRoverCoordinatesAndDirection() => $"{this.CoordinateX}{this.CoordinateY}{this.RoverDirection}";

        private uint CalculateNextCoordinateX() => this.CoordinateX == SURFACE_SIZE-1 ? 0 :   (this.CoordinateX + 1);
        private uint CalculateNextCoordinateY() => this.CoordinateY == SURFACE_SIZE-1 ? 0 : (this.CoordinateY + 1);
        private uint CalculatePreviousCoordinateX() => this.CoordinateX == 0 ? SURFACE_SIZE-1 : this.CoordinateX -1;
        private uint CalculatePreviousCoordinateY() => this.CoordinateY == 0 ? SURFACE_SIZE -1 : this.CoordinateY - 1;


        /// <summary>
        /// Check is there obstacle on surface field. On every check we update variable obstacle detected
        /// </summary>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        /// <returns></returns>
        private bool IsObstacleOnField(uint coordinateX, uint coordinateY) => ObstacleDetected = Surface[coordinateX, coordinateY] == 1;
        public uint CoordinateX { get; private set; }
        public uint CoordinateY { get; private set; }
        public CardinalDirection RoverDirection { get; private set; }
        public int[,] Surface { get; set; }
        public bool ObstacleDetected { get; private set; }
        public const uint SURFACE_SIZE = 100;
    }
}

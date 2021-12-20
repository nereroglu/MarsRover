namespace MarsRover.Library.Entities.Interfaces
{ 
    public  interface IPosition
    {
         int XCoordinate { get; set; }
         int YCoordinate { get; set; }
         DirectionType Direction { get; set; }
    }
}

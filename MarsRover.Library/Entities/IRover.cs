namespace MarsRover.Library.Entities.Interfaces
{
    public interface IRover
    {
        public IPosition MoveRover(IPlateau plateau, string actionCommand);
        public bool RoverInPlateau(IPlateau plateau);
    }
}

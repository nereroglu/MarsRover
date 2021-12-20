using MarsRover.Library.Entities.Interfaces;
using MarsRover.Library.Helper;
using System;
using System.Text.RegularExpressions;

namespace MarsRover.Library.Entities
{
    [Serializable]
    public class Rover : IRover
    {
        private Regex actionRegexPattern => new Regex("^[LRMlrm]+$");
        public static IPosition RoverPosition;

        #region singleton constructor
        private static Rover roverInstance = null;
        private Rover(IPosition roverStartPosition)
        {
            RoverPosition = roverStartPosition;
        }
        public static Rover GetRoverInstance(IPosition startPosition)
        {
            if (roverInstance == null)
            {
                roverInstance = new Rover(startPosition);
            }
            else if (startPosition != null)
            {
                RoverPosition = startPosition;
            }
            return roverInstance;
        }
        #endregion

        public IPosition MoveRover(IPlateau plateau, string actionCommand)
        {
            actionRegexPattern.IsMatchRegex(actionCommand);
            RoverInPlateau(plateau);

            var commandArry = actionCommand.ToUpper().Trim(' ').ToCharArray();
            foreach (var command in commandArry)
            {
                Move(Enum.Parse<ActionType>(command.ToString(), true));
                RoverInPlateau(plateau);
            }
            return RoverPosition;
        }

        public bool RoverInPlateau(IPlateau plateau)
        {
            if (RoverPosition.XCoordinate < 0 || RoverPosition.XCoordinate > plateau.XCoordinate)
                throw new Exception("Out of space!");
            if (RoverPosition.YCoordinate < 0 || RoverPosition.YCoordinate > plateau.YCoordinate)
                throw new Exception("Out of space!");
            return true;
        }

        #region private methods
        private void Move(ActionType action)
        {
            switch (action)
            {
                case ActionType.L: TurnLeft(); break;
                case ActionType.R: TurnRight(); break;
                case ActionType.M: MoveOneStep(); break;
            }
        }
        private void TurnLeft()
        {
            switch (RoverPosition.Direction)
            {
                case DirectionType.E:
                    RoverPosition.Direction = DirectionType.N; break;
                case DirectionType.W:
                    RoverPosition.Direction = DirectionType.S; break;
                case DirectionType.S:
                    RoverPosition.Direction = DirectionType.E; break;
                case DirectionType.N:
                    RoverPosition.Direction = DirectionType.W; break;
            }
        }
        private void TurnRight()
        {
            switch (RoverPosition.Direction)
            {
                case DirectionType.E:
                    RoverPosition.Direction = DirectionType.S; break;
                case DirectionType.W:
                    RoverPosition.Direction = DirectionType.N; break;
                case DirectionType.S:
                    RoverPosition.Direction = DirectionType.W; break;
                case DirectionType.N:
                    RoverPosition.Direction = DirectionType.E; break;
            }
        }
        private void MoveOneStep()
        {
            switch (RoverPosition.Direction)
            {
                case DirectionType.E:
                    RoverPosition.XCoordinate++;
                    break;
                case DirectionType.W:
                    RoverPosition.XCoordinate--;
                    break;
                case DirectionType.S:
                    RoverPosition.YCoordinate--;
                    break;
                case DirectionType.N:
                    RoverPosition.YCoordinate++;
                    break;
            }
        }
        #endregion
    }
}

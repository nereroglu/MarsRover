using MarsRover.Library.Entities.Interfaces;
using MarsRover.Library.Helper;
using System;
using System.Text.RegularExpressions;

namespace MarsRover.Library.Entities
{
    [Serializable]
    public class Position: IPosition
    {
        private Regex regexPattern => new Regex("^\\d+ \\d+ [NSWEnswe]$");

       public int XCoordinate { get; set; }        
       public  int YCoordinate { get; set; }
        public DirectionType Direction { get; set; }

        public Position() { }
        public Position(string inputStr) { InputStringToObject(inputStr); }

        private void InputStringToObject(string inputStr)
        {
            var inputArry = regexPattern.InputStringToArray(inputStr);
            XCoordinate = int.Parse(inputArry[0]);
            YCoordinate = int.Parse(inputArry[1]);
            DirectionType.TryParse(inputArry[2].ToUpper(), out DirectionType direction);
            Direction = direction;
        }
    }
}

using MarsRover.Library.Entities.Interfaces;
using MarsRover.Library.Helper;
using System;
using System.Text.RegularExpressions;

namespace MarsRover.Library.Entities
{
    [Serializable]
    public class Plateau :IPlateau
    {
        private Regex regexPattern => new Regex("^\\d+ \\d+$");
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Plateau() { }
        public Plateau(string inputStr) { InputStringToObject(inputStr); }

        private void InputStringToObject(string inputStr)
        {
            var inputArry = regexPattern.InputStringToArray(inputStr);
            XCoordinate = int.Parse(inputArry[0]);
            YCoordinate = int.Parse(inputArry[1]);
        }
    }
}

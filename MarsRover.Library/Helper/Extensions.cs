using System;
using System.Text.RegularExpressions;

namespace MarsRover.Library.Helper
{
    public static class Extensions
    {
        public static string[] InputStringToArray(this Regex regexPattern, string inputStr)
        {
            regexPattern.IsMatchRegex(inputStr);
            return inputStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
        public static bool IsMatchRegex(this Regex regexPattern, string inputStr)
        {
            if (!regexPattern.IsMatch(inputStr)) throw new Exception("Input pattern error!");
            return true;
        }


    }
}

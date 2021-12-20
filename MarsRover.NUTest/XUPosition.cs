using MarsRover.Library;
using MarsRover.Library.Entities;
using Newtonsoft.Json;
using System;
using Xunit;

namespace MarsRover.NUTest
{
    public class XUPosition
    {
        [Theory]
        [InlineData("1 2 N")]
        public void TestCaseInput(string input)
        {
            var expected = new Position { XCoordinate = 1, YCoordinate = 2, Direction = DirectionType.N };
            var actual = new Position(input);
            Assert.NotNull(actual);
            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }

        [Theory]
        [InlineData(new object[] { "c 4 N", "Input pattern error!" })]
        public void TestCaseInputNotMatchRegex(string input, string errorMessage)
        {
            var exception = Assert.Throws<Exception>(() => new Position(input));
            Assert.Equal(errorMessage, exception.Message);
        }
    }
}
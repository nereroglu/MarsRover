using MarsRover.Library.Entities;
using Newtonsoft.Json;
using System;
using Xunit;

namespace MarsRover.NUTest
{
    public class XUPlateau
    {
        [Theory]
        [InlineData("3 5")]
        public void TestCaseInput(string input)
        {
            var expected = new Plateau { XCoordinate = 3, YCoordinate = 5 };
            var actual = new Plateau(input);
            Assert.NotNull(actual);
            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }

        [Theory]
        [InlineData(new object[] { "3 A", "Input pattern error!" })]
        public void TestCaseInputNotMatchRegex(string input, string errorMessage)
        {
            var exception = Assert.Throws<Exception>(() => new Plateau(input));
            Assert.Equal(errorMessage, exception.Message);
        }
    }
}
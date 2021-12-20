using FluentAssertions;
using MarsRover.Library;
using MarsRover.Library.Entities;
using Newtonsoft.Json;
using System;
using Xunit;

namespace MarsRover.NUTest
{
    public class XURover
    {
        [Theory]
        [InlineData(new object[] { "5 5", "1 2 N", "LMLMLMLMM", "1 3 N" })]
        public void TestCaseMovementRover(string plateau, string startPosition, string moveList, string lastPosition)
        {
            var expected = new Position { XCoordinate = 1, YCoordinate = 3, Direction = DirectionType.N };
            var actual = new Position(lastPosition);
            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));

            var startPos = new Position(startPosition);
            var plt = new Plateau(plateau);

            var rover = Rover.GetRoverInstance(startPos);
            var roverLastPosition = Rover.GetRoverInstance(startPos).MoveRover(plt, moveList);

            Assert.NotNull(rover);
            Assert.Equal(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(roverLastPosition));
        }

        [Theory]
        [InlineData(new object[] { "5 5", "5 2 E", "MM", "Out of space!" })]
        public void TestCaseMovementRoverOutOfSpace(string plateau, string startPosition, string moveList, string errorMessage)
        {
            var expected = new Position { XCoordinate = 5, YCoordinate = 2, Direction = DirectionType.E };            
            var pos = new Position(startPosition);            
            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(pos));

            var plt = new Plateau(plateau);
            var rover = Rover.GetRoverInstance(pos);

            var exception = Assert.Throws<Exception>(() => rover.MoveRover(plt, moveList));
            Assert.Equal(errorMessage, exception.Message);
        }

        [Theory]
        [InlineData(new object[] { "5 5", "3 3 E", "MMRMMRMRRM" })]
        public void TestCaseMovementRover2(string plateau, string startPosition, string moveList)
        {
            var plt = new Plateau(plateau);
            var pos = new Position(startPosition);

            var rover = Rover.GetRoverInstance(pos);
            var roverLastPosition = rover.MoveRover(plt, moveList);

            rover.Should().NotBeNull();
            //5 1 E
            roverLastPosition.XCoordinate.Should().Be(5);
            roverLastPosition.YCoordinate.Should().Be(1);
            roverLastPosition.Direction.Should().Be(DirectionType.E);
        }

        [Theory]
        [InlineData(new object[] { "5 5", "1 2 W", "acML", "Input pattern error!" })]
        public void TestCaseInputNotMatchRegex(string plateau, string startPosition, string moveList, string errorMessage)
        {
            var expected = new Position { XCoordinate = 1, YCoordinate = 2, Direction = DirectionType.W };
            var pos = new Position(startPosition);
            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(pos));

            var plt = new Plateau(plateau);
            Assert.NotNull(plt);
            var rover = Rover.GetRoverInstance(pos);

            var exception = Assert.Throws<Exception>(() => rover.MoveRover(plt, moveList));
            Assert.Equal(errorMessage, exception.Message);
        }
    }
}
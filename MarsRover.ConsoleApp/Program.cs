using MarsRover.Library.Entities;
using MarsRover.Library.Entities.Interfaces;
using System;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlateau plateau;
            IPosition position;

            Console.WriteLine("# Exit = Q # \nPlease enter parameters  \nPlateau -> ");
            var plateauStr = Console.ReadLine();
            plateau = new Plateau(plateauStr);
            Console.WriteLine($"Plateau created ... {plateau.XCoordinate} , {plateau.YCoordinate}");

            Console.WriteLine("Start Position -> "); 
            var positionStr = Console.ReadLine();
            position = new Position(positionStr);
            var rover = Rover.GetRoverInstance(position);
            Console.WriteLine($"rover is ready for position : {position.XCoordinate} , {position.YCoordinate} , {position.Direction}");

            Console.WriteLine("RoverActions -> ");
            var actionListStr = Console.ReadLine();
            Console.WriteLine($"Action list ... {actionListStr}");

            Console.WriteLine($"Rover moving....");
            var lastPosition = rover.MoveRover(plateau, actionListStr);

            Console.WriteLine($"Rover last position : {lastPosition.XCoordinate} {lastPosition.YCoordinate} {lastPosition.Direction}");

            Console.WriteLine("finish... ");

            while (Console.ReadKey().Key != ConsoleKey.Q)
            {
            }
        }
    }
}

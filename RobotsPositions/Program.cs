using RobotsPositions.Enums;
using RobotsPositions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsPositions
{


    internal class Program
    {
        static void Main(string[] args)
        {
            var xRec = 5;
            var yRec = 3;
            List<Location> goodSmells = new List<Location>();

            Location l = new Location { X = 1, Y = 1, Orientation = Orientation.E };
            l = l.GetNewLocation(xRec, yRec, l.X, l.Y, l.Orientation, "RFRFRFRF", goodSmells);
            Console.WriteLine(l);

            l = new Location { X = 3, Y = 2, Orientation = Orientation.N };
            l = l.GetNewLocation(xRec, yRec, l.X, l.Y, l.Orientation, "FRRFLLFFRRFLL", goodSmells);
            Console.WriteLine(l);

            l = new Location { X = 0, Y = 3, Orientation = Orientation.W };
            l = l.GetNewLocation(xRec, yRec, l.X, l.Y, l.Orientation, "LLFFFLFLFL", goodSmells);
            Console.WriteLine(l);
            Console.ReadLine();
        }
    }
}

using RobotsPositions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsPositions.Models
{
    public class Location
    {
        public bool Lost { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Orientation Orientation { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", X, Y, Orientation, Lost? "LOST" : string.Empty);
        }

        public  Location MoveForward(int xLimit, int yLimit, int x, int y, Orientation o, List<Location> goodSmells, bool lost = false)
        {
            Location newLocation = null;
            switch (o)
            {
                case Orientation.N:
                    newLocation = new Location { X = x, Y = y + 1, Orientation = o };
                    break;
                case Orientation.S:
                    newLocation = new Location { X = x, Y = y - 1, Orientation = o };
                    break;
                case Orientation.E:
                    newLocation = new Location { X = x + 1, Y = y, Orientation = o };
                    break;
                case Orientation.W:
                    newLocation = new Location { X = x - 1, Y = y, Orientation = o };
                    break;
                default:
                    return null;
            }
            var newLocationIsLost = Logic.NewLocIsLost(newLocation.X, newLocation.Y, xLimit, yLimit);
            Location currentLocation = new Location { X = x, Y = y, Orientation = o, Lost = false };
            if (!lost && newLocationIsLost && goodSmells.Any(s=> s.X == currentLocation.X && s.Y == currentLocation.Y)/* doesn't work I don't have enough time to investigate it: goodSmells.Contains(currentLocation)*/)
            {
                return new Location { X = x, Y = y, Orientation = o, Lost = false };
            }
            else if (!lost && newLocationIsLost)
            {
                goodSmells.Add(new Location { X = x, Y = y });
            }

            if (lost || newLocationIsLost)
            {
                return new Location { X = x, Y = y, Orientation = o, Lost = true };
            }
            return newLocation;
        }

        public Location MoveLeft(int xLimit, int yLimit, int x, int y, Orientation o, List<Location> goodSmells, bool lost = false)
        {
            Location newLocation = null;
            switch (o)
            {
                case Orientation.N:
                    newLocation = new Location { Orientation = Orientation.W, X = x, Y = y };
                    break;
                case Orientation.S:
                    newLocation = new Location { Orientation = Orientation.E, X = x, Y = y };
                    break;
                case Orientation.E:
                    newLocation = new Location { Orientation = Orientation.N, X = x, Y = y };
                    break;
                case Orientation.W:
                    newLocation = new Location { Orientation = Orientation.S, X = x, Y = y };
                    break;
                default:
                    return null;
            }
            var newLocationIsLost = Logic.NewLocIsLost(newLocation.X, newLocation.Y, xLimit, yLimit);
            if (!lost && newLocationIsLost && goodSmells.Contains(new Location { X = x, Y = y }))
            {
                return new Location { X = x, Y = y, Orientation = o, Lost = false };
            }
            else if (!lost && newLocationIsLost)
            {
                goodSmells.Add(new Location { X = x, Y = y });
            }

            if (lost || newLocationIsLost)
            {
                return new Location { X = x, Y = y, Orientation = o, Lost = true };
            }
            return newLocation;
        }

        public Location MoveRight(int xLimit, int yLimit, int x, int y, Orientation o, List<Location> goodSmells, bool lost = false)
        {
            Location newLocation = null;
            switch (o)
            {
                case Orientation.N:
                    newLocation = new Location { Orientation = Orientation.E, X = x, Y = y };
                    break;
                case Orientation.S:
                    newLocation = new Location { Orientation = Orientation.W, X = x, Y = y };
                    break;
                case Orientation.E:
                    newLocation = new Location { Orientation = Orientation.S, X = x, Y = y };
                    break;
                case Orientation.W:
                    newLocation = new Location { Orientation = Orientation.N, X = x, Y = y };
                    break;
                default:
                    return null;
            }
            var newLocationIsLost = Logic.NewLocIsLost(newLocation.X, newLocation.Y, xLimit, yLimit);
            if (!lost && newLocationIsLost && goodSmells.Contains(new Location { X = x, Y = y }))
            {
                return new Location { X = x, Y = y, Orientation = o, Lost = false };
            }
            else if (!lost && newLocationIsLost)
            {
                goodSmells.Add(new Location { X = x, Y = y });
            }

            if (lost || newLocationIsLost)
            {
                return new Location { X = x, Y = y, Orientation = o, Lost = true };
            }
            return newLocation;
        }
        public Location GetNewLocation(int xLimit, int yLimit, int x, int y, Orientation o, string movements, List<Location> goodSmells)
        {
            Location l = new Location { Orientation = o, X = x, Y = y };
            foreach (char movement in movements.ToCharArray())
            {
                switch (movement)
                {
                    case 'R':
                        l = MoveRight(xLimit, yLimit, l.X, l.Y, l.Orientation, goodSmells, l.Lost);
                        break;
                    case 'L':
                        l = MoveLeft(xLimit, yLimit, l.X, l.Y, l.Orientation, goodSmells, l.Lost);
                        break;
                    case 'F':
                        l = MoveForward(xLimit, yLimit, l.X, l.Y, l.Orientation, goodSmells, l.Lost);
                        break;

                }
                //Console.WriteLine(l);
            }

            return l;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsPositions.Models
{
    public static class Logic
    {
        public static bool PointOutRectangle(int x, int y, int xRec, int yRec)
        {
            return y < 0 || x < 0 || x > xRec || y > yRec;
        }

        public static bool NewLocIsLost(int x, int y, int xRec, int yRec)
        {
            return PointOutRectangle(x, y, xRec, yRec);
        }
    }
}

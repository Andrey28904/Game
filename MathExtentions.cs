using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Size = System.Drawing.Size;
using Point = System.Drawing.Point;

namespace TheGame
{
    public static class MathExtentions
    {
        public static double Clamp(double value, double floor, double ceil)
            => Math.Min(Math.Max(value, floor), ceil);

        public static Vector GetVector(Point point)
            => new Vector(point.X, point.Y);

        public static Point GetPoint(Vector point)
            => new Point((int)Math.Round(point.X), (int)Math.Round(point.Y));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using Size = System.Drawing.Size;
using Point = System.Drawing.Point;

namespace TheGame
{
    public enum AllTypesOfObjects
    {
        WorldGeometry,
        Box
    }

    public class GameObject
    {
        public Vector RealPos = new Vector(0, 0);
        public Point Pos => MathExtentions.GetPoint(RealPos);

        public Size Size = new Size(0, 0);

        public Trigger Collider;

        public Point Center => new Point(Pos.X + Size.Width / 2, Pos.Y + Size.Height / 2);

        public AllTypesOfObjects Type = AllTypesOfObjects.WorldGeometry;

        public IEnumerable<Point> GetAllPoints()
        {
            yield return Pos;
            yield return new Point(Pos.X + Size.Width, Pos.Y);
            yield return new Point(Pos.X + Size.Width, Pos.Y + Size.Height);
            yield return new Point(Pos.X, Pos.Y + Size.Height);
        }

        public IEnumerable<Point[]> GetPairsOfAllPoints()
        {
            var allPoints = GetAllPoints().ToArray();
            for(int i = 0; i < allPoints.Length; i++)
                yield return new[] { allPoints[i], allPoints[(i + 1) % allPoints.Length] };
        }

        public IEnumerable<Point> GetMiddlePoints()
        {
            var allPairs = GetPairsOfAllPoints();
            foreach(var pair in allPairs)
                yield return new Point((pair[0].X + pair[1].Y) / 2, (pair[0].Y + pair[1].Y) / 2);
        }

        public GameObject() { }
        public GameObject(Point pos, Size size, AllTypesOfObjects type)
        {
            RealPos = MathExtentions.GetVector(pos);
            Size = size;
            Type = type;
        }
    }
}

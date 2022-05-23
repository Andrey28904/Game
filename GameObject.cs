using System.Collections.Generic;
using System.Linq;
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

        public GameObject() { }
        public GameObject(Point pos, Size size, AllTypesOfObjects type)
        {
            RealPos = MathExtentions.GetVector(pos);
            Size = size;
            Type = type;
        }
    }
}

using System.Linq;
using System.Windows;
using Size = System.Drawing.Size;
using Point = System.Drawing.Point;

namespace TheGame
{
    public class Trigger : GameObject
    {
        public Trigger(Point centerPos, Size size)
        {
            Size = size;
            RealPos = new Vector(centerPos.X - Size.Width / 2, centerPos.Y - Size.Height / 2);
        }

        public void RefreshPos(Point newCenterPos)
        {
            RealPos = new Vector(newCenterPos.X - Size.Width / 2, newCenterPos.Y - Size.Height / 2);
        }

        public bool OnTouch(GameObject obj)
        {
            foreach (var point in obj.Collider.GetAllPoints())
                if (IsInsideSize(point))
                    return true;
            foreach(var pair in obj.Collider.GetPairsOfAllPoints())
            {
                var newPair = pair.OrderBy((rec) => rec.X).ThenBy((rec) => rec.Y).ToArray();
                var leftUpPoint = RealPos;
                var rightDownPoint = RealPos + new Vector(Size.Width, Size.Height);
                if (newPair[0].X <= leftUpPoint.X && newPair[1].X >= rightDownPoint.X
                    && newPair[0].Y >= leftUpPoint.Y && newPair[0].Y <= rightDownPoint.Y)
                    return true;
                if (newPair[0].Y <= leftUpPoint.Y && newPair[1].Y >= rightDownPoint.Y
                    && newPair[0].X >= leftUpPoint.X && newPair[0].X <= rightDownPoint.X)
                    return true;
            }
            return false;
        }

        public bool IsInsideSize(Point point)
        {
            var leftUpPoint = RealPos;
            var rightDownPoint = RealPos + new Vector(Size.Width, Size.Height);
            if (point.X >= leftUpPoint.X && point.X <= rightDownPoint.X
                && point.Y <= rightDownPoint.Y && point.Y >= leftUpPoint.Y)
                return true;
            return false;
        }
    }
}

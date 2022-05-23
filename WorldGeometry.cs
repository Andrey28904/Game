using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using TheGame.Interfaces;
using Size = System.Drawing.Size;
using Point = System.Drawing.Point;

namespace TheGame
{
    class WorldGeometry : GameObject, IPhysics, IDraw
    {
        public bool IsStatic { get; set; } = true;
        public Vector Speed { get; set; } = new Vector(0, 0);
        public double Mass { get; set; } = 1000;
        public double Bounce { get; set; } = 0;
        public double Friction { get; set; } = 1;
        public WorldGeometry(Point pos, Size size)
        {
            Type = AllTypesOfObjects.WorldGeometry;
            RealPos = MathExtentions.GetVector(pos);
            Size = size;
            Collider = new Trigger(Center, Size);
        }
        public WorldGeometry(Point pos, Size size, bool isTransparent)
        {
            Type = AllTypesOfObjects.WorldGeometry;
            RealPos = MathExtentions.GetVector(pos);
            Size = size;
            if (!isTransparent)
                Collider = new Trigger(Center, Size);
            else
                Collider = new Trigger(new Point(0, 0), new Size(0, 0));
        }
        public WorldGeometry(Point pos, Size size, bool isTransparent, Brush color)
        {
            Type = AllTypesOfObjects.WorldGeometry;
            RealPos = MathExtentions.GetVector(pos);
            Size = size;
            if (!isTransparent)
                Collider = new Trigger(Center, Size);
            else
                Collider = new Trigger(new Point(0, 0), new Size(0, 0));
            Color = color;
        }

        public void Move() { }
        public IEnumerable<GameObject> GetNearCollisions()
            => null;
        public void ClampSpeed(double min, double max) { }
        public void RefreshAllTriggers() { }

        public void AddImpulse(Vector speedImpulse) { }

        public Brush Color { get; set; } = Brushes.Gray;
        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Color, new Rectangle(Pos, Size));
        }
    }
}

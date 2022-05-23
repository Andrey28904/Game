using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using TheGame.Interfaces;
using Size = System.Drawing.Size;
using Point = System.Drawing.Point;
using static TheGame.Game;
using static TheGame.Physics;

namespace TheGame
{
    public class Box : GameObject, IPhysics, IDraw
    {
        public bool IsStatic { get; set; } = false;
        public Vector Speed { get; set; } = new Vector(0, 0);
        public double Mass { get; set; } = 10;
        public double Bounce { get; set; } = 0.3;
        public double Friction { get; set; } = 2d;

        public Box(Point pos, Size size, Size sizeSearch)
        {
            Type = AllTypesOfObjects.Box;
            RealPos = MathExtentions.GetVector(pos);
            Size = size;
            Collider = new Trigger(Center, Size);
        }
        public Box(Point pos, Size size, double mass)
        {
            Type = AllTypesOfObjects.Box;
            RealPos = MathExtentions.GetVector(pos);
            Size = size;
            Collider = new Trigger(Center, Size);
            Mass = mass;
        }
        public Box(Point pos, Size size, double mass, double bounce)
        {
            Type = AllTypesOfObjects.Box;
            RealPos = MathExtentions.GetVector(pos);
            Size = size;
            Collider = new Trigger(Center, Size);
            Mass = mass;
            Bounce = bounce;
        }
        public Box(Point pos, Size size, double mass, double bounce, double friction)
        {
            Type = AllTypesOfObjects.Box;
            RealPos = MathExtentions.GetVector(pos);
            Size = size;
            Collider = new Trigger(Center, Size);
            Mass = mass;
            Bounce = bounce;
            Friction = friction;
        }
        public Box(Point pos, Size size, double mass, double bounce, double friction, Brush color)
        {
            Type = AllTypesOfObjects.Box;
            RealPos = MathExtentions.GetVector(pos);
            Size = size;
            Collider = new Trigger(Center, Size);
            Mass = mass;
            Bounce = bounce;
            Friction = friction;
            Color = color;
        }

        public void Move()
        {
            RealPos = new Vector(RealPos.X + Speed.X, RealPos.Y + Speed.Y);
            if (Speed.X >= 0)
                Speed = new Vector(Math.Max(Speed.X - Friction * FromFrame, 0), Speed.Y + Gravity);
            else
                Speed = new Vector(Math.Min(Speed.X + Friction * FromFrame, 0), Speed.Y + Gravity);
            ClampSpeed(-MaxSpeed, MaxSpeed);
            RefreshAllTriggers();
            foreach (var phys in GetNearCollisions())
                DoCollision(this, phys);
        }

        public IEnumerable<GameObject> GetNearCollisions()
        {
            foreach (var phys in AllObjects)
                if (phys as IPhysics != null && phys != this)
                    if (Collider.OnTouch(phys))
                        yield return phys;
        }

        public void RefreshAllTriggers() 
        {
            Collider.RefreshPos(Center);
        }

        public void AddImpulse(Vector speedImpulse)
        {
            Speed += speedImpulse / Mass;
            ClampSpeed(-MaxSpeed, MaxSpeed);
        }

        public void ClampSpeed(double min, double max)
        {
            Speed = new Vector(MathExtentions.Clamp(Speed.X, min, max),
                               MathExtentions.Clamp(Speed.Y, min, max));
        }

        public Brush Color { get; set; } = Brushes.Brown;
        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Color, new Rectangle(Pos, Size));
            foreach (var points in GetPairsOfAllPoints())
                graphics.DrawLine(new Pen(Brushes.RosyBrown, 2), points[0], points[1]);
        }
    }
}

using System.Linq;
using TheGame.Interfaces;
using System.Windows;

namespace TheGame
{
    public static class Physics
    {
        public static readonly double MaxSpeed = 20;
        public static void DoCollision(GameObject obj1, GameObject obj2)
        {
            var moveableObject = GetMoveableObject(obj1, obj2);
            var staticObject = moveableObject != obj1 ? obj1 : obj2;
            var IPhysMove = moveableObject as IPhysics;
            var IPhysStatic = staticObject as IPhysics;
            var offsetVector = GetOffsetVector(moveableObject, staticObject);
            moveableObject.RealPos = new Vector(moveableObject.RealPos.X + offsetVector.X, moveableObject.RealPos.Y + offsetVector.Y);
            var moveImpulseWithBounce = new Vector(0, 0);
            var statAddImpulseFromMove = new Vector(0, 0);
            var statImpulseWithBounce = new Vector(0, 0);
            var moveAddImpulseFromStat = new Vector(0, 0);
            if (offsetVector.X != 0)
            {
                moveImpulseWithBounce = new Vector(-IPhysMove.Speed.X * IPhysMove.Mass * (1 + IPhysMove.Bounce), 0);
                statAddImpulseFromMove = new Vector(IPhysMove.Speed.X * IPhysMove.Mass * (1 - IPhysMove.Bounce), 0);
                statImpulseWithBounce = new Vector(-IPhysStatic.Speed.X * IPhysStatic.Mass * (1 + IPhysStatic.Bounce), 0);
                moveAddImpulseFromStat = new Vector(IPhysStatic.Speed.X * IPhysStatic.Mass * (1 - IPhysStatic.Bounce), 0);
            }
            if(offsetVector.Y != 0)
            {
                moveImpulseWithBounce = new Vector(0, -IPhysMove.Speed.Y * IPhysMove.Mass * (1 + IPhysMove.Bounce));
                statAddImpulseFromMove = new Vector(0, IPhysMove.Speed.Y * IPhysMove.Mass * (1 - IPhysMove.Bounce));
                statImpulseWithBounce = new Vector(0, -IPhysStatic.Speed.Y * IPhysStatic.Mass * (1 + IPhysStatic.Bounce));
                moveAddImpulseFromStat = new Vector(0, IPhysStatic.Speed.Y * IPhysStatic.Mass * (1 - IPhysStatic.Bounce));
            }
            IPhysMove.AddImpulse(moveImpulseWithBounce + moveAddImpulseFromStat);//New Move + From Static to Move
            IPhysStatic.AddImpulse(statImpulseWithBounce + statAddImpulseFromMove);//New Static + From Move to Static
        }

        private static GameObject GetMoveableObject(GameObject obj1, GameObject obj2)
        {
            var IPhys1 = obj1 as IPhysics;
            var IPhys2 = obj2 as IPhysics;
            if (IPhys1.IsStatic)
                return obj2;
            if (IPhys2.IsStatic)
                return obj1;
            if (IPhys1.Speed.Length > IPhys2.Speed.Length)
                return obj1;
            return obj2;
        }

        private static Vector GetOffsetVector(GameObject move, GameObject stat)
        {
            var allOffsetVectors = new[]
            {
                new Vector(stat.RealPos.X + stat.Size.Width - move.RealPos.X + 0.4, 0),//Right
                new Vector(stat.RealPos.X - move.Size.Width - move.RealPos.X - 0.4, 0),//Left
                new Vector(0, stat.RealPos.Y - move.Size.Height - move.RealPos.Y - 0.4),//Up
                new Vector(0, stat.RealPos.Y + stat.Size.Height - move.RealPos.Y + 0.4)//Down
            };
            return allOffsetVectors.OrderBy((rec) => rec.Length).First();
        }
    }
}

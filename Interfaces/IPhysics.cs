using System.Collections.Generic;
using System.Windows;

namespace TheGame.Interfaces
{
    public interface IPhysics
    {
        /// <summary>
        /// WORLD GEOMETRY or Not
        /// </summary>
        bool IsStatic { get; set; }

        /// <summary>
        /// Only for non-static Objects
        /// Current Speed of object
        /// </summary>
        Vector Speed { get; set; }

        /// <summary>
        /// Clamping Speed Between min and max
        /// </summary>
        /// <param name="min">minimum speed</param>
        /// <param name="max">maximum speed</param>
        void ClampSpeed(double min, double max);

        /// <summary>
        /// Mass of Physics Object (in KGs)
        /// </summary>
        double Mass { get; set; }

        /// <summary>
        /// Add impulse to this GameObject
        /// </summary>
        /// <param name="speedImpulse">Value to add</param>
        void AddImpulse(Vector speedImpulse);

        /// <summary>
        /// Ability of an object to bounce
        /// Must be between 0.0 and 1.0
        /// </summary>
        double Bounce { get; set; }

        /// <summary>
        /// Friction Speed.X When Collide
        /// </summary>
        double Friction { get; set; }

        /// <summary>
        /// Only for non-static Objects
        /// </summary>
        void Move();

        /// <summary>
        /// Get All GameObjects which must do collision at current frame
        /// </summary>
        /// <param name="pos">Position to collide</param>
        /// <returns></returns>
        IEnumerable<GameObject> GetNearCollisions();

        /// <summary>
        /// Set new pos for All triggers
        /// </summary>
        void RefreshAllTriggers();
    }
}

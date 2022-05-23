using System.Drawing;

namespace TheGame.Interfaces
{
    public interface IDraw
    {
        /// <summary>
        /// Color to Draw
        /// </summary>
        Brush Color { get; set; }

        /// <summary>
        /// Function of Drawing for visible Entities
        /// </summary>
        /// <param name="graphics">Form Graphics</param>
        void Draw(Graphics graphics);
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheGame
{
    public class Level1
    {
        public static readonly List<GameObject> ListOfAllEntitiesOnLevel1 = new List<GameObject>
        {
            new Box(new Point(120, 40), new Size(40, 40), 50, 0, 1.8, Brushes.GreenYellow),
            new WorldGeometry(new Point(20, 60), new Size(300, 20)),
            new Box(new Point(340, 40), new Size(60, 60), 20),
            new WorldGeometry(new Point(100, 800), new Size(500, 20)),
            new Box(new Point(340, 500), new Size(80, 80), 40, 0.1),
            new Box(new Point(350, 200), new Size(30, 30), 50, 0.7),
            new Box(new Point(360, -20), new Size(35, 35), 20, 0.4),
            new Box(new Point(600, 500), new Size(80, 80), 40, 0.1),
            new Box(new Point(800, 500), new Size(40, 80), 60, 0),
            new Box(new Point(360, 380), new Size(60, 40), 40, 0),
            new Box(new Point(500, 380), new Size(100, 100), 400, 0),
            new WorldGeometry(new Point(600, 600), new Size(20, 200)),
            new WorldGeometry(new Point(600, 600), new Size(280, 20)),
            new WorldGeometry(new Point(600, 600), new Size(20, 200)),
            new WorldGeometry(new Point(80, 400), new Size(20, 400)),
            new WorldGeometry(new Point(900, 200), new Size(20, 400))
        };
    }
}

using System.Collections.Generic;
using System.Drawing;

namespace TheGame
{
    public class Level1
    {
        public static readonly List<GameObject> ListOfAllEntitiesOnLevel1 = new List<GameObject>
        {
            new WorldGeometry(new Point(0, 800), new Size(600, 160), true, Brushes.DarkRed),//LoseZone
            new WorldGeometry(new Point(600, 800), new Size(400, 120), true, Brushes.Green),//WinZone

            new Box(new Point(30, 150), new Size(40, 40), 50, 0.3, 1.8, Brushes.GreenYellow),

            new Box(new Point(160, 150), new Size(30, 30), 20, 0.45, 2d, Brushes.DarkGreen),

            new Box(new Point(780, 150), new Size(40, 80), 60, 0.2, 2.0d, Brushes.DarkGreen),
            new Box(new Point(600, 550), new Size(50, 50), 60, 0.3, 5, Brushes.DarkGreen),
            new Box(new Point(610, 160), new Size(60, 35), 45, 0.45, 4, Brushes.DarkRed),
            new Box(new Point(615, 25), new Size(35, 35), 33, 0.4, 4, Brushes.DarkRed),

            new Box(new Point(180, 200), new Size(40, 40), 40, 0.2, 2, Brushes.DarkRed),
            new Box(new Point(240, 200), new Size(30, 30), 40, 0.2, 2, Brushes.DarkGreen),
            new Box(new Point(320, 600), new Size(50, 50), 50, 0.2, 2, Brushes.DarkGreen),


            new WorldGeometry(new Point(0, 250), new Size(180, 20)),
            new WorldGeometry(new Point(140, 500), new Size(180, 20)),
            new WorldGeometry(new Point(200, 800), new Size(400, 20)),
            new WorldGeometry(new Point(600, 600), new Size(240, 20)),
            new WorldGeometry(new Point(600, 800), new Size(20, 140)),
            new WorldGeometry(new Point(600, 920), new Size(400, 20)),
            new WorldGeometry(new Point(0, 0), new Size(20, 940)),
            new WorldGeometry(new Point(0, 940), new Size(620, 20)),
            new WorldGeometry(new Point(0, 0), new Size(980, 20)),
            new WorldGeometry(new Point(980, 0), new Size(20, 940))
        };
    }
}

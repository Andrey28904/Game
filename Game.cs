using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using TheGame.Interfaces;
using Timer = System.Windows.Forms.Timer;
using System.Windows;
using Size = System.Drawing.Size;
using System.Drawing;

namespace TheGame
{
    public class Game : Form
    {
        public static readonly int FrameDelay = 7;
        public static readonly int HUDFrameDelay = 30;
        public static readonly List<Timer> ListOfAllTimers = new List<Timer>();

        public static double FromFrame => (double)FrameDelay / 1000;
        public static double Gravity => 30 * FromFrame;

        public static readonly List<GameObject> AllObjects = Level1.ListOfAllEntitiesOnLevel1;

        public Game()
        {
            DoubleBuffered = true;
            ClientSize = new Size(1000, 1000);
            BackColor = Color.AliceBlue;

            ListOfAllTimers.Add(CreateTimer(FrameDelay, "PhysAndDraw", new Action[] {RefreshPhysics, Invalidate}));
        }

        public Timer CreateTimer(int interval, string tag, Action[] methods)
        {
            var newTimer = new Timer { Interval = interval, Tag = tag };
            newTimer.Tick += (sender, args) =>
            {
                var thread = new Thread(() =>
                {
                    foreach (var action in methods)
                        action();
                });
                thread.Start();
            };
            newTimer.Start();
            return newTimer;
        }

        public void RefreshPhysics()
        {
            var physObjects = AllObjects
                .Where((obj) => obj as IPhysics != null)
                .Where((obj) => !((IPhysics)obj).IsStatic)
                .OrderBy((obj) => obj.Pos.Y)
                .Select((obj) => obj as IPhysics);
            foreach (var obj in physObjects)
                obj.Move();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var allDrawObjects = AllObjects
                .Where((obj) => obj as IDraw != null)
                .Select((obj) => obj as IDraw);
            foreach (var obj in allDrawObjects)
                obj.Draw(e.Graphics);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                (AllObjects[2] as IPhysics).AddImpulse(new Vector(0, -100));
            if (e.KeyCode == Keys.S)
                (AllObjects[2] as IPhysics).AddImpulse(new Vector(0, 100));
            if (e.KeyCode == Keys.A)
                (AllObjects[2] as IPhysics).AddImpulse(new Vector(-20, 0));
            if (e.KeyCode == Keys.D)
                (AllObjects[2] as IPhysics).AddImpulse(new Vector(20, 0));
        }
    }
}

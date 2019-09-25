using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Ball
    {
        private Point location;

        private Size sizeBall;

        private Image type;

        private bool touchAxisX;

        private bool touchAxisY;

        private Point lastMove;

        private bool stopMove;

        private int dx;

        private int dy;

        public Ball(int _dx, int _dy)
        {
            dx = _dx;
            dy = _dy;
        }


        public Point Location { get => location; set => location = value; }
        public Size SizeBall { get => sizeBall; set => sizeBall = value; }
        public Image Type { get => type; set => type = value; }
        public bool TouchAxisX { get => touchAxisX; set => touchAxisX = value; }
        public bool TouchAxisY { get => touchAxisY; set => touchAxisY = value; }
        public Point LastMove { get => lastMove; set => lastMove = value; }
        public bool StopMove { get => stopMove; set => stopMove = value; }

        public void Draw(Graphics g)
        {
            g.DrawImage(Type, Location);
        }

        public void ChangeDirection()
        {
            if (touchAxisX)
            {
                dx = -dx;
                touchAxisX = false;
            }
            if (touchAxisY)
            {
                dy = -dy;
                touchAxisY = false;
            }
        }

        public void Move()
        {
            if (!stopMove)
            {
                LastMove = Location;
                Location = new Point(Location.X + dx, Location.Y + dy);
            }
        }
    }
}

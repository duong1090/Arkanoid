using System.Drawing;

namespace Game
{
    public enum StatusDisk {None, Left, Right };
    public class Disk
    {
        private const int STEP= 4;
        private const int SIZE_HEIGHT = 16;
        private const int SIZE_WIDTH = 80;
        private const int PTB_SIZE_WIDTH = 400;
        private const int PTB_SIZE_HEIGHT = 415;
        private const int REC_SIZE_WIDTH = 16;

        public StatusDisk statusMove;

        private Point location;

        private Size sizeDisk;

        private Rectangle stopBallLeft;

        private Rectangle stopBallRight;

        public int dx;

        public Point Location { get => location; set => location = value; }

        public Size SizeDisk { get => sizeDisk; set => sizeDisk = value; }
        public Rectangle StopBallLeft { get => stopBallLeft; set => stopBallLeft = value; }
        public Rectangle StopBallRight { get => stopBallRight; set => stopBallRight = value; }

        public Disk(Point _location, Size _size)
        {
            location = new Point(_location.X, _location.Y);
            sizeDisk = new Size(_size.Width, _size.Height);
            stopBallLeft = new Rectangle(new Point(_location.X - REC_SIZE_WIDTH, _location.Y),
                new Size(REC_SIZE_WIDTH, _size.Height));
            stopBallRight = new Rectangle(new Point(_location.X + _size.Width, _location.Y),
                new Size(REC_SIZE_WIDTH, _size.Height));
        }

        public void Move()
        {
            if (statusMove == StatusDisk.Right)
                dx = STEP;
            else if (statusMove == StatusDisk.Left)
                dx = -STEP;
            else
                dx = 0;

            location.X += dx;
            stopBallLeft.Location = new Point(location.X - REC_SIZE_WIDTH, location.Y);
            stopBallRight.Location = new Point(location.X + sizeDisk.Width, location.Y);

            if (stopBallRight.Location.X > PTB_SIZE_WIDTH - stopBallRight.Size.Width)
            {
                location.X = PTB_SIZE_WIDTH - sizeDisk.Width - stopBallRight.Size.Width;
                dx = 0;
                stopBallLeft.Location = new Point(location.X - REC_SIZE_WIDTH, location.Y);
                stopBallRight.Location = new Point(location.X + sizeDisk.Width, location.Y);
            }
            
            else if (stopBallLeft.Location.X < 0)
            {
                location.X = stopBallLeft.Size.Width;
                dx = 0;
                stopBallLeft.Location = new Point(location.X - REC_SIZE_WIDTH, location.Y);
                stopBallRight.Location = new Point(location.X + sizeDisk.Width, location.Y);
            }
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.DarkGreen), Location.X, Location.Y, SizeDisk.Width, SizeDisk.Height);
            g.FillRectangle(new SolidBrush(Color.Gold), stopBallLeft);
            g.FillRectangle(new SolidBrush(Color.Gold), stopBallRight);
        }
    }
}

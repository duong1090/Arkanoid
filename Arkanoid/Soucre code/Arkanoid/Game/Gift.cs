using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    class Gift
    {
        private const int PTB_SIZE_WIDTH = 400;
        private const int PTB_SIZE_HEIGHT = 415;
        
        
        private bool isEnable;
        private Point location;
        private Size sizeGift;
        

        public Gift()
        {
            Random rd = new Random();
            location = new Point(rd.Next(0, PTB_SIZE_WIDTH - 70), -20);
            sizeGift = new Size(20, 20);
            Random rd1 = new Random();
        }
        

        public Point Location { get => location; set => location = value; }
        public Size SizeGift { get => sizeGift; set => sizeGift = value; }
        public bool IsEnable { get => isEnable; set => isEnable = value; }
        

        public void Draw(Graphics g)
        {
            g.DrawImage(Properties.Resources.QUA, location.X, location.Y);
        }

        public void Move()
        {
            location.Y = location.Y + 3;
        }
 
    }
}

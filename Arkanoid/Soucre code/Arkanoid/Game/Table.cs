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
    class Table
    {
        private const int TABLE_SIZE_WIDTH = 40;
        private const int TABLE_SIZE_HEIGHT = 16;

        private Point location;
        private Size sizeTable;

        public Table()
        {
            sizeTable = new Size(TABLE_SIZE_WIDTH, TABLE_SIZE_HEIGHT);
        }

        public Point Location { get => location; set => location = value; }
        public Size SizeTable { get => sizeTable; set => sizeTable = value; }

        public void Draw(Graphics g)
        {
            g.DrawImage(Properties.Resources.Table, Location);
        }
    }
}

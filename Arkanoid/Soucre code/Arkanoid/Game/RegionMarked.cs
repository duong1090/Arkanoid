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
    class Region
    {
        private const int PTB_SIZE_WIDTH = 400;
        private const int PTB_SIZE_HEIGHT = 400;
        
        private Rectangle recRegion;


        public Region(Rectangle _rectangle)
        {
            recRegion = _rectangle;
        }
        
        public Rectangle RecRegion { get => recRegion; set => recRegion = value; }

        public bool touchedBy(Ball ball)
        {
            Rectangle recBall = new Rectangle(ball.Location, ball.SizeBall);
            Rectangle recLastMoveBall = new Rectangle(ball.LastMove, ball.SizeBall);

            if (recRegion.IntersectsWith(recBall))
            {
                if (recBall.Top <= recRegion.Bottom && recBall.Bottom >= recRegion.Bottom)
                {
                    if (recLastMoveBall.Top >= recRegion.Bottom)
                        ball.TouchAxisY = true;
                    else
                        ball.TouchAxisX = true;
                }

                else if (recBall.Bottom >= recRegion.Top && recBall.Top <= recRegion.Top)
                {
                    if (recLastMoveBall.Bottom <= recRegion.Top)
                        ball.TouchAxisY = true;
                    else
                        ball.TouchAxisX = true;
                }

                else if (recBall.Right >= recRegion.Left && recBall.Left <= recRegion.Left)
                {
                    if (recLastMoveBall.Right <= recRegion.Left)
                        ball.TouchAxisX = true;
                    else
                        ball.TouchAxisY = true;
                }

                else if (recBall.Left <= recRegion.Right && recBall.Right >= recRegion.Right)
                {
                    if (recLastMoveBall.Left >= recRegion.Right)
                        ball.TouchAxisX = true;
                    else
                        ball.TouchAxisY = true;
                }

                return true;
            }
            return false;
        }

        
    }
}

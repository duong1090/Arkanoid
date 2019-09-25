using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace Game
{
    
    public partial class Form1 : Form
    {
        private const string LINK_HIGH_SCORE = "High_score.txt";
        private const string LINK_PLAYER = "Player.txt";
        private const int DISK_REGION_INDEX = 0;
        private const int DISK_LOCATION_X = 200;
        private const int DISK_LOCATION_Y = 384;
        private const int DISK_SIZE_HEIGHT = 16;
        private const int DISK_SIZE_WIDTH = 80;
        private const int TABLE_LOCATION_FIRST_X = 24;
        private const int TABLE_LOCATION_FIRST_Y = 24;
        private const int TABLE_DISTANCE = 4;
        private const int TABLE_LIMIT_ROW = 7;
        private const int TABLE_LIMIT_COLUMN = 8;
        private const int TABLE_NUM_FIRST = 10;

        List<Table> listTable;
        List<Region> listRegion;
        List<string> listPlayer;
        Ball ball;
        Disk disk;
        Gift gift;
        Bitmap bmp;
        Graphics g;
        int level;
        int multiTable;
        bool isLevelOne;
        bool isStart;
        int step;
        int score;
        int minute;
        int second;
        int timeGift;

        public Form1()
        {
            InitializeComponent();
            lbNamePlayer.Text = FormNamePlayer.NamePlayer;
            listTable = new List<Table>();
            listRegion = new List<Region>();
            listPlayer = new List<string>();
            level = 1;
            multiTable = 1;
            isLevelOne = true;
            isStart = false;
            step = 3;
            score = 0;
            minute = 1;
            second = 0;
            timeGift = 0;
            lblMinute.Text = minute.ToString();
            lblSecond.Text = "0" + second.ToString();

            InitDisk();
            InitBall();
            gift = new Gift();

            bmp = new Bitmap(ptbMain.Width, ptbMain.Height);
            g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        #region Init
        public void InitBall()
        {
            ball = new Ball(step, step);
            ball.Type = Properties.Resources.ball1;
            ball.SizeBall = ball.Type.Size;
            ball.Location = new Point(disk.Location.X + disk.SizeDisk.Width/2 - ball.SizeBall.Width / 2, disk.Location.Y - ball.SizeBall.Height);
            ball.StopMove = true;
        }

        public void InitDisk()
        {
            disk = new Disk(new Point(DISK_LOCATION_X, DISK_LOCATION_Y), new Size(DISK_SIZE_WIDTH, DISK_SIZE_HEIGHT));
            listRegion.Add(new Region(new Rectangle(disk.Location, disk.SizeDisk)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateTables(TABLE_NUM_FIRST);
            DrawTables();
            disk.Draw(g);
            ball.Draw(g);
            ptbMain.Image = bmp;
        }
        
        public void CreateTables(int numOfTable)
        {
            Random random = new Random();
            List<Point> listPoint = new List<Point>();

            InitListRandom(listPoint);


            for (int i = 0; i < numOfTable; i++)
            {
                Point xy = RandomNumber(random, listPoint);
                Table table = new Table();
                listTable.Add(table);
                listTable[i].Location = new Point(TABLE_LOCATION_FIRST_X + (table.SizeTable.Width + TABLE_DISTANCE) * xy.X,
                    TABLE_LOCATION_FIRST_Y + (table.SizeTable.Height + TABLE_DISTANCE)* xy.Y);
                listRegion.Add(new Region(new Rectangle(table.Location, table.SizeTable)));
            }
        }
        
        public void InitListRandom(List<Point> listPoint)
        {
            for (int i = 0; i < TABLE_LIMIT_ROW; i++)
                for (int j = 0; j < TABLE_LIMIT_COLUMN; j++)
                    listPoint.Add(new Point(i, j));
        }

        public Point RandomNumber(Random random, List<Point> listPoint)
        {
            int num = 0;
            Point temp = new Point();
            num = random.Next(0, listPoint.Count - 1);
            temp = listPoint[num];
            listPoint.RemoveAt(num);
            return temp;
        }

        public void DrawTables()
        {
            foreach (Table a in listTable)
                a.Draw(g);
        }
        #endregion

        #region Operation
        private void timerOperation_Tick(object sender, EventArgs e)
        {
            if (isStart)
            {
                g.Clear(ptbMain.BackColor);
                Play();
                ptbMain.Image = bmp;
            }
        }

        public void Play()
        {
            DrawTables();
            DiskOperation();
            BallOperation();
            GiftOperation();
        }
        
        public void DiskOperation()
        {
            disk.Move();
            disk.Draw(g);
            listRegion[DISK_REGION_INDEX].RecRegion = new Rectangle(disk.Location, disk.SizeDisk);
        }

        public void BallOperation()
        {
            if (ball.StopMove)
            {
                ball.Location = new Point(ball.Location.X + disk.dx, ball.Location.Y);
            }
            else
            {
                if (ballTouchWall() || ballTouchTable())
                {
                    ballTouchTable();
                }
                    ball.ChangeDirection();
                ball.Move();
            }

            if (ballTouchStopRegionOfDisk())
            {
                ball.StopMove = true;
                ball.Location = ball.LastMove;
            }

            ball.Draw(g);
        }

        public void GiftOperation()
        {
            Rectangle recGift = new Rectangle(gift.Location, gift.SizeGift);
            Rectangle recDisk = new Rectangle(disk.Location, disk.SizeDisk);
            timeGift++;

            if (timeGift > 1000)
            {
                gift.Draw(g);
                gift.Move();
            }

            if (timeGift > 100)
            {
                lblAddTime.Visible = false;
            }

            if (recGift.IntersectsWith(recDisk))
            {
                timeGift = 0;
                gift = new Gift();
                second += 5;
                lblAddTime.Visible = true;
            }
            if (gift.Location.Y > ptbMain.Size.Height)
            {
                timeGift = 0;
                gift = new Gift();
            }
        }

        public bool ballTouchStopRegionOfDisk()
        {
            Rectangle recBall = new Rectangle(ball.Location, ball.SizeBall);
            if (recBall.IntersectsWith(disk.StopBallLeft) || recBall.IntersectsWith(disk.StopBallRight))
                return true;
            return false;
        }

        bool ballTouchTable()
        {
            for (int i = 0; i < listRegion.Count; i++)
            {
                if (listRegion[i].touchedBy(ball))
                {
                    if (i != DISK_REGION_INDEX)
                    {
                        score += 10;
                        lblScore.Text = score.ToString();
                        listRegion.RemoveAt(i);
                        listTable.RemoveAt(i - 1);
                    }
                    return true;
                }
            }
            return false;
        }

        bool ballTouchWall()
        {
            bool temp = false;
            int posX = ball.Location.X;
            int posY = ball.Location.Y;
            if (posX <= 0 || posX >= ptbMain.Size.Width)
            {
                ball.TouchAxisX = true;
                temp = true;
            }
            if (posY <= 0)
            {
                ball.TouchAxisY = true;
                temp = true;
            }
            return temp;
        }
        #endregion
        
        #region Level Up and Game Over
        private void timerLevelUp_Tick(object sender, EventArgs e)
        {
            if (levelUp() || isLevelOne)
            {
                g.DrawString("LEVEL " + level.ToString(), new Font("Mongolian Baiti", 50.0f, FontStyle.Bold),
                    new HatchBrush(HatchStyle.BackwardDiagonal, Color.White, Color.Blue), new PointF(ptbMain.Size.Width / 2 - 150, ptbMain.Size.Height / 2 + 50));
                if (isLevelOne)
                    g.DrawString("Press Enter to Start", new Font("Times New Roman", 15.0f),
                    new SolidBrush(Color.Gray), new PointF(ptbMain.Size.Width / 2 - 90, ptbMain.Size.Height / 2 + 110));
                ptbMain.Image = bmp;
                timerOperation.Enabled = false;
                timerGameOver.Enabled = false;
                isLevelOne = false;
            }
            else
            {
                timerGameOver.Enabled = true;
                timerOperation.Enabled = true;
            }
        }
        public bool levelUp()
        {
            if (listTable.Count <= 0)
            {
                if (TABLE_NUM_FIRST * multiTable < TABLE_LIMIT_ROW * TABLE_LIMIT_COLUMN)
                {
                    multiTable++;
                }
                if (TABLE_NUM_FIRST * multiTable >= TABLE_LIMIT_ROW * TABLE_LIMIT_COLUMN)
                {
                    multiTable = 1;
                    step++;
                }

                level++;
                InitBall();
                CreateTables(TABLE_NUM_FIRST * multiTable);
                ResetTime();

                return true;
            }
            return false;
        }
        
        private void timerGameOver_Tick(object sender, EventArgs e)
        {
            if (gameOver())
            {
                g.Clear(ptbMain.BackColor);
                g.DrawString("GAME OVER", new Font("Mongolian Baiti", 45.0f, FontStyle.Bold),
                    new HatchBrush(HatchStyle.BackwardDiagonal, Color.White, Color.Red), new PointF(ptbMain.Size.Width / 2 - 190, ptbMain.Size.Height / 2 + 50));
                g.DrawString("Press Enter to Start", new Font("Times New Roman", 15.0f),
                    new SolidBrush(Color.Gray), new PointF(ptbMain.Size.Width / 2 - 90, ptbMain.Size.Height / 2 + 110));
                ptbMain.Image = bmp;
                GetScore();
                ResetAll();
                timerOperation.Enabled = false;
                timerLeveUp.Enabled = false;
                isStart = false;
            }
            else
            {
                if (isStart)
                {
                    timerLeveUp.Enabled = true;
                    timerOperation.Enabled = true;
                }
            }
        }
        bool gameOver()
        {
            if (ball.Location.Y >= ptbMain.Size.Height || (minute == 0 && second == 0))
                return true;
            return false;
        }
        public void ResetAll()
        {
            listTable.Clear();
            listRegion.Clear();
            InitDisk();
            InitBall();
            level = 1;
            multiTable = 1;
            isLevelOne = false;
            step = 3;
            ResetTime();
            score = 0;
            lblScore.Text = "00";
            Form1_Load(null, null);
        }

        #endregion
        
        #region Get Key
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                disk.statusMove = StatusDisk.Left;
            if (e.KeyCode == Keys.Right)
                disk.statusMove = StatusDisk.Right;
            if (e.KeyCode != Keys.Right && e.KeyCode != Keys.Left)
                disk.statusMove = StatusDisk.None;

            if (e.KeyCode == Keys.Enter)
            {
                isStart = true;
            }

            if (e.KeyCode == Keys.Up && ball.StopMove)
            {
                ball.StopMove = false;
                ball.TouchAxisY = true;
                ball.TouchAxisX = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            disk.statusMove = StatusDisk.None;
        }
        #endregion

        #region Countdown
        private void timerCountdown_Tick(object sender, EventArgs e)
        {
            if (isStart)
            {
                if (second == 0)
                {
                    second = 60;
                    minute--;
                }
                second--;
                lblMinute.Text = minute.ToString();
                if (second < 10)
                    lblSecond.Text = "0" + second.ToString();
                else
                    lblSecond.Text = second.ToString();
            }
        }
        
        public void ResetTime()
        {
            minute = 1;
            second = 0;
            lblMinute.Text = minute.ToString();
            lblSecond.Text = "0" + second.ToString();
        }
        #endregion

        public void GetScore()
        {
            if (gameOver())
            {
                string player = FormNamePlayer.NamePlayer + "," + score.ToString();
                
                listPlayer = File.ReadAllLines(LINK_HIGH_SCORE).ToList();

                listPlayer.Add(player);

                SortScore();
                
                File.WriteAllLines(LINK_HIGH_SCORE, listPlayer.ToArray());
            }
        }
        
        public void SortScore()
        {
            for (int i = 0; i < listPlayer.Count; i++)
            {
                for (int j = i + 1; j < listPlayer.Count; j++)
                {
                    string[] temp1 = listPlayer[i].Split(',');
                    string[] temp2 = listPlayer[j].Split(',');

                    if (int.Parse(temp1[1]) < int.Parse(temp2[1]))
                    {
                        string temp = listPlayer[i];
                        listPlayer[i] = listPlayer[j];
                        listPlayer[j] = temp;
                    }   
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnHighScore_Click(object sender, EventArgs e)
        {
            
            StreamReader stream = new StreamReader(LINK_HIGH_SCORE);
            string temp = "";
            temp += "1st: \t" + stream.ReadLine() + "\r\n";
            temp += "2nd:\t" + stream.ReadLine() + "\r\n";
            temp += "3rd:\t" + stream.ReadLine();
            MessageBox.Show(temp, "Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

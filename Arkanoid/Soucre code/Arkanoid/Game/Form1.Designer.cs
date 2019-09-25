namespace Game
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ptbMain = new System.Windows.Forms.PictureBox();
            this.timerOperation = new System.Windows.Forms.Timer(this.components);
            this.timerLeveUp = new System.Windows.Forms.Timer(this.components);
            this.timerGameOver = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.timerCountdown = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAddTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMinute = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbNamePlayer = new System.Windows.Forms.Label();
            this.timerGetScore = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMain)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptbMain
            // 
            this.ptbMain.BackColor = System.Drawing.Color.White;
            this.ptbMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptbMain.Location = new System.Drawing.Point(26, 182);
            this.ptbMain.Name = "ptbMain";
            this.ptbMain.Size = new System.Drawing.Size(400, 415);
            this.ptbMain.TabIndex = 0;
            this.ptbMain.TabStop = false;
            // 
            // timerOperation
            // 
            this.timerOperation.Enabled = true;
            this.timerOperation.Interval = 1;
            this.timerOperation.Tick += new System.EventHandler(this.timerOperation_Tick);
            // 
            // timerLeveUp
            // 
            this.timerLeveUp.Enabled = true;
            this.timerLeveUp.Interval = 1000;
            this.timerLeveUp.Tick += new System.EventHandler(this.timerLevelUp_Tick);
            // 
            // timerGameOver
            // 
            this.timerGameOver.Enabled = true;
            this.timerGameOver.Interval = 1;
            this.timerGameOver.Tick += new System.EventHandler(this.timerGameOver_Tick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Stencil Std", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblScore.Location = new System.Drawing.Point(20, 144);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(49, 36);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "00";
            // 
            // timerCountdown
            // 
            this.timerCountdown.Enabled = true;
            this.timerCountdown.Interval = 1000;
            this.timerCountdown.Tick += new System.EventHandler(this.timerCountdown_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Game.Properties.Resources.Arkanoid;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(40, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 82);
            this.panel1.TabIndex = 7;
            // 
            // lblAddTime
            // 
            this.lblAddTime.AutoSize = true;
            this.lblAddTime.BackColor = System.Drawing.Color.Transparent;
            this.lblAddTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddTime.ForeColor = System.Drawing.Color.Yellow;
            this.lblAddTime.Location = new System.Drawing.Point(3, 11);
            this.lblAddTime.Name = "lblAddTime";
            this.lblAddTime.Size = new System.Drawing.Size(27, 20);
            this.lblAddTime.TabIndex = 8;
            this.lblAddTime.Text = "+5";
            this.lblAddTime.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(59, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 35);
            this.label1.TabIndex = 14;
            this.label1.Text = ":";
            // 
            // lblMinute
            // 
            this.lblMinute.AutoSize = true;
            this.lblMinute.BackColor = System.Drawing.Color.Transparent;
            this.lblMinute.Font = new System.Drawing.Font("Palatino Linotype", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinute.ForeColor = System.Drawing.Color.Yellow;
            this.lblMinute.Location = new System.Drawing.Point(25, 1);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(50, 35);
            this.lblMinute.TabIndex = 12;
            this.lblMinute.Text = "02 ";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.BackColor = System.Drawing.Color.Transparent;
            this.lblSecond.Font = new System.Drawing.Font("Palatino Linotype", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecond.ForeColor = System.Drawing.Color.Yellow;
            this.lblSecond.Location = new System.Drawing.Point(74, 1);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(43, 35);
            this.lblSecond.TabIndex = 13;
            this.lblSecond.Text = "00";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Game.Properties.Resources.Disk1;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblAddTime);
            this.panel3.Controls.Add(this.lblSecond);
            this.panel3.Controls.Add(this.lblMinute);
            this.panel3.Location = new System.Drawing.Point(306, 139);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(120, 40);
            this.panel3.TabIndex = 9;
            // 
            // lbNamePlayer
            // 
            this.lbNamePlayer.AutoSize = true;
            this.lbNamePlayer.BackColor = System.Drawing.Color.Transparent;
            this.lbNamePlayer.Font = new System.Drawing.Font("Stencil Std", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNamePlayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbNamePlayer.Location = new System.Drawing.Point(111, 144);
            this.lbNamePlayer.Name = "lbNamePlayer";
            this.lbNamePlayer.Size = new System.Drawing.Size(96, 36);
            this.lbNamePlayer.TabIndex = 10;
            this.lbNamePlayer.Text = "Name";
            // 
            // timerGetScore
            // 
            this.timerGetScore.Enabled = true;
            this.timerGetScore.Interval = 1;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::Game.Properties.Resources.Disk1;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(26, 101);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(130, 40);
            this.panel4.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("UTM Atlas", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "High Score";
            this.label6.Click += new System.EventHandler(this.btnHighScore_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::Game.Properties.Resources.honeycomb_34984_1280;
            this.ClientSize = new System.Drawing.Size(448, 609);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lbNamePlayer);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ptbMain);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ptbMain)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbMain;
        private System.Windows.Forms.Timer timerOperation;
        private System.Windows.Forms.Timer timerLeveUp;
        private System.Windows.Forms.Timer timerGameOver;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer timerCountdown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAddTime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.Label lbNamePlayer;
        private System.Windows.Forms.Timer timerGetScore;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
    }
}


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
    public partial class FormNamePlayer : Form
    {
        public FormNamePlayer()
        {
            InitializeComponent();
        }

        public static string NamePlayer;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtNamePlayer.Text.Length < 3)
            {
                MessageBox.Show("Bạn cần nhập tên người chơi lớn hơn 3 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamePlayer.Clear();
                txtNamePlayer.Focus();
            }
            else
            {
                NamePlayer = txtNamePlayer.Text;
                Form1 form = new Form1();
                form.FormClosed += new FormClosedEventHandler(FormNamePlayer_FormClosed);
                form.Show();
                txtNamePlayer.Clear();
                txtNamePlayer.Focus();
                this.Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc thoát không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Close();
        }

        private void FormNamePlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}

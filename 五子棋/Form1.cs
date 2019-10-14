using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋
{
    public partial class Form1 : Form
    {
        private Game game = new Game();
        public Form1()
        {
            InitializeComponent();     
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            qizi qz = game.placeqizi(e.X, e.Y);
            if (qz!=null)
            {
                this.Controls.Add(qz);
                //检查是否有人获胜
                if (game.winner == qztype.BLACK)
                {
                    MessageBox.Show("黑色获胜");
                    this.Close();
                }
                else if (game.winner == qztype.WHITE)
                {
                    MessageBox.Show("白色获胜");
                    this.Close();
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(game.canplace(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace 五子棋
{
    
    abstract class qizi:PictureBox
      
    {
        private static readonly int i = 50;
        public qizi(int x, int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x - i / 2, y - i / 2);
            this.Size = new Size(i, i);
        }
        public abstract qztype GetQizitype();
    }
}

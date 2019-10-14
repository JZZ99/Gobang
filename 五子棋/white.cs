using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋
{
    class white:qizi
    {
        public white(int x,int y) : base(x, y)
        {
            this.Image = Properties.Resources.white;
        }
        public override qztype GetQizitype()
        {
            return qztype.WHITE;
        }
    }
}

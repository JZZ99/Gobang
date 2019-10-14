using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋
{
    class qipan
    {
        //避免回传的nodepalce超过棋盘坐标个数
        public static readonly int nodecount = 9;
        private static readonly int side = 75;
        private static readonly int distance = 75;
        private static readonly int radious = 10;
        private static readonly Point NO_MATCH = new Point(-1, -1);
        //创建一个二维阵列存放棋子
        private qizi[,] qizis = new qizi[9, 9];

        private Point lastPlaceNode = NO_MATCH;
        public Point LastPlaceNode
        {
            get { return lastPlaceNode; }
        }

        //找出节点上的棋子是什么颜色
        public qztype GetQztype(int nodeidX, int nodeidY)
        {
            if (qizis[nodeidX, nodeidY] == null)
            {
                return qztype.NONE;
            }
            else
            {
                return qizis[nodeidX, nodeidY].GetQizitype();
            }
        }
        public bool canplace(int x, int y)
        {
            //找出最近的节点
            Point nodeid = FindTheCloseNode(x, y);
            //如果没有的话，false
            if (nodeid == NO_MATCH)
                return false;
            //如果有的话，检查是否已经有棋子存在
            if (qizis[nodeid.X, nodeid.Y] != null)
            {
                return false;
            }
            return true;
        }
        public qizi placeqizi(int x, int y, qztype type)
        {
            //找出最近的节点
            Point nodeid = FindTheCloseNode(x, y);
            //如果没有的话，false
            if (nodeid == NO_MATCH)
            {
                return null;
            }
            //如果有的话，检查是否已经有棋子存在
            if (qizis[nodeid.X, nodeid.Y] != null)
            {
                return null;
            }
            //根据type产生对应的棋子
            Point formPos = conertToFormPosition(nodeid);
            if (type == qztype.BLACK)
            {
                qizis[nodeid.X, nodeid.Y] = new black(formPos.X, formPos.Y);
            }
            else if (type == qztype.WHITE)
            {
                qizis[nodeid.X, nodeid.Y] = new white(formPos.X, formPos.Y);
            }
            //记录最后下棋子的位置
            lastPlaceNode = nodeid;
            return qizis[nodeid.X, nodeid.Y];
        }
        //调整棋子位置使其于坐标上居中
        private Point conertToFormPosition(Point nodeid)
        {
            Point formPosintion = new Point();
            formPosintion.X = nodeid.X * distance + side;
            formPosintion.Y = nodeid.Y * distance + side;
            return formPosintion;
        }
        private Point FindTheCloseNode(int x, int y)
        {
            int nodeX = FindTheCloseNode(x);
            if (nodeX == -1 || nodeX >= nodecount)
                return NO_MATCH;
            int nodeY = FindTheCloseNode(y);
            if (nodeY == -1 || nodeY >= nodecount)
                return NO_MATCH;
            return new Point(nodeX, nodeY);
        }
        private int FindTheCloseNode(int pos)
        {
            if (pos < side - radious)
            {
                return -1;
            }
            pos -= side;
            int nodeplace = pos / distance;
            int nodemore = pos % distance;
            if (nodemore >= distance - radious)
            {
                return nodeplace + 1;
            }
            else if (nodemore <= radious)
            {
                return nodeplace;
            }
            else
            {
                return -1;
            }
        }
    }
}

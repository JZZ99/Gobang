using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋
{
    class Game
    {
        private qipan qp = new qipan();
        private qztype currentPlayer = qztype.BLACK;
        private qztype Winner = qztype.NONE;
        public qztype winner { get { return Winner; } }
        public bool canplace(int x, int y)
        {
            return qp.canplace(x, y);
        }
        public qizi placeqizi(int x, int y)
        {
            qizi qz = qp.placeqizi(x, y, currentPlayer);
            if (qz != null)
            {
                //检查是否现在下棋的人获胜
                checkWinner();

                //交换棋手
                if (currentPlayer == qztype.BLACK)
                    currentPlayer = qztype.WHITE;
                else if (currentPlayer == qztype.WHITE)
                    currentPlayer = qztype.BLACK;
                return qz;
            }
            return null;
        }

        //游戏规则
        private void checkWinner()
        {
            int centerX = qp.LastPlaceNode.X;
            int centerY = qp.LastPlaceNode.Y;

            //检查8个方向的棋子
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    //排除中间的情况
                    if (xDir == 0 && yDir == 0)
                        //跳过后面的代码再次进入循环
                        continue;

                    //记录现在看到几颗相同的棋子
                    int count = -2;
                    while (count < 2)
                    {
                        int targetX = centerX + count * xDir;
                        int targetY = centerY + count * yDir;

                        //检查颜色是否相同
                        if (targetX < 0 || targetX >= qipan.nodecount ||
                            targetY < 0 || targetY >= qipan.nodecount ||
                            qp.GetQztype(targetX, targetY) != currentPlayer)
                            break;

                        count++;
                    }

                    //检查是否看到五颗棋子
                    if (count == 2)
                    {
                        Winner = currentPlayer;
                    }
                    int count1 = 0;
                    while (count1 < 5)
                    {
                        int targetX = centerX + count1 * xDir;
                        int targetY = centerY + count1 * yDir;

                        //检查颜色是否相同
                        if (targetX < 0 || targetX >= qipan.nodecount ||
                            targetY < 0 || targetY >= qipan.nodecount ||
                            qp.GetQztype(targetX, targetY) != currentPlayer)
                            break;

                        count1++;
                    }

                    //检查是否看到五颗棋子
                    if (count1 == 5)
                    {
                        Winner = currentPlayer;
                    }
                }
            }
        }
    }
}

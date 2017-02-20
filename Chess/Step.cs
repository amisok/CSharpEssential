using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Step
    {
        public int fromX, fromY;
        public int toX, toY;
        
        public Step(string f, string t)
        {
            
            Cell(f,out fromX, out fromY);
            Cell(t, out toX, out toY);
        }

        public Step(int fromX, int fromY, int toX, int toY)
        {
            this.fromX = fromX;
            this.fromY = fromY;
            this.toX = toX;
            this.toY = toY;
        }

        void Cell(string arg, out int x, out int y)  //Getting coordinates
        {
            char[] argYX = arg.ToCharArray();

            y = (int)(argYX[0] - 'a');
            x = (int)(argYX[1] - '1');
        }
    }
}

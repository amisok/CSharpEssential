using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Desk
    {
        Chess[,] map = new Chess[8, 8];

        public Desk() //create start desk
        {
            for (int i = 0; i < 8; i++)
            {
                map[1,i] = new Pawn(1);
                map[6, i] = new Pawn(0);
                
            }
            map[0, 0] = new Rook(1);
            map[0, 7] = new Rook(1);
            map[7, 0] = new Rook(0);
            map[7, 7] = new Rook(0);
            map[0, 1] = new Knight(1);
            map[0, 6] = new Knight(1);
            map[7, 1] = new Knight(0);
            map[7, 6] = new Knight(0);
            map[0, 2] = new Bishop(1);
            map[0, 5] = new Bishop(1);
            map[7, 2] = new Bishop(0);
            map[7, 5] = new Bishop(0);
            map[0, 3] = new Queen(1);
            map[7, 3] = new Queen(0);
            map[0, 4] = new King(1);
            map[7, 4] = new King(0);
        }

        char this[int x, int y]
        {
            get
            {
                if (map[x, y] == null)
                {
                    return ' ';
                }
                else
                {
                    return map[x, y].GetName();
                }
            }
        }

        
        public void Show()
        {
            Console.WriteLine("  a b c d e f g h ");
            Console.WriteLine(" +-+-+-+-+-+-+-+-+");
            for (int i = 0; i < 8; i++)
            {
                Console.Write($"{i+1}");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"|{this[i, j]}");
                }
                Console.WriteLine("|");
                Console.WriteLine(" +-+-+-+-+-+-+-+-+");
            }
       }

    }
}

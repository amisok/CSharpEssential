using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{


    interface IPerson
    {
        int PersonX { get; set; }
        int PersonY { get; set; }
    }

    interface IBox
    {
        int BoxX { get; set; }
        int BoxY { get; set; }
    }

    interface IFinishSell
    {
        int FinishX { get; set; }
        int FinishY { get; set; }
    }

    class SokobanGame : IPerson, IBox, IFinishSell
    {
        int boxX, boxY, personX, personY, finishX, finishY;
        public bool complete = false;

        public int PersonX
        {
            get { return personX; }
            set { personX = value; }
        }

        public int PersonY
        {
            get { return personY; }
            set { personY = 0; }
        }
        public int BoxX
        {
            get { return boxX; }
            set { boxX = value; }
        }

        public int BoxY
        {
            get { return boxY; }
            set { boxY = 0; }
        }

        public int FinishX
        {
            get { return finishX; }
            set { finishX = value; }
        }

        public int FinishY
        {
            get { return finishY; }
            set { finishY = 0; }
        }


        public SokobanGame(int startPersonX, int startBoxX, int startFinishX)
        {
            PersonX = startPersonX;
            BoxX = startBoxX;
            FinishX = startFinishX;
            if (BoxX == FinishX && BoxY == FinishY)
            {
                complete = true;
            }
        }

        public void Move()
        {
            if (!complete)
            {
                if (PersonX + 1 != BoxX)
                {
                    PersonX += 1;
                }
                else
                {
                    BoxX += 1;
                    PersonX += 1;
                    if (BoxX == FinishX && BoxY == FinishY)
                    {
                        complete = true;
                    }
                }
            }
        }
    }

    class Program
    {
        static void ShowFrame(SokobanGame sokoban)
        {
            Console.Clear();
            Console.SetCursorPosition(sokoban.PersonX, sokoban.PersonY);
            Console.Write("P");
            Console.SetCursorPosition(sokoban.FinishX, sokoban.FinishY);
            Console.Write("X");
            Console.SetCursorPosition(sokoban.BoxX, sokoban.BoxY);
            Console.Write("B");
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            SokobanGame sokoban = new SokobanGame(1, 5, 10);
            ShowFrame(sokoban);
            while (!sokoban.complete)
            {
                if (Console.ReadKey().Key == ConsoleKey.RightArrow)
                {
                    sokoban.Move();
                    ShowFrame(sokoban);
                }
            }
            Console.WriteLine("     !!!You win!!!");
            Console.ReadKey();
        }
    }
}

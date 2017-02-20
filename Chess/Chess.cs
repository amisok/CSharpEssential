using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Chess
    {
        public int colour;
        public bool attacked;
        protected char name;
        protected Chess[,] desk;

        public Chess(Chess[,] desk, int colour, char name)
        {
            this.colour = colour;  //0-black, 1-white
            this.name = name;
            this.desk = desk;
        }

        public char GetName()
        {
            return name;
        }

        public int CheckMove(int x, int y)//0-impossible; 1-possible; 2-atack; 3 - check; 
        {
            if (x < 0 || x > 7)
                return 0;
            if (y < 0 || y > 7)
                return 0;
            if (desk[x, y] == null)
                return 1;
            if (colour != desk[x, y].colour)
            {

                if (desk[x, y].GetName() == 'K' && desk[x, y].GetName() == 'k')
                {
                    desk[x, y].attacked = true;
                    return 3;
                }

                else return 2;
            }
            return 0;

        }

        public bool Move(Step step)
        {
            int count;
            Step[] s = GetPossibleSteps(step.fromX, step.fromY, out count);
            for (int i = 0; i < count; i++)
            {
                if (s[i].toX == step.toX && s[i].toY == step.toY)
                {
                    desk[step.toX, step.toY] = desk[step.fromX, step.fromY];
                    desk[step.fromX, step.fromY] = null;
                    return true;

                }
            }
            return false;
        }

        public virtual Step[] GetPossibleSteps(int fromX, int fromY, out int count)
        {
            count = 0;
            return new Step[0];
        }

        public Step[] GetPossibleSteps(int fromX, int fromY)
        {
            int c;
            return GetPossibleSteps(fromX, fromY, out c);
        }
    }

    class Pawn : Chess
    {
        public Pawn(Chess[,] desk, int colour) : base(desk, colour, ((colour == 0) ? 'p' : 'P'))
        {
        }


        public override Step[] GetPossibleSteps(int fromX, int fromY, out int count)
        {
            Step[] s = new Step[4];
            count = 0;

            if (colour == 1)//white
            {
                if (CheckMove(fromX + 1, fromY) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX + 1, fromY);
                }

                //step2
                if (CheckMove(fromX + 1, fromY - 1) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX + 1, fromY - 1);
                }

                //step 3
                if (fromX == 1 && CheckMove(fromX + 2, fromY) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX + 2, fromY);
                }
                //step 4
                if (CheckMove(fromX + 1, fromY + 1) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX + 1, fromY + 1);
                }
            }
            else //black
            {

                //step 1
                if (CheckMove(fromX - 1, fromY) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX - 1, fromY);
                }

                //step2
                if (CheckMove(fromX - 1, fromY - 1) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX - 1, fromY - 1);
                }

                //step 3
                if (fromX == 6 && CheckMove(fromX - 2, fromY) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX - 2, fromY);
                }
                //step 4
                if (CheckMove(fromX - 1, fromY + 1) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX - 1, fromY + 1);
                }
            }

            return s;
        }
    }

    class Rook : Chess
    {
        public Rook(Chess[,] desk, int colour) : base(desk, colour, ((colour == 0) ? 'r' : 'R'))
        {
        }

        public override Step[] GetPossibleSteps(int fromX, int fromY, out int count)
        {
            Step[] s = new Step[14];
            count = 0;

            for (int i = 1; i <= 7; i++)//down
            {
                if (CheckMove(fromX + i, fromY) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX + i, fromY);
                }
                else if (CheckMove(fromX + i, fromY) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX + i, fromY);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i <= 7; i++)//up
            {
                if (CheckMove(fromX - i, fromY) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX - i, fromY);
                }
                else if (CheckMove(fromX - i, fromY) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX - i, fromY);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i <= 7; i++)//right
            {
                if (CheckMove(fromX, fromY + i) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX, fromY + i);
                }
                else if (CheckMove(fromX, fromY + i) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX, fromY + i);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i <= 7; i++)//left
            {
                if (CheckMove(fromX, fromY - i) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX, fromY - i);
                }
                else if (CheckMove(fromX, fromY - i) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX, fromY - i);
                    break;
                }
                else
                    break;
            }
            return s;
        }
    }

    class Knight : Chess
    {
        public Knight(Chess[,] desk, int colour) : base(desk, colour, ((colour == 0) ? 'n' : 'N'))
        {
        }

        public override Step[] GetPossibleSteps(int fromX, int fromY, out int count)
        {
            Step[] s = new Step[8];
            count = 0;

            //step 1
            if (CheckMove(fromX - 1, fromY - 2) == 1 || CheckMove(fromX - 1, fromY - 2) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX - 1, fromY - 2);
            }

            //step2
            if (CheckMove(fromX - 2, fromY - 1) == 1 || CheckMove(fromX - 2, fromY - 1) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX - 2, fromY - 1);
            }

            //step 3
            if (CheckMove(fromX - 2, fromY + 1) == 1 || CheckMove(fromX - 2, fromY + 1) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX - 2, fromY + 1);
            }
            //step 4
            if (CheckMove(fromX - 1, fromY + 2) == 1 || CheckMove(fromX - 1, fromY + 2) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX - 1, fromY + 2);
            }

            //step 5
            if (CheckMove(fromX + 1, fromY + 2) == 1 || CheckMove(fromX + 1, fromY + 2) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX + 1, fromY + 2);
            }

            //step 6
            if (CheckMove(fromX + 2, fromY + 1) == 1 || CheckMove(fromX + 2, fromY + 1) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX + 2, fromY + 1);
            }

            //step 7
            if (CheckMove(fromX + 2, fromY - 1) == 1 || CheckMove(fromX + 2, fromY - 1) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX + 2, fromY - 1);
            }
            //step 8
            if (CheckMove(fromX + 1, fromY - 2) == 1 || CheckMove(fromX + 1, fromY - 2) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX + 1, fromY - 2);
            }

            return s;
        }
    }

    class Bishop : Chess
    {
        public Bishop(Chess[,] desk, int colour) : base(desk, colour, ((colour == 0) ? 'b' : 'B'))
        {
        }

        public override Step[] GetPossibleSteps(int fromX, int fromY, out int count)
        {
            Step[] s = new Step[14];
            count = 0;

            for (int i = 1; i <= 7; i++)//right-down
            {
                if (CheckMove(fromX + i, fromY + i) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX + i, fromY + i);
                }
                else if (CheckMove(fromX + i, fromY + i) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX + i, fromY + i);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i <= 7; i++)//left-up
            {
                if (CheckMove(fromX - i, fromY - i) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX - i, fromY - i);
                }
                else if (CheckMove(fromX - i, fromY) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX - i, fromY - i);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i <= 7; i++)//right-up
            {
                if (CheckMove(fromX - i, fromY + i) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX - i, fromY + i);
                }
                else if (CheckMove(fromX - i, fromY + i) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX - i, fromY + i);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i < 7; i++)//left-down
            {
                if (CheckMove(fromX + i, fromY - i) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX + i, fromY - i);
                }
                else if (CheckMove(fromX + i, fromY - i) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX + i, fromY - i);
                    break;
                }
                else
                    break;
            }

            return s;
        }
    }

    class Queen : Chess
    {
        public Queen(Chess[,] desk, int colour) : base(desk, colour, ((colour == 0) ? 'q' : 'Q'))
        {
        }

        public override Step[] GetPossibleSteps(int fromX, int fromY, out int count)
        {
            Step[] s = new Step[28];
            count = 0;

            for (int i = 1; i <= 7; i++)//down
            {
                if (CheckMove(fromX + i, fromY) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX + i, fromY);
                }
                else if (CheckMove(fromX + i, fromY) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX + i, fromY);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i <= 7; i++)//up
            {
                if (CheckMove(fromX - i, fromY) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX - i, fromY);
                }
                else if (CheckMove(fromX - i, fromY) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX - i, fromY);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i <= 7; i++)//right
            {
                if (CheckMove(fromX, fromY + i) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX, fromY + i);
                }
                else if (CheckMove(fromX, fromY + i) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX, fromY + i);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i <= 7; i++)//left
            {
                if (CheckMove(fromX, fromY - i) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX, fromY - i);
                }
                else if (CheckMove(fromX, fromY - i) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX, fromY - i);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i <= 7; i++)//right-down
            {
                if (CheckMove(fromX + i, fromY + i) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX + i, fromY + i);
                }
                else if (CheckMove(fromX + i, fromY + i) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX + i, fromY + i);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i <= 7; i++)//left-up
            {
                if (CheckMove(fromX - i, fromY - i) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX - i, fromY - i);
                }
                else if (CheckMove(fromX - i, fromY) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX - i, fromY - i);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i <= 7; i++)//right-up
            {
                if (CheckMove(fromX - i, fromY + i) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX - i, fromY + i);
                }
                else if (CheckMove(fromX - i, fromY + i) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX - i, fromY + i);
                    break;
                }
                else
                    break;
            }

            for (int i = 1; i < 7; i++)//left-down
            {
                if (CheckMove(fromX + i, fromY - i) == 1)
                {
                    s[count++] = new Step(fromX, fromY, fromX + i, fromY - i);
                }
                else if (CheckMove(fromX + i, fromY - i) == 2)
                {
                    s[count++] = new Step(fromX, fromY, fromX + i, fromY - i);
                    break;
                }
                else
                    break;
            }
            return s;
        }
    }

    class King : Chess
    {
        public King(Chess[,] desk, int colour) : base(desk, colour, ((colour == 0) ? 'k' : 'K'))
        {
        }

        public override Step[] GetPossibleSteps(int fromX, int fromY, out int count)
        {
            Step[] s = new Step[8];
            count = 0;

            //step 1
            if (CheckMove(fromX - 1, fromY - 1) == 1 || CheckMove(fromX - 1, fromY - 1) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX - 1, fromY - 1);
            }

            //step2
            if (CheckMove(fromX - 1, fromY) == 1 || CheckMove(fromX - 1, fromY) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX - 1, fromY);
            }

            //step 3
            if (CheckMove(fromX - 1, fromY + 1) == 1 || CheckMove(fromX - 1, fromY + 1) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX - 1, fromY + 1);
            }
            //step 4
            if (CheckMove(fromX, fromY + 1) == 1 || CheckMove(fromX, fromY + 1) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX, fromY + 1);
            }

            //step 5
            if (CheckMove(fromX + 1, fromY + 1) == 1 || CheckMove(fromX + 1, fromY + 1) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX + 1, fromY + 1);
            }

            //step 6
            if (CheckMove(fromX + 1, fromY) == 1 || CheckMove(fromX + 1, fromY) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX + 1, fromY);
            }

            //step 7
            if (CheckMove(fromX + 1, fromY - 1) == 1 || CheckMove(fromX + 1, fromY - 1) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX + 1, fromY - 1);
            }
            //step 8
            if (CheckMove(fromX, fromY - 1) == 1 || CheckMove(fromX, fromY - 1) == 2)
            {
                s[count++] = new Step(fromX, fromY, fromX, fromY - 1);
            }
            return s;
        }
    }
}

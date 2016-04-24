using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Chess
    {
        public Chess (int colour, char name)
        {
            this.colour = colour;  //0-black, 1-white
            this.name = name;
        }

        protected int colour;
        protected char name;

        public char GetName()
        {
            return name;
        }

        //public virtual void Move()
        //{

        //}
    }

    class Pawn : Chess
    {
        public Pawn(int colour):base(colour, ((colour == 0)?'p':'P')) 
        {
        }
        
    }

    class Rook : Chess
    {
        public Rook(int colour) : base(colour, ((colour == 0) ? 'r' : 'R'))
        {
        }

    }

    class Knight : Chess
    {
        public Knight(int colour) : base(colour, ((colour == 0) ? 'n' : 'N'))
        {
        }

    }

    class Bishop : Chess
    {
        public Bishop(int colour) : base(colour, ((colour == 0) ? 'b' : 'B'))
        {
        }

    }

    class Queen : Chess
    {
        public Queen(int colour) : base(colour, ((colour == 0) ? 'q' : 'Q'))
        {
        }

    }

    class King : Chess
    {
        public King(int colour) : base(colour, ((colour == 0) ? 'k' : 'K'))
        {
        }

    }



}

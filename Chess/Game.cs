using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Game
    {
        private Chess[,] desk = new Chess[8, 8];
        private string cmd;
        private string[] temp;
        private Chess whiteKing;
        private Chess blackKing;
        private int currColour;

        public Game()
        {
            Start();
        }

        char this[int x, int y]
        {
            get
            {
                if (desk[x, y] == null)
                {
                    return ' ';
                }
                else
                {
                    return desk[x, y].GetName();
                }
            }
        }

        void Start() //starting position of chess pieces
        {
            currColour = 1;
            for (int i = 0; i < 8; i++)
            {
                desk[1, i] = new Pawn(desk, 1);
                desk[6, i] = new Pawn(desk, 0);
            }
            desk[0, 0] = new Rook(desk, 1);
            desk[0, 7] = new Rook(desk, 1);
            desk[7, 0] = new Rook(desk, 0);
            desk[7, 7] = new Rook(desk, 0);
            desk[0, 1] = new Knight(desk, 1);
            desk[0, 6] = new Knight(desk, 1);
            desk[7, 1] = new Knight(desk, 0);
            desk[7, 6] = new Knight(desk, 0);
            desk[0, 2] = new Bishop(desk, 1);
            desk[0, 5] = new Bishop(desk, 1);
            desk[7, 2] = new Bishop(desk, 0);
            desk[7, 5] = new Bishop(desk, 0);
            desk[0, 3] = new Queen(desk, 1);
            desk[7, 3] = new Queen(desk, 0);
            whiteKing = desk[0, 4] = new King(desk, 1);
            blackKing = desk[7, 4] = new King(desk, 0);
        }

        void Show() //starting view of game
        {
            Console.WriteLine("Welcome to Chess!");
            Console.WriteLine();
            Console.WriteLine("   a   b   c   d   e   f   g   h ");
            Console.WriteLine(" +---+---+---+---+---+---+---+---+");
            for (int i = 0; i < 8; i++)
            {
                Console.Write($"{i + 1}");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"| {this[i, j]} ");
                }
                Console.Write("|");
                Console.WriteLine($"{i + 1}");
                Console.WriteLine(" +---+---+---+---+---+---+---+---+");
            }
            Console.WriteLine("   a   b   c   d   e   f   g   h ");
            Console.WriteLine();
            Console.WriteLine("White's move");
        }

        public void Run()
        {
            Show();
            while (cmd != "quit")
            {
                temp = Console.ReadLine().Split(' ');
                cmd = temp[0];

                switch (cmd)
                {
                    case "help"://Show menu
                        Console.WriteLine("Possible commands:");
                        Console.WriteLine("help  - Show this menu");
                        Console.WriteLine("quit  - Quit Chess");
                        Console.WriteLine("new   - Create a new game");
                        Console.WriteLine("board - Show the chess board");
                        Console.WriteLine("list  - List all possible moves");
                        Console.WriteLine("move {colrow}-{colrow} - Make a move");
                        break;

                    case "quit"://Quit Chess
                        Console.WriteLine("Goodbye!");
                        break;

                    case "new"://Create a new game
                        Console.Clear();
                        Console.WriteLine("New game is started");
                        Start();
                        Show();
                        break;

                    case "list":
                        //TODO: createList(color)
                        break;

                    case "board":
                        Show();
                        break;

                    case "move":
                        MoveFromTo();
                        Show();

                        if (CheckCheck())
                        {
                            Console.WriteLine("Check!!!");
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    Chess ch = desk[i, j];
                                    if (ch != null && ch.colour != currColour)
                                    {
                                        int count;
                                        Step[] list = ch.GetPossibleSteps(i, j, out count);
                                        for (int k = 0; k < count; k++)
                                        {

                                        }
                                    }
                                }

                            }
                        }

                        currColour = (currColour == 1) ? 0 : 1;

                        //TODO: нужно проверить нет ли Шаха после этого хода.
                        //Если есть то нужно сделать все возможный ходы для "следущего цвета" и после кажого проверять нет ли Шах.
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }

        public bool CheckCheck()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Chess ch = desk[i, j];
                    if (ch != null)
                    {
                        ch.GetPossibleSteps(i, j);
                        if (currColour == 1)
                        {
                            if (blackKing.attacked)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (whiteKing.attacked)
                            {
                                return true;
                            }
                        }

                    }
                }
            }
            return false;
        }


        //it whould be better to remove this code to each  class's inheritor of Chess
        void MoveFromTo()
        {
            Step step = new Step(temp[1], temp[2]);
            Chess currChess = desk[step.fromX, step.fromY];
            if (currChess != null)
            {
                currChess.Move(step);
            }
            else
            {
                Console.WriteLine("There is no chess piece!!!");
            }
        }
    }
}

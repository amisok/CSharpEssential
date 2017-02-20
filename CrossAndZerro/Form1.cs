using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossAndZerro
{
    public partial class Form1 : Form
    {
        Game game;
        public Form1()
        {
            InitializeComponent();
            game = new Game();
            game.changeState += FormChangeStateHandler;
            ShowGame();
            labelMessage.Text = "New game";
        }

        private void FormChangeStateHandler(CheckResult p)
        {
            if (p == CheckResult.CrossWin)
            {
                LockButtons();
                labelMessage.Text = "The game is finished. Cross is winner";
            }
            else if (p == CheckResult.ZeroWin)
            {
                LockButtons();
                labelMessage.Text = "The game is finished. Zerro is winner";
            }
            else if (p == CheckResult.DeadHeat)
            {
                LockButtons();
                labelMessage.Text = "The game is finished. It's deap heap";
            }
        }

        private void LockButtons()
        {
            button00.Enabled = false;
            button01.Enabled = false;
            button02.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button20.Enabled = false;
            button21.Enabled = false;
            button22.Enabled = false;
        }
        private void UnLockButtons()
        {
            button00.Enabled = true;
            button01.Enabled = true;
            button02.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button20.Enabled = true;
            button21.Enabled = true;
            button22.Enabled = true;
        }

        public void ShowGame()
        {
            button00.Text = PlayerToString(game.map[0, 0]);
            button01.Text = PlayerToString(game.map[0, 1]);
            button02.Text = PlayerToString(game.map[0, 2]);
            button10.Text = PlayerToString(game.map[1, 0]);
            button11.Text = PlayerToString(game.map[1, 1]);
            button12.Text = PlayerToString(game.map[1, 2]);
            button20.Text = PlayerToString(game.map[2, 0]);
            button21.Text = PlayerToString(game.map[2, 1]);
            button22.Text = PlayerToString(game.map[2, 2]);
            ShowPlayer();

        }
        private void ShowPlayer()
        {
            if (game.currPlayer == Player.Cross)
            {
                labelPlayer.Text = "Next move: Cross";
            }
            else if (game.currPlayer == Player.Zero)
            {
                labelPlayer.Text = "Next move: Zero";
            }
        }
        private string PlayerToString(Player player)
        {
            string str = "";
            if (player == Player.Cross)
            {
                str = "X";
            }
            else if (player == Player.Zero)
            {
                str = "0";
            }
            return str;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            game = new Game();
            UnLockButtons();
            game.changeState += FormChangeStateHandler;
            ShowGame();
            labelMessage.Text = "New game";
        }



        private void button00_Click(object sender, EventArgs e)
        {
            try
            {

                labelMessage.Text = "";
                game.SetPosition(0, 0);
                ShowGame();
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }

        private void button01_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = "";
                game.SetPosition(0, 1);
                ShowGame();

            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }

        private void button02_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = "";
                game.SetPosition(0, 2);
                ShowGame();
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = "";
                game.SetPosition(1, 0);
                ShowGame();
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = "";
                game.SetPosition(1, 1);
                ShowGame();
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = "";
                game.SetPosition(1, 2);
                ShowGame();
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = "";
                game.SetPosition(2, 0);
                ShowGame();
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = "";
                game.SetPosition(2, 1);
                ShowGame();
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = "";
                game.SetPosition(2, 2);
                ShowGame();
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }
    }

    class Game
    {
        public delegate void ChangeState(CheckResult newState);
        public event ChangeState changeState;
        public Player[,] map;
        public Player currPlayer;

        CheckResult currState = CheckResult.Continue;

        private void OnChangeState()
        {
            CheckResult newState = Check();
            if (currState != newState)
            {
                currState = newState;
                if (changeState != null)
                    changeState(currState);
            }
        }

        public void SetPosition(int x, int y)
        {
            if (map[x, y] != 0)
            {
                throw new Exception("Action is not allowed");
            }
            if (x > map.GetLength(0) || x < 0 || y > map.GetLength(1) || y < 0)
            {
                throw new IndexOutOfRangeException();
            }

            map[x, y] = currPlayer;

            ChangePlayer();
            OnChangeState();
        }

        public CheckResult Check()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (map[i, j] == map[i, j + 1] && map[i, j] == map[i, j + 2] && map[i, j] != Player.Empty)
                    {
                        if (map[i, j] == Player.Cross)
                            return CheckResult.CrossWin;
                        else
                            return CheckResult.ZeroWin;
                    }
                }
            }

            for (int j = 0; j < map.GetLength(1); j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    if (map[i, j] == map[i + 1, j] && map[i, j] == map[i + 2, j] && map[i, j] != Player.Empty)
                    {
                        if (map[i, j] == Player.Cross)
                            return CheckResult.CrossWin;
                        else
                            return CheckResult.ZeroWin;
                    }
                }
            }

            if (map[0, 0] == map[1, 1] && map[0, 0] == map[2, 2] && map[0, 0] != Player.Empty)
            {
                if (map[0, 0] == Player.Cross)
                    return CheckResult.CrossWin;
                else
                    return CheckResult.ZeroWin;
            }

            if (map[0, 2] == map[1, 1] && map[0, 2] == map[2, 0] && map[0, 2] != Player.Empty)
            {
                if (map[0, 2] == Player.Cross)
                    return CheckResult.CrossWin;
                else
                    return CheckResult.ZeroWin;
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == Player.Empty)
                        return CheckResult.Continue;
                }
            }
            return CheckResult.DeadHeat;
        }

        public void ChangePlayer()
        {
            currPlayer = (currPlayer == Player.Cross) ? Player.Zero : Player.Cross;
        }

        public Game(Player player)
        {
            map = new Player[3, 3];
            currPlayer = player;
        }
        public Game()
        {
            map = new Player[3, 3];
            currPlayer = Player.Cross;
        }
    }

    enum Player
    {
        Empty = 0,
        Cross = 1,
        Zero = 2
    }

    enum CheckResult
    {
        Continue,
        CrossWin,
        ZeroWin,
        DeadHeat
    }
}

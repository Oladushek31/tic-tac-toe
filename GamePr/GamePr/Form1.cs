using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePr
{
    public partial class Form1 : Form
    {
        private bool _isPlayerX = true;
        private bool _gameOver = false;
        private int _movesCount = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    button.Text = "";
                    button.Enabled = false;
                }
            }

            startButton.Enabled = true;
            startButton.Text = "Старт";
            conditionLabel.Text = "Игра не начата";
            _gameOver = false;
            _movesCount = 0;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "Старт")
            {
                StartNewGame();
            }
            else if (startButton.Text == "Перезапустить")
            {
                InitializeGame();
            }
        }

        private void StartNewGame()
        {
            startButton.Enabled = false;
            startButton.Text = "Перезапустить";
            _isPlayerX = true;
            conditionLabel.Text = "Ход игрока X";
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = true;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text != "" || _gameOver)
                return;

            button.Text = _isPlayerX ? "X" : "O";
            _isPlayerX = !_isPlayerX;
            _movesCount++;

            if (CheckForWinner())
            {
                string winner = _isPlayerX ? "O" : "X";
                conditionLabel.Text = $"Игра окончена. Победил игрок {winner}!";
                _gameOver = true;
                DisableAllButtons();
            }
            else if (_movesCount == 9)
            {
                conditionLabel.Text = "Игра окончена. Ничья!";
                _gameOver = true;
                DisableAllButtons();
            }
            else
            {
                conditionLabel.Text = _isPlayerX ? "Ход игрока X" : "Ход игрока O";
            }
        }

        private void DisableAllButtons()
        {
            foreach (Control control in Controls)
            {
                if (control is Button btn)
                {
                    btn.Enabled = false;
                }
            }
        }

        private bool CheckForWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (button1.Text == button2.Text && button2.Text == button3.Text && button1.Text != "")
                    return true;
                if (button4.Text == button5.Text && button5.Text == button6.Text && button4.Text != "")
                    return true;
                if (button7.Text == button8.Text && button8.Text == button9.Text && button7.Text != "")
                    return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (button1.Text == button4.Text && button4.Text == button7.Text && button1.Text != "")
                    return true;
                if (button2.Text == button5.Text && button5.Text == button8.Text && button2.Text != "")
                    return true;
                if (button3.Text == button6.Text && button6.Text == button9.Text && button3.Text != "")
                    return true;
            }

            if (button1.Text == button5.Text && button5.Text == button9.Text && button1.Text != "")
                return true;
            if (button3.Text == button5.Text && button5.Text == button7.Text && button3.Text != "")
                return true;

            return false;
        }
    }
}

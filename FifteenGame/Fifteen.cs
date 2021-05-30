using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLibrary;
using ComponentLibrary;

namespace FifteenGame
{
    public partial class Fifteen : Form
    {
        Stack<Caretaker> gameStates;
        Game game;
        int size, steps;
        public Fifteen()
        {
            InitializeComponent();
            steps = 0;
            size = 4;
            game = new Game(size, size);
            gameStates = new Stack<Caretaker>();
        }

        private void RefreshButtonField()
        {
            for (int position = 0; position < size * size; ++position)
            {
                ComponentLibrary.Button currButton = GetButton(position);
                int number = game.GetNumber(position);

                currButton.Text = number.ToString();
                if (number == 0)
                    currButton.Visible = false;
                else
                    currButton.Visible = true;
            }
        }

        private void startMenu_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void Fifteen_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            gameStates.Clear();
            stepsLabel.Text = "Количество ходов: 0";
            steps = 0;
            game.Start();
            RefreshButtonField();
            gameTimer.Start();
        }

        private void отменитьХодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameStates.Any())
            {
                stepsLabel.Text = "Количество ходов: " + (--steps).ToString();
                game.SetGameState(gameStates.Pop().GameState);
                RefreshButtonField();
            }
        }

        private void button0_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is ComponentLibrary.Button)
            {
                Caretaker nextStep = new Caretaker(game.CreateGameState());
                int position = Convert.ToInt32(((ComponentLibrary.Button)sender).Tag);
                int selectButtonNum = game.Shift(position);
                GetButton(selectButtonNum).Select();
                RefreshButtonField();
                if (position != selectButtonNum)
                {
                    stepsLabel.Text = "Количество ходов: " + (++steps).ToString();
                    gameStates.Push(nextStep);
                }

                if (game.End())
                {
                    gameTimer.Stop();
                    if (MessageBox.Show($"Вы собрали пятнашки!\nКоличество ходов: {steps}\nВремя: {gameTimer.Text}\nСыграть ещё раз?", "Победа!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        Close();
                    else
                        StartGame();
                }
            }
            else
                throw new ArgumentException();
        }

        private ComponentLibrary.Button GetButton(int index)
        {
            return (ComponentLibrary.Button)tableLayoutPanel1.Controls["button" + index.ToString()];
        }
    }
}

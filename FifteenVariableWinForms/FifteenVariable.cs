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

namespace FifteenGame
{
    public partial class Fifteen : Form
    {
        TableLayoutPanel panel;
        Button[] buttons;
        Game game;
        Stack<Caretaker> gameStates;
        int width, height, steps, seconds, minutes;
        public Fifteen()
        {
            InitializeComponent();
            steps = seconds = minutes = 0;
            width = height = 4;
            gameStates = new Stack<Caretaker>();
        }

        private void RefreshButtonField()
        {
            for (int position = 0; position < width * height; ++position)
            {
                int number = game.GetNumber(position);

                buttons[position].Text = number.ToString();
                if (number == 0)
                    buttons[position].Visible = false;
                else
                    buttons[position].Visible = true;
            }
        }

        private void SetButtons()
        {
            Size screen = Screen.PrimaryScreen.Bounds.Size;
            for (int i = 0; i < height; ++i)
                for (int j = 0; j < width; ++j)
                {
                    int position = i * width + j;
                    int number = game.GetNumber(position);
                    buttons[position] = new Button();
                    buttons[position].Tag = position;
                    buttons[position].Click += new EventHandler(buttonClick);
                    buttons[position].Width = screen.Width;
                    buttons[position].Height = screen.Height;
                    buttons[position].BackColor = Color.WhiteSmoke;
                    buttons[position].Font = new Font("Microsoft Sans Serif",
                        Math.Max(Width, Height) / Math.Max(width, height) / 4, FontStyle.Bold);
                    buttons[position].Text = number.ToString();
                    if (number == 0)
                        buttons[position].Visible = false;
                    panel.Controls.Add(buttons[position], j, i + 1);
                }
            panel.Controls.Add(stepsLabel, 0, height + 1);
            panel.SetColumnSpan(stepsLabel, width / 2);
            panel.Controls.Add(timeLabel, width / 2, height + 1);
            panel.SetColumnSpan(timeLabel, width / 2);
        }

        private void startMenu_Click(object sender, EventArgs e)
        {
            Dispose();
            StartGame();
        }

        private new void Dispose()
        {
            panel.Dispose();
            foreach (System.Windows.Forms.Button button in buttons)
                button.Dispose();
        }

        private void Fifteen_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {         
            steps = seconds = minutes = 0;
            SetWindowSize();
            SetTableLayoutPanel();
            SetTimeLabel();
            SetStepsLabel();
            buttons = new System.Windows.Forms.Button[height * width];
            game = new Game(width, height);
            game.Start();
            SetButtons();
            CenterToScreen();
            timer.Start();
        }

        private void SetWindowSize()
        {
            Size screen = Screen.PrimaryScreen.Bounds.Size;
            Width = Height = (int)(Math.Min(screen.Width, screen.Height) / 1.5);
            /*if (width > height)
                Height /= width / height;
            else
                Width /= height / width;*/
            Height += 40;
        }

        private void SetTableLayoutPanel()
        {
            panel = new TableLayoutPanel();
            panel.Location = new Point(0, 0);
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.Dock = DockStyle.Fill;
            panel.ColumnCount = width;
            panel.RowCount = height + 2;
            for (int i = 0; i < width; ++i)
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / width));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            for (int j = 0; j < height; ++j)
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / height));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            Controls.Add(panel);
        }

        private void SetTimeLabel()
        {
            timeLabel = new Label();
            timeLabel.Width = Width / 2;
            timeLabel.Text = "Время: 0 сек.";
            timeLabel.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void SetStepsLabel()
        {
            stepsLabel = new Label();
            stepsLabel.Width = Width / 2;
            stepsLabel.Text = "Количество ходов: 0";
            stepsLabel.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (++seconds >= 60)
            {
                ++minutes;
                seconds = 0;
            }

            string time = "Время: ";
            if (minutes > 0)
                time += minutes.ToString() + " мин. ";
            time += seconds.ToString() + " сек.";
            timeLabel.Text = time;
        }

        private void buttonClick(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Caretaker nextStep = new Caretaker(game.CreateGameState());
                int position = Convert.ToInt32(((Button)sender).Tag);
                int selectButtonNum = game.Shift(position);
                buttons[selectButtonNum].Select();
                RefreshButtonField();
                if (position != selectButtonNum)
                {
                    stepsLabel.Text = "Количество ходов: " + (++steps).ToString();
                    gameStates.Push(nextStep);
                }

                if (game.End())
                {
                    timer.Stop();
                    string time = minutes > 0 ? $"{minutes} мин. {seconds} сек." : $"{seconds} сек.";
                    if (MessageBox.Show($"Вы собрали пятнашки!\nКоличество ходов: {steps}\nВремя: {time}\nСыграть ещё раз?", "Победа!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        Close();
                    else
                    {
                        Dispose();
                        StartGame();
                    }
                }
            }
            else
                throw new ArgumentException();
        }

        private void ResizeField()
        {
            timer.Stop();
            Dispose();
            StartGame();
        }

        private void UncheckAllWidthStripes()
        {
            toolStripMenuItem0.Checked = toolStripMenuItem1.Checked = toolStripMenuItem2.Checked
                = toolStripMenuItem3.Checked = toolStripMenuItem4.Checked = toolStripMenuItem5.Checked
                = toolStripMenuItem6.Checked = toolStripMenuItem7.Checked = toolStripMenuItem8.Checked = false;
        }

        private void UncheckAllHeightStripes()
        {
            toolStripMenuItem9.Checked = toolStripMenuItem10.Checked = toolStripMenuItem11.Checked
                = toolStripMenuItem12.Checked = toolStripMenuItem13.Checked = toolStripMenuItem14.Checked
                = toolStripMenuItem15.Checked = toolStripMenuItem16.Checked = toolStripMenuItem17.Checked = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = false;
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllWidthStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                width = 2;
                ResizeField();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllWidthStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                width = 3;
                ResizeField();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllWidthStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                width = 4;
                ResizeField();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllWidthStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                width = 5;
                ResizeField();
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllWidthStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                width = 6;
                ResizeField();
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllWidthStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                width = 7;
                ResizeField();
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllWidthStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                width = 8;
                ResizeField();
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllWidthStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                width = 9;
                ResizeField();
            }
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllWidthStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                width = 10;
                ResizeField();
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllHeightStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                height = 2;
                ResizeField();
            }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllHeightStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                height = 3;
                ResizeField();
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllHeightStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                height = 4;
                ResizeField();
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllHeightStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                height = 5;
                ResizeField();
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllHeightStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                height = 6;
                ResizeField();
            }
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

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllHeightStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                height = 7;
                ResizeField();
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllHeightStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                height = 8;
                ResizeField();
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllHeightStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                height = 9;
                ResizeField();
            }
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UncheckAllHeightStripes();
                ((ToolStripMenuItem)sender).Checked = true;
                height = 10;
                ResizeField();
            }
        }

    }
}

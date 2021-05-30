using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GameLibrary;

namespace FifteenWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stack<Caretaker> gameStates;
        DispatcherTimer timer;
        Game game;
        int size, steps, seconds, minutes;

        public MainWindow()
        {
            InitializeComponent();
            steps = seconds = minutes = 0;
            size = 4;
            game = new Game(size, size);
            gameStates = new Stack<Caretaker>();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            steps = seconds = minutes = 0;
            game.Start();
            RefreshButtonField();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
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
            timerLabel.Content = time;
        }

        private void MenuStepBack_Click(object sender, RoutedEventArgs e)
        {
            if (gameStates.Any())
            {
                stepsLabel.Content = "Количество ходов: " + (--steps).ToString();
                game.SetGameState(gameStates.Pop().GameState);
                RefreshButtonField();
            }
        }

        private void RefreshButtonField()
        {
            for (int position = 0; position < size * size; ++position)
            {
                Button currButton = GetButton(position);
                int number = game.GetNumber(position);

                currButton.Content = number;
                if (number == 0)
                    currButton.Visibility = Visibility.Hidden;
                else
                    currButton.Visibility = Visibility.Visible;
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Caretaker nextStep = new Caretaker(game.CreateGameState());
            int position = Convert.ToInt32(((Button)sender).Tag);
            int selectButtonNum = game.Shift(position);
            GetButton(selectButtonNum).Focus();
            RefreshButtonField();
            if (position != selectButtonNum)
            {
                stepsLabel.Content = "Количество ходов: " + (++steps).ToString();
                gameStates.Push(nextStep);
            }

            if (game.End())
            {
                timer.Stop();
                string time = minutes > 0 ? $"{minutes} мин. {seconds} сек." : $"{seconds} сек.";
                if (MessageBox.Show($"Вы собрали пятнашки!\nКоличество ходов: {steps}\nВремя: {time}\nСыграть ещё раз?", "Победа!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    Close();
                else
                    StartGame(sender, e);
            }
        }

        private Button GetButton(int index)
        {
            switch (index)
            {
                case 0:
                    return button0;
                case 1:
                    return button1;
                case 2:
                    return button2;
                case 3:
                    return button3;
                case 4:
                    return button4;
                case 5:
                    return button5;
                case 6:
                    return button6;
                case 7:
                    return button7;
                case 8:
                    return button8;
                case 9:
                    return button9;
                case 10:
                    return button10;
                case 11:
                    return button11;
                case 12:
                    return button12;
                case 13:
                    return button13;
                case 14:
                    return button14;
                case 15:
                    return button15;
                default:
                    throw new ArgumentException();
            }
        }
    }
}

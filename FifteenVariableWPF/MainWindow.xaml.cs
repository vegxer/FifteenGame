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

namespace FifteenVariableWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stack<Caretaker> gameStates;
        Label timeLabel, stepsLabel;
        DispatcherTimer timer;
        Grid panel;
        Button[] buttons;
        Game game;
        int width, height, steps, seconds, minutes;

        public MainWindow()
        {
            InitializeComponent();
            gameStates = new Stack<Caretaker>();
            steps = seconds = minutes = 0;
            width = height = 4;
        }

        private void RefreshButtonField()
        {
            for (int position = 0; position < width * height; ++position)
            {
                int number = game.GetNumber(position);

                buttons[position].Content = number;
                if (number == 0)
                    buttons[position].Visibility = Visibility.Hidden;
                else
                    buttons[position].Visibility = Visibility.Visible;
            }
        }

        private void SetButtons()
        {
            for (int i = 0; i < height; ++i)
                for (int j = 0; j < width; ++j)
                {
                    int position = i * width + j;
                    int number = game.GetNumber(position);
                    buttons[position] = new Button();
                    buttons[position].Tag = position;
                    buttons[position].Click += new RoutedEventHandler(buttonClick);
                    buttons[position].FontSize = Math.Max(Width, Height) / Math.Max(width, height) / 4;
                    buttons[position].FontWeight = FontWeights.Bold;
                    buttons[position].Margin = new Thickness(2, 2, 2, 2);
                    buttons[position].Content = number;
                    buttons[position].VerticalAlignment = VerticalAlignment.Stretch;
                    buttons[position].HorizontalAlignment = HorizontalAlignment.Stretch;
                    Grid.SetColumn(buttons[position], j);
                    Grid.SetRow(buttons[position], i + 1);
                    panel.Children.Add(buttons[position]);
                }
        }

        private void startMenu_Click(object sender, EventArgs e)
        {
            Dispose();
            StartGame();
        }

        private void Dispose()
        {
            foreach (Button button in buttons)
                panel.Children.Remove(button);
            panel.Children.Remove(stepsLabel);
            panel.Children.Remove(Menu);
            panel.Children.Remove(timeLabel);
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            steps = seconds = minutes = 0;
            SetWindowSize();
            Top = SystemParameters.PrimaryScreenHeight / 2 - Height / 2;
            Left = SystemParameters.PrimaryScreenWidth / 2 - Width / 2;
            SetGrid();
            SetTimeLabel();
            SetStepsLabel();
            buttons = new Button[height * width];
            game = new Game(width, height);
            game.Start();
            SetButtons();
            SetMenu();
            SetLabels();
            RefreshButtonField();
            SetTimer();
            Content = panel;
        }

        private void SetTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void SetWindowSize()
        {
            Width = Height = (int)(Math.Min(SystemParameters.PrimaryScreenWidth, SystemParameters.PrimaryScreenHeight) / 1.5);
            /*if (width > height)
                Height /= width / height;
            else
                Width /= height / width;*/
            Height += 40;
        }

        private void SetGrid()
        {
            panel = new Grid();
            panel.Margin = new Thickness(2, 2, 2, 2);
            panel.HorizontalAlignment = HorizontalAlignment.Stretch;
            panel.VerticalAlignment = VerticalAlignment.Stretch;

            ColumnDefinition[] colDef = new ColumnDefinition[width];
            for (int i = 0; i < width; ++i)
            {
                colDef[i] = new ColumnDefinition();
                colDef[i].Width = new GridLength(1.0, GridUnitType.Star);
                panel.ColumnDefinitions.Add(colDef[i]);
            }

            Height += 52;
            RowDefinition menuRowDef = new RowDefinition();
            menuRowDef.Height = new GridLength(25, GridUnitType.Pixel);
            panel.RowDefinitions.Add(menuRowDef);
            RowDefinition[] rowDef = new RowDefinition[height];
            for (int i = 0; i < height; ++i)
            {
                rowDef[i] = new RowDefinition();
                rowDef[i].Height = new GridLength(1.0, GridUnitType.Star);
                panel.RowDefinitions.Add(rowDef[i]);
            }
            RowDefinition lowerRowDef = new RowDefinition();
            lowerRowDef.Height = new GridLength(27, GridUnitType.Pixel);
            panel.RowDefinitions.Add(lowerRowDef);
        }

        private void SetMenu()
        {
            Grid.SetRow(Menu, 0);
            Grid.SetColumn(Menu, 0);
            Grid.SetColumnSpan(Menu, width);
            dockPanel.Children.Remove(Menu);
            panel.Children.Add(Menu);
        }

        private void SetLabels()
        {
            Grid.SetColumn(stepsLabel, 0);
            Grid.SetRow(stepsLabel, height + 1);
            Grid.SetColumnSpan(stepsLabel, width / 2);
            panel.Children.Add(stepsLabel);

            Grid.SetColumn(timeLabel, width / 2);
            Grid.SetRow(timeLabel, height + 1);
            Grid.SetColumnSpan(timeLabel, width / 2);
            panel.Children.Add(timeLabel);
        }

        private void SetTimeLabel()
        {
            timeLabel = new Label();
            timeLabel.Width = Width / 2;
            timeLabel.Content = "Время: 0 сек.";
            timeLabel.FontSize = 14;
        }

        private void SetStepsLabel()
        {
            stepsLabel = new Label();
            stepsLabel.Width = Width / 2;
            stepsLabel.Content = "Количество ходов: 0";
            stepsLabel.FontSize = 14;
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
            timeLabel.Content = time;
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Caretaker nextStep = new Caretaker(game.CreateGameState());
            int position = Convert.ToInt32(((Button)sender).Tag);
            int selectButtonNum = game.Shift(position);
            buttons[selectButtonNum].Focus();
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
                {
                    Dispose();
                    StartGame();
                }
            }
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

        private void ResizeField()
        {
            timer.Stop();
            Dispose();
            StartGame();
        }

        private void MenuItemWidth_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                UncheckAllWidthStripes();
                MenuItem item = (MenuItem)sender;
                width = Convert.ToInt32(item.Header);
                item.IsChecked = true;
                ResizeField();
            }
        }

        private void MenuItemHeight_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Если Вы смените размер поля, то игра начнётся заново!", "Изменить размер поля?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                UncheckAllHeightStripes();
                MenuItem item = (MenuItem)sender;
                height = Convert.ToInt32(item.Header);
                item.IsChecked = true;
                ResizeField();
            }
        }

        private void UncheckAllWidthStripes()
        {
            MenuWidth2.IsChecked = MenuWidth3.IsChecked = MenuWidth4.IsChecked
                = MenuWidth5.IsChecked = MenuWidth6.IsChecked = MenuWidth7.IsChecked
                = MenuWidth8.IsChecked = MenuWidth9.IsChecked = MenuWidth10.IsChecked = false;
        }

        private void UncheckAllHeightStripes()
        {
            MenuHeight2.IsChecked = MenuHeight3.IsChecked = MenuHeight4.IsChecked
                = MenuHeight5.IsChecked = MenuHeight6.IsChecked = MenuHeight7.IsChecked
                = MenuHeight8.IsChecked = MenuHeight9.IsChecked = MenuHeight10.IsChecked = false;
        }
    }
}

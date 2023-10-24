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

namespace zad_2_Szymon_Olszok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private char currentPlayer = 'X';
        private Button[,] buttons = new Button[3, 3];
        private bool gameEnded = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button button = new Button
                    {
                        Name = $"btn{row}{col}",
                        Content = string.Empty,
                        FontSize = 96
                    };
                    button.Click += OnButtonClick;
                    buttons[row, col] = button;
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    grid.Children.Add(button);
                }
            }
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            if (gameEnded)
            {
                MessageBox.Show("Gra zakończona. Rozpocznij nową grę.");
                return;
            }

            Button button = (Button)sender;
            if (string.IsNullOrEmpty(button.Content.ToString()))
            {
                button.Content = currentPlayer;

                if (CheckForWinner(currentPlayer))
                {
                    MessageBox.Show($"Gracz {currentPlayer} wygrywa!");
                    gameEnded = true;
                }
                else if (IsBoardFull())
                {
                    MessageBox.Show("Remis!");
                    gameEnded = true;
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }

        private bool CheckForWinner(char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Content.ToString() == player.ToString() &&
                    buttons[i, 1].Content.ToString() == player.ToString() &&
                    buttons[i, 2].Content.ToString() == player.ToString())
                {
                    return true;
                }

                if (buttons[0, i].Content.ToString() == player.ToString() &&
                    buttons[1, i].Content.ToString() == player.ToString() &&
                    buttons[2, i].Content.ToString() == player.ToString())
                {
                    return true;
                }
            }

            if (buttons[0, 0].Content.ToString() == player.ToString() &&
                buttons[1, 1].Content.ToString() == player.ToString() &&
                buttons[2, 2].Content.ToString() == player.ToString())
            {
                return true;
            }

            if (buttons[0, 2].Content.ToString() == player.ToString() &&
                buttons[1, 1].Content.ToString() == player.ToString() &&
                buttons[2, 0].Content.ToString() == player.ToString())
            {
                return true;
            }

            return false;
        }

        private bool IsBoardFull()
        {
            foreach (Button button in buttons)
            {
                if (string.IsNullOrEmpty(button.Content.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void NewGame()
        {
            foreach (Button button in buttons)
            {
                button.Content = string.Empty;
            }
            currentPlayer = 'X';
            gameEnded = false;
        }
    }
}
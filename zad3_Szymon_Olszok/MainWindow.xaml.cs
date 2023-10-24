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

namespace zad3_Szymon_Olszok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isPlayerTurn = true;
        private int playerShipsRemaining = 5;
        private int enemyShipsRemaining = 5;
        private Button[,] playerBoard = new Button[10, 10];
        private Button[,] enemyBoard = new Button[10, 10];

        public MainWindow()
        {
            InitializeComponent();
            CreateGameBoard();
            PlaceShipsRandomly(playerBoard);
        }

        private void CreateGameBoard()
        {
            // Tworzenie planszy gracza
            Grid playerGrid = new Grid();
            playerGrid.RowDefinitions.Add(new RowDefinition());
            playerGrid.ColumnDefinitions.Add(new ColumnDefinition());

            // Tworzenie planszy przeciwnika
            Grid enemyGrid = new Grid();
            enemyGrid.RowDefinitions.Add(new RowDefinition());
            enemyGrid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    Button playerCell = new Button
                    {
                        Name = $"PlayerCell_{row}_{col}",
                        Content = "",
                        Tag = "Empty",
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };
                    playerCell.Click += PlayerCell_Click;
                    Grid.SetRow(playerCell, row);
                    Grid.SetColumn(playerCell, col);
                    playerBoard[row, col] = playerCell;
                    playerGrid.Children.Add(playerCell);

                    Button enemyCell = new Button
                    {
                        Name = $"EnemyCell_{row}_{col}",
                        Content = "",
                        Tag = "Empty",
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };
                    enemyCell.Click += EnemyCell_Click;
                    Grid.SetRow(enemyCell, row);
                    Grid.SetColumn(enemyCell, col);
                    enemyBoard[row, col] = enemyCell;
                    enemyGrid.Children.Add(enemyCell);
                }
            }

            Grid.SetRow(playerGrid, 0);
            Grid.SetColumn(playerGrid, 0);
            Grid.SetRow(enemyGrid, 0);
            Grid.SetColumn(enemyGrid, 1);
            this.Content = new Grid { Children = { playerGrid, enemyGrid } };
        }

        private void PlaceShipsRandomly(Button[,] board)
        {
            // Implementuj losowe rozmieszczanie statków na planszy gracza
            // Poniżej znajduje się przykład losowego rozmieszczenia jednego statku o długości 5 pól
            Random random = new Random();
            int row = random.Next(10);
            int col = random.Next(10);
            bool isHorizontal = random.Next(2) == 0; // Losowo wybierz orientację statku

            if (CanPlaceShip(board, row, col, isHorizontal, 5))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (isHorizontal)
                    {
                        board[row, col + i].Tag = "Ship";
                    }
                    else
                    {
                        board[row + i, col].Tag = "Ship";
                    }
                }
            }
            else
            {
                // Jeśli nie możemy rozmieścić statku, spróbuj ponownie
                PlaceShipsRandomly(board);
            }
        }

        private bool CanPlaceShip(Button[,] board, int row, int col, bool isHorizontal, int length)
        {
            // Sprawdza, czy można umieścić statek na danej pozycji
            if (isHorizontal)
            {
                if (col + length > 10)
                {
                    return false;
                }
                for (int i = 0; i < length; i++)
                {
                    if (board[row, col + i].Tag != "Empty")
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (row + length > 10)
                {
                    return false;
                }
                for (int i = 0; i < length; i++)
                {
                    if (board[row + i, col].Tag != "Empty")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void PlayerCell_Click(object sender, RoutedEventArgs e)
        {
            if (!isPlayerTurn)
                return;

            Button cell = (Button)sender;
            if (cell.Tag.ToString() == "Empty")
            {
                // Gracz oddaje strzał w puste pole.
                cell.Background = Brushes.Gray;
                cell.Tag = "Miss";
                isPlayerTurn = false;

                // Sprawdzamy, czy trafienie zniszczyło statek przeciwnika.
                if (cell.Name.StartsWith("EnemyCell") && cell.Tag.ToString() == "Miss")
                {
                    // Przeciwnik strzelił i chybiony, zmniejsz liczbę pozostałych statków przeciwnika.
                    enemyShipsRemaining--;
                }

                if (enemyShipsRemaining == 0)
                {
                    // Gracz wygrał grę, ponieważ zatopił wszystkie statki przeciwnika.
                    MessageBox.Show("Gratulacje! Wygrałeś grę!");
                    ResetGame();
                }
            }
        }

        private void EnemyCell_Click(object sender, RoutedEventArgs e)
        {
            if (isPlayerTurn)
                return;

            Button cell = (Button)sender;
            if (cell.Tag.ToString() == "Empty")
            {
                // Przeciwnik oddaje strzał w puste pole.
                cell.Background = Brushes.Gray;
                cell.Tag = "Miss";
                isPlayerTurn = true;

                // Sprawdzamy, czy trafienie zniszczyło statek gracza.
                if (cell.Name.StartsWith("PlayerCell") && cell.Tag.ToString() == "Miss")
                {
                    // Gracz strzelił i chybiony, zmniejsz liczbę pozostałych statków gracza.
                    playerShipsRemaining--;
                }

                if (playerShipsRemaining == 0)
                {
                    // Przeciwnik wygrał grę, ponieważ zatopił wszystkie statki gracza.
                    MessageBox.Show("Przeciwnik wygrał grę. Spróbuj jeszcze raz.");
                    ResetGame();
                }
            }
        }

        private void ResetGame()
        {
            // Resetowanie gry, np. umieszczanie statków na planszy od nowa.
            // Możesz dodać dodatkową logikę resetowania gry według potrzeb.
            playerShipsRemaining = 5;
            enemyShipsRemaining = 5;
            isPlayerTurn = true;
            // Tutaj możesz wyczyścić plansze i rozmieścić statki na nowo.
        }
    }
}
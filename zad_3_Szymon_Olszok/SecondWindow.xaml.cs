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
using System.Windows.Shapes;

namespace zad_3_Szymon_Olszok
{
    /// <summary>
    /// Logika interakcji dla klasy SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            CreateGrid();
        }

        private void CreateGrid()
        {
            Grid grid = new Grid();

            Thickness buttonMargin = new Thickness(0);

            for (int i = 0; i < 11; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }


            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (row == 0)
                    {
                        TextBlock letterBlock = new TextBlock
                        {
                            Text = ((char)('A' + col)).ToString(),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = buttonMargin // Usunięcie marginesów
                        };
                        Grid.SetRow(letterBlock, row);
                        Grid.SetColumn(letterBlock, col + 1);
                        grid.Children.Add(letterBlock);
                    }

                    if (col == 0)
                    {
                        TextBlock numberBlock = new TextBlock
                        {
                            Text = (row + 1).ToString(),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = buttonMargin
                        };
                        Grid.SetRow(numberBlock, row + 1);
                        Grid.SetColumn(numberBlock, col);
                        grid.Children.Add(numberBlock);
                    }

                    Button button = new Button
                    {
                        Name = "Button_" + row + "_" + col,
                        Content = "",
                        Width = 64,
                        Height = 64,
                        Margin = buttonMargin
                    };

                    button.Click += Button_Click;
                    Grid.SetRow(button, row + 1);
                    Grid.SetColumn(button, col + 1);
                    grid.Children.Add(button);
                }
            }

            MainGrid2.Children.Add(grid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
        }
    }
}
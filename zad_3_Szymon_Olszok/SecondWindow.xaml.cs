﻿using System;
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
            // Tworzenie siatek 10x10 dla górnego i dolnego Gridda
            Grid topGridP2 = new Grid();
            Grid bottomGridP2 = new Grid();

            // Usuwanie marginesów przycisków
            Thickness buttonMargin = new Thickness(0);

            for (int i = 0; i < 11; i++)
            {
                topGridP2.RowDefinitions.Add(new RowDefinition());
                topGridP2.ColumnDefinitions.Add(new ColumnDefinition());

                bottomGridP2.RowDefinitions.Add(new RowDefinition());
                bottomGridP2.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Dodawanie przycisków do górnego i dolnego Gridda oraz oznaczeń liter
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (row == 0) // Pierwszy wiersz - oznaczenia liter
                    {
                        TextBlock letterBlockTop = new TextBlock
                        {
                            Text = ((char)('A' + col)).ToString(),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = buttonMargin // Usunięcie marginesów
                        };

                        TextBlock letterBlockBottom = new TextBlock
                        {
                            Text = ((char)('A' + col)).ToString(),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = buttonMargin // Usunięcie marginesów
                        };

                        Grid.SetRow(letterBlockTop, row);
                        Grid.SetColumn(letterBlockTop, col + 1); // +1, aby uniknąć zakrycia liczby
                        topGridP2.Children.Add(letterBlockTop);

                        Grid.SetRow(letterBlockBottom, row);
                        Grid.SetColumn(letterBlockBottom, col + 1); // +1, aby uniknąć zakrycia liczby
                        bottomGridP2.Children.Add(letterBlockBottom);
                    }

                    if (col == 0) // Pierwsza kolumna - liczby
                    {
                        TextBlock numberBlockTop = new TextBlock
                        {
                            Text = (row + 1).ToString(),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = buttonMargin // Usunięcie marginesów
                        };

                        TextBlock numberBlockBottom = new TextBlock
                        {
                            Text = (row + 1).ToString(),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = buttonMargin // Usunięcie marginesów
                        };

                        Grid.SetRow(numberBlockTop, row + 1); // +1, aby uniknąć zakrycia litery
                        Grid.SetColumn(numberBlockTop, col);
                        topGridP2.Children.Add(numberBlockTop);

                        Grid.SetRow(numberBlockBottom, row + 1); // +1, aby uniknąć zakrycia litery
                        Grid.SetColumn(numberBlockBottom, col);
                        bottomGridP2.Children.Add(numberBlockBottom);
                    }

                    Button buttonTop = new Button
                    {
                        Name = "ButtonTop_" + row + "_" + col,
                        Content = "",
                        Width = 40, // Zmniejszenie szerokości przycisku
                        Height = 40, // Zmniejszenie wysokości przycisku
                        Margin = buttonMargin // Usunięcie marginesów
                    };

                    Button buttonBottom = new Button
                    {
                        Name = "ButtonBottom_" + row + "_" + col,
                        Content = "",
                        Width = 40, // Zmniejszenie szerokości przycisku
                        Height = 40, // Zmniejszenie wysokości przycisku
                        Margin = buttonMargin // Usunięcie marginesów
                    };

                    buttonTop.Click += ButtonDeploy_Click;
                    buttonBottom.Click += ButtonShoot_Click;

                    Grid.SetRow(buttonTop, row + 1); // +1, aby uniknąć zakrycia litery
                    Grid.SetColumn(buttonTop, col + 1); // +1, aby uniknąć zakrycia liczby
                    topGridP2.Children.Add(buttonTop);

                    Grid.SetRow(buttonBottom, row + 1); // +1, aby uniknąć zakrycia litery
                    Grid.SetColumn(buttonBottom, col + 1); // +1, aby uniknąć zakrycia liczby
                    bottomGridP2.Children.Add(buttonBottom);
                }
            }

            // Dodawanie Griddów do odpowiednich kontenerów w oknie
            TopGridP2.Children.Add(topGridP2);
            BottomGridP2.Children.Add(bottomGridP2);
        }

        private void ButtonDeploy_Click(object sender, RoutedEventArgs e)
        {
            // Obsługa kliknięcia przycisku
            Button button = (Button)sender;
            // Tutaj możesz dodać kod obsługi kliknięcia przycisku gry w statki.
        }

        private void ButtonShoot_Click(object sender, RoutedEventArgs e)
        {
            // Obsługa kliknięcia przycisku
            Button button = (Button)sender;
            // Tutaj możesz dodać kod obsługi kliknięcia przycisku gry w statki.
        }
    }
}
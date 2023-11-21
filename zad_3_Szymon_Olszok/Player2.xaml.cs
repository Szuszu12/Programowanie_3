using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace zad_3_Szymon_Olszok
{
    public partial class Player2 : Window
    {
        public Player2()
        {
            InitializeComponent();
            int[] tab = new int[100];
            int[] tab2 = new int[100];
            InitializedeployButton(deployButton);
            InitializeUpperGrid(upperGrid, 10, Button_Click);
            InitializeShootButton(shootButton);
            InitializeLowerGrid(lowerGrid, 10, Button_Click_shot);
        }

        private void InitializeUpperGrid(UniformGrid grid, int gridSize, RoutedEventHandler clickHandler)
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button btn = new Button
                    {
                        Content = $"{i}.{j}",
                        Tag = i * gridSize + j,
                    };

                    Binding binding = new Binding($"PersonIdTwo[{btn.Tag}]");
                    binding.Converter = new YesNoToBooleanConverter();
                    btn.SetBinding(BackgroundProperty, binding);

                    btn.Click += Button_Click;
                    grid.Children.Add(btn);
                }
            }
        }

        private void InitializeLowerGrid(UniformGrid grid, int gridSize, RoutedEventHandler clickHandler)
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button btn = new Button
                    {
                        Content = $"{i}.{j}",
                        Tag = i * gridSize + j,
                    };

                    Binding binding = new Binding($"PersonIdOne[{btn.Tag}]");
                    binding.Converter = new YesNoToBooleanConverter2();
                    btn.SetBinding(BackgroundProperty, binding);

                    btn.Click += Button_Click_shot;
                    grid.Children.Add(btn);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 0)
                ((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())]++;
            else if (((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())]--;
        }

        private void Button_Click_shot(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 0 || ((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] += 2;
        }

        private void InitializedeployButton(Button button)
        {
            button.Content = "Rozmieść statki";
            button.Click += deployButton_Click;
        }

        private void deployButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InitializeShootButton(Button button)
        {
            button.Content = "Oddaj strzał";
            button.Click += shootButton_Click;
        }

        private void shootButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
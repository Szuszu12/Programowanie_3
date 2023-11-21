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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zad_3_Szymon_Olszok
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            int[] tab = new int[100];
            int[] tab2 = new int[100];
            Game gra = new Game(tab, tab2);
            plnPersonForm.DataContext = gra;
            InitializedeployButton(deployButton);
            InitializeUpperGrid(upperGrid, 10, Button_Click);
            InitializeShootButton(shootButton);
            InitializeLowerGrid(lowerGrid, 10, Button_Click_shot);
            Player2 okno = new Player2();
            okno.DataContext = gra;
            okno.Show();
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

                    Binding binding = new Binding($"PersonIdOne[{btn.Tag}]");
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

                    Binding binding = new Binding($"PersonIdTwo[{btn.Tag}]");
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
            if (((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 0)
                ((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())]++;
            else if (((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())]--;
        }

        private void Button_Click_shot(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 0 || ((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] += 2;
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
            button.Click += ShootButton_Click;
        }

        private void ShootButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class YesNoToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case 3:
                    MessageBox.Show("Trafiony!");
                    return new SolidColorBrush(Colors.Red);
                case 2:
                    return new SolidColorBrush(Colors.Yellow);
                case 1:
                    return new SolidColorBrush(Colors.Black);
                case 0:
                    return new SolidColorBrush(Colors.Transparent);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }

    public class YesNoToBooleanConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case 3:
                    return new SolidColorBrush(Colors.Red);
                case 2:
                    return new SolidColorBrush(Colors.Yellow);
                case 1:
                    return new SolidColorBrush(Colors.Transparent);
                case 0:
                    return new SolidColorBrush(Colors.Transparent);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
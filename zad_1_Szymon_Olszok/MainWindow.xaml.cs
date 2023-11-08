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

namespace zad_1_Szymon_Olszok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double first;
        double second;
        char op;

        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += MainWindow_PreviewKeyDown;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            resultTextBox.Text += btn.Content.ToString();
            second = double.Parse(resultTextBox.Text);
        }

        private void Button_Click_Equals(object sender, RoutedEventArgs e)
        {
            second = double.Parse(resultTextBox.Text);
            double result = 0;

            if (op == '+')
            {
                result = first + second;
            }
            else if (op == '-')
            {
                result = first - second;
            }
            else if (op == '*')
            {
                result = first * second;
            }
            else if (op == '/')
            {
                if (second == 0)
                {
                    MessageBox.Show("Nie dzielimy przez 0!");
                    return;
                }
                result = first / second;
            }
            resultTextBox.Text = result.ToString();
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            resultTextBox.Clear();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            first = double.Parse(resultTextBox.Text);
            op = '+';
            resultTextBox.Clear();
        }

        private void Button_Click_Substract(object sender, RoutedEventArgs e)
        {
            first = double.Parse(resultTextBox.Text);
            op = '-';
            resultTextBox.Clear();
        }

        private void Button_Click_Multiply(object sender, RoutedEventArgs e)
        {
            first = double.Parse(resultTextBox.Text);
            op = '*';
            resultTextBox.Clear();
        }

        private void Button_Click_Divide(object sender, RoutedEventArgs e)
        {
            first = double.Parse(resultTextBox.Text);
            op = '/';
            resultTextBox.Clear();
        }

        private void Button_Click_Comma(object sender, RoutedEventArgs e)
        {
            if (!resultTextBox.Text.Contains(","))
            {
                resultTextBox.Text += ",";
            }
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            double result = 0;
            switch (e.Key)
            {
                case Key.D0:
                case Key.NumPad0:
                    resultTextBox.Text += "0";
                    break;

                case Key.D1:
                case Key.NumPad1:
                    resultTextBox.Text += "1";
                    break;

                case Key.D2:
                case Key.NumPad2:
                    resultTextBox.Text += "2";
                    break;

                case Key.D3:
                case Key.NumPad3:
                    resultTextBox.Text += "3";
                    break;

                case Key.D4:
                case Key.NumPad4:
                    resultTextBox.Text += "4";
                    break;

                case Key.D5:
                case Key.NumPad5:
                    resultTextBox.Text += "5";
                    break;

                case Key.D6:
                case Key.NumPad6:
                    resultTextBox.Text += "6";
                    break;

                case Key.D7:
                case Key.NumPad7:
                    resultTextBox.Text += "7";
                    break;

                case Key.D8:
                case Key.NumPad8:
                    resultTextBox.Text += "8";
                    break;

                case Key.D9:
                case Key.NumPad9:
                    resultTextBox.Text += "9";
                    break;

                case Key.Add:
                case Key.A:
                    first = double.Parse(resultTextBox.Text);
                    op = '+';
                    resultTextBox.Clear();
                    break;

                case Key.Subtract:
                case Key.S:
                    first = double.Parse(resultTextBox.Text);
                    op = '-';
                    resultTextBox.Clear();
                    break;

                case Key.Multiply:
                case Key.M:
                    first = double.Parse(resultTextBox.Text);
                    op = '*';
                    resultTextBox.Clear();
                    break;

                case Key.Divide:
                case Key.D:
                    first = double.Parse(resultTextBox.Text);
                    op = '/';
                    resultTextBox.Clear();
                    break;

                case Key.Clear:
                case Key.C:
                    resultTextBox.Clear();
                    break;

                case Key.OemComma:
                case Key.P:
                    resultTextBox.Text += ",";
                    break;

                case Key.Enter:
                    // Button_Click_Equals(null, null);
                    second = double.Parse(resultTextBox.Text);
                    //int result = 0;

                    if (op == '+')
                    {
                        result = first + second;
                    }
                    else if (op == '-')
                    {
                        result = first - second;
                    }
                    else if (op == '*')
                    {
                        result = first * second;
                    }
                    else if (op == '/')
                    {
                        if (second == 0)
                        {
                            MessageBox.Show("Nie dzielimy przez 0!");
                            return;
                        }
                        result = first / second;
                    }
                    resultTextBox.Text = result.ToString();
                    break;

                case Key.Back:
                    if (resultTextBox.Text.Length > 0)
                    {
                        resultTextBox.Text = resultTextBox.Text.Substring(0, resultTextBox.Text.Length - 1);
                    }
                    break;
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {

            }
        }
    }
}
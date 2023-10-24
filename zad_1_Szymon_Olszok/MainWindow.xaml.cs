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
        private string currentInput = string.Empty;
        private double currentNumber = 0;
        private string currentOperator = string.Empty;
        private bool isNewInput = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string digit = button.Content.ToString();

            if (isNewInput)
            {
                inputTextBox.Text = digit;
                isNewInput = false;
            }
            else
            {
                inputTextBox.Text += digit;
            }

            currentInput = inputTextBox.Text;
        }

        private void comma_Click(object sender, RoutedEventArgs e)
        {
            if (!currentInput.Contains(","))
            {
                inputTextBox.Text += ",";
                currentInput = inputTextBox.Text;
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string newOperator = button.Content.ToString();

            if (!string.IsNullOrEmpty(currentOperator))
            {
                Calculate();
            }

            currentOperator = newOperator;
            currentNumber = double.Parse(currentInput);
            isNewInput = true;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            currentOperator = string.Empty;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            currentInput = string.Empty;
            currentNumber = 0;
            currentOperator = string.Empty;
            inputTextBox.Text = string.Empty;
            isNewInput = true;
        }

        private void Calculate()
        {
            if (!string.IsNullOrEmpty(currentOperator))
            {
                double newNumber = double.Parse(currentInput);
                switch (currentOperator)
                {
                    case "+":
                        currentNumber += newNumber;
                        break;
                    case "-":
                        currentNumber -= newNumber;
                        break;
                    case "*":
                        currentNumber *= newNumber;
                        break;
                    case "/":
                        if (newNumber != 0)
                        {
                            currentNumber /= newNumber;
                        }
                        else
                        {
                            inputTextBox.Text = "Błąd";
                            currentNumber = 0;
                            currentOperator = string.Empty;
                            isNewInput = true;
                            return;
                        }
                        break;
                }

                inputTextBox.Text = currentNumber.ToString();
                isNewInput = true;
            }
        }
    }
}
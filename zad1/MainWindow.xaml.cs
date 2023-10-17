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

namespace zad1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentInput = "";
        private string currentOperator = "";
        private double firstNumber = 0;
        private bool isNewCalculation = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (isNewCalculation)
            {
                inputTextBox.Text = "";
                isNewCalculation = false;
            }

            Button button = (Button)sender;
            currentInput += button.Content.ToString();
            inputTextBox.Text += button.Content.ToString();
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewCalculation)
            {
                if (!string.IsNullOrEmpty(currentInput))
                {
                    firstNumber = double.Parse(currentInput);
                    currentOperator = ((Button)sender).Content.ToString();
                    currentInput = "";
                    inputTextBox.Text += currentOperator;
                }
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput) && !string.IsNullOrEmpty(currentOperator))
            {
                double secondNumber = double.Parse(currentInput);
                double result = 0;

                switch (currentOperator)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                            result = firstNumber / secondNumber;
                        else
                            inputTextBox.Text = "Error";
                        break;
                }

                inputTextBox.Text = result.ToString();
                currentInput = result.ToString();
                isNewCalculation = true;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            currentOperator = "";
            firstNumber = 0;
            inputTextBox.Text = "";
        }
    }
}

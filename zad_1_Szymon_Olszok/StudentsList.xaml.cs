using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;

namespace zad_1_Szymon_Olszok
{
    /// <summary>
    /// Interaction logic for StudentsList.xaml
    /// </summary>
    public partial class StudentsList : Window
    {
        public bool IsOkPressed { get; set; }

        public StudentsList()
        {
            InitializeComponent();
        }

        private void Button_Click_AddStudent(object sender, RoutedEventArgs e)
        {
            IsOkPressed = true;
            this.Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            IsOkPressed = false;
            this.Close();
        }
        private void PeselTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length >= 11)
            {
                e.Handled = true;
            }
        }
    }
}

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

namespace zad2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DodajStudenta_Click(object sender, RoutedEventArgs e)
        {
            string imie = txtImie.Text;
            string nazwisko = txtNazwisko.Text;
            DateTime dataUrodzenia = dpDataUrodzenia.SelectedDate ?? DateTime.Now;
            int semestr = Convert.ToInt32(cmbSemestr.SelectedItem);

            MessageBox.Show("Student został dodany do bazy danych.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

            txtImie.Clear();
            txtNazwisko.Clear();
            dpDataUrodzenia.SelectedDate = null;
            cmbSemestr.SelectedIndex = -1;
        }
    }
}

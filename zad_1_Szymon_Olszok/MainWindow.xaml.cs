using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class MainWindow : Window
    {
        List<Student> listOfStudents = new List<Student>();
        public static List<Student> DeserializedList = new List<Student>();

        private ObservableCollection<Student> _students;

        public MainWindow()
        {
            InitializeComponent();
            listOfStudents.Add(new Student("Jan", "Kowalski", "83838929384", Semester.Semestr5));
            dataGridStudent.ItemsSource = listOfStudents;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            StudentsList okno = new StudentsList();
            Student osoba = new Student();
            okno.DataContext = osoba;
            okno.ShowDialog();
            if (okno.IsOkPressed)
            {
                listOfStudents.Add(osoba);
                dataGridStudent.Items.Refresh();
            }
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (var writer = new StreamWriter("C:/Serializacja/Serializacja.xml"))
            {
                xmlSerializer.Serialize(writer, listOfStudents);
            }
            MessageBox.Show("Lista została zapisana do pliku Serializacja.xml.");
        }

        private void Button_Click_Read(object sender, RoutedEventArgs e)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (var reader = new StreamReader("C:/Serializacja/Serializacja.xml"))
            {
                var deserializedList = xmlSerializer.Deserialize(reader) as List<Student>;
                if (deserializedList != null && deserializedList.Count > 0)
                {
                    DeserializedList = deserializedList;
                }
                dataGridStudent.ItemsSource = deserializedList;
                MessageBox.Show("Lista została odczytana z pliku Serializacja.xml.");
            }
        }
    }
}

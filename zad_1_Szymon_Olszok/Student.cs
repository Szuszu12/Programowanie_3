using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace zad_1_Szymon_Olszok
{
    [XmlRoot(ElementName = "Studenci")]
    public enum Semester
    {
        Semestr1,
        Semestr2,
        Semestr3,
        Semestr4,
        Semestr5,
        Semestr6,
        Semestr7
    }
    public class Student : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string pesel;
        private Semester semestr;

        [XmlAttribute("FirstName")]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value != firstName)
                {
                    firstName = value;
                    NotifyPropertyChanged(nameof(FirstName));
                }
            }
        }

        [XmlAttribute("LastName")]
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value != lastName)
                {
                    lastName = value;
                    NotifyPropertyChanged(nameof(LastName));
                }
            }
        }

        [XmlAttribute("PESEL")]
        public string Pesel
        {
            get { return pesel; }
            set
            {
                if (value != pesel)
                {
                    pesel = value;
                    NotifyPropertyChanged(nameof(Pesel));
                }
            }
        }

        [XmlAttribute("Semestr")]
        public Semester Semestr
        {
            get { return semestr; }
            set
            {
                if (value != semestr)
                {
                    semestr = value;
                    NotifyPropertyChanged(nameof(Semestr));
                }
            }
        }

        public Student()
        {
        }

        public Student(string firstName, string lastName, string pesel, Semester semestr)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Pesel = pesel;
            this.Semestr = semestr;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
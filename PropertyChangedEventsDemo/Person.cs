using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PropertyChangedEventsDemo
{
    internal class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public Person()
        {
            FirstName = "noname";
            LastName = "noname";
        }
        private string firstName;
        private string lastName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName == value) { return; }
                firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }
        public string LastName { 
            get { return lastName; }
            set
            {
                if (lastName == value) { return; }
                lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }
    }
}

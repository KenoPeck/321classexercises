using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChangedEventsDemo
{
    internal class Person
    {
        public Person(string first, string last)
        {
            firstName = first;
            lastName = last;
        }
        private string firstName;
        private string lastName;
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

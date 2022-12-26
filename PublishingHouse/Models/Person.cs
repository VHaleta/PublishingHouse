using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.Models
{
    public class Person
    {
        public const string Id_ = "ID_Person";
        public const string Name_ = "NamePerson";
        public const string Address_ = "AddressPerson";
        public const string Phone_ = "PhonePerson";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Person() { }
    }
}

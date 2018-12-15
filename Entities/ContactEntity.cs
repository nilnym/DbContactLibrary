using DbContactLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace DbContactLibrary.Entities
{
    public class ContactEntity
    {
        public int ID { get; set; }
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Address> Addresses { get; set; }
        public List<ContactInformation> ContactInformation { get; set;  }

        public override string ToString()
        {
            return $"{FirstName} {LastName} \r\n{string.Join("\r\n", Addresses)} \r\n{string.Join("\r\n", ContactInformation)}";
        }
    }
}

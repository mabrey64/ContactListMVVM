using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListMVVM.Classes
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public Contact() { }
        public Contact(string name, string phoneNumber, string email, string description)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Description = description;
        }
    }
}

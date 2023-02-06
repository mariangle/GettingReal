using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandrasBookingSystem.Models
{
    
    public class Freelancer : User
    {

        public string HourlyPrice { get; set; }
        public string Region { get; set; }

        public Freelancer(string firstName, string lastName, string email, string phoneNumber, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SandrasBookingSystem.Models;

namespace SandrasBookingSystem.Models
{
    public class Booking 
    {
        public DateTime Date { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyCVR_nr { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Comment { get; set; }
        public string BookedBy { get; set; }
        public string BookedPhoneNr { get; set; }

            public Booking(DateTime date, string companyName, string companyCVR_nr, string companyPhoneNumber, string city, string street, string bookedBy, string bookedPhoneNr, string comment)
        {
            Date = date;
            CompanyName = companyName;
            CompanyPhoneNumber = companyPhoneNumber;
            CompanyCVR_nr = companyCVR_nr;
            City = city;
            Street = street;
            Comment = comment;
            BookedBy = bookedBy;
            BookedPhoneNr = bookedPhoneNr;
        }

        public override string ToString()
        {
            return $"{Date.ToString("MMMM dd")}, {CompanyName}, {Street}, {City}";

        }
    }
}

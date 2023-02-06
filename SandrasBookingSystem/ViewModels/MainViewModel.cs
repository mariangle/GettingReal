using SandrasBookingSystem.Commands;
using SandrasBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;


namespace SandrasBookingSystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Login & Registrer
        public ICommand LoginCommand { get; } = new LoginCommand();
        public ICommand RegisterCommand { get; } = new RegisterCommand();

        public ObservableCollection<Freelancer> Freelancers { get; set; } = new ObservableCollection<Freelancer>();
        public ObservableCollection<Agency> Agencies { get; set; } = new ObservableCollection<Agency>();

        public Freelancer AuthenticatedUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }


        // Book

        public string BookedBy { get; set; }
        public string BookedPhoneNr { get; set; }

        private Freelancer selectedFreelancer;

        public Freelancer SelectedFreelancer
        {
            get { return selectedFreelancer; }
            set { selectedFreelancer = value; OnPropertyChanged("SelectedFreelancer"); }
        }

        public ICommand BookCommand { get; } = new BookCommand();
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        // Se bookinger
        public ObservableCollection<Booking> Bookings { get; set; } = new ObservableCollection<Booking>();
        public string CompanyName { get; set; }
        public string CompanyCVR_nr { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        private Booking selectedBooking;

        public Booking SelectedBooking
        {
            get { return selectedBooking; }
            set { selectedBooking = value; OnPropertyChanged("SelectedBooking"); }
        }

        public ICommand DeleteBookingCommand { get; } = new DeleteBookingCommand();

        // Se Profil

        public ICommand DeleteAccountCommand { get; } = new DeleteAccountCommand();
        public ICommand SaveEditsCommand { get; } = new SaveEditsCommand();
        public string ConfirmPassword { get; set; } 

    }
}
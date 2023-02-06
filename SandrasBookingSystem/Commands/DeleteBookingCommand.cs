using SandrasBookingSystem.Models;
using SandrasBookingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SandrasBookingSystem.Commands
{
    public class DeleteBookingCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result = true;
            if (parameter is MainViewModel mvm)
            {
                if (mvm.SelectedBooking == null)
                    result = false;
            }
            CommandManager.InvalidateRequerySuggested();
            return result;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                string bookingsPath = "..\\..\\..\\Bookings.txt";
                var document = File.ReadAllLines(bookingsPath);

                foreach (var booking in document)
                {
                    string[] bookingInfo = booking.Split(",");
                    string phoneNr = bookingInfo[3];
                    if (mvm.SelectedBooking.CompanyPhoneNumber == phoneNr)
                    {
                        var oldLines = System.IO.File.ReadAllLines(bookingsPath);
                        var newLines = oldLines.Where(line => !line.Contains(mvm.SelectedBooking.CompanyPhoneNumber));
                        System.IO.File.WriteAllLines(bookingsPath, newLines);
                        mvm.Bookings.Remove(mvm.SelectedBooking);
                        MessageBox.Show("Den valgte booking er blevet slettet.");

                        break;
                    }
                }
            }
        }

    }
}



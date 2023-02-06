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
using static System.Net.WebRequestMethods;

namespace SandrasBookingSystem.Commands
{
    public class BookCommand : ICommand
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
                if (mvm.SelectedFreelancer == null)
                    result = false;
            }
            CommandManager.InvalidateRequerySuggested(); 
            return result;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                {
                    if (string.IsNullOrEmpty(mvm.CompanyName) || string.IsNullOrEmpty(mvm.CompanyCVR_nr)
                                || string.IsNullOrEmpty(mvm.CompanyPhoneNumber) ||
                                string.IsNullOrEmpty(mvm.City) || string.IsNullOrEmpty(mvm.Street))
                    {
                        MessageBox.Show("Alle felter skal udfyldes.");
                    }
                    else
                    {
                        StreamWriter sw = new StreamWriter("..\\..\\..\\Bookings.txt", true);
                        sw.Write($"{mvm.Date},{mvm.CompanyName},{mvm.CompanyCVR_nr},{mvm.CompanyPhoneNumber},{mvm.City},{mvm.Street},{mvm.AuthenticatedUser.FirstName},{mvm.AuthenticatedUser.PhoneNumber},");
                        if (string.IsNullOrEmpty(mvm.Comment))
                        {
                            sw.Write("Ingen kommentar. "); 
                        } else
                        {
                            sw.Write($"{mvm.Comment}");
                        }
                        sw.WriteLine("");
                        sw.Close();
                        mvm.Bookings.Add(new Booking(mvm.Date, mvm.CompanyName,mvm.CompanyCVR_nr, mvm.CompanyPhoneNumber, mvm.City, mvm.Street, mvm.Comment, mvm.AuthenticatedUser.FirstName, mvm.AuthenticatedUser.PhoneNumber));
                        MessageBox.Show("Du har oprettet en booking.");

                    }
                }
            }
        }
    }
}

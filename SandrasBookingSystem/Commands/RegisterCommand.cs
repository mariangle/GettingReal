using SandrasBookingSystem.Models;
using SandrasBookingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace SandrasBookingSystem.Commands
{
    public class RegisterCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result = true;
            return result;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                string freelancersPath = "..\\..\\..\\Freelancers.txt";
                var document = File.ReadAllLines(freelancersPath);

                if (string.IsNullOrEmpty(mvm.FirstName) || string.IsNullOrEmpty(mvm.LastName) || string.IsNullOrEmpty(mvm.Email) || string.IsNullOrEmpty(mvm.Password) || string.IsNullOrEmpty(mvm.PhoneNumber))
                {
                    MessageBox.Show("Alle felter skal udfyldes.");
                }
                else
                {
                    bool detailsExists = false;
                    foreach (var user in document)
                    {
                        string[] userInfo = user.Split(",");
                        string existingPhoneNumber = userInfo[3].Trim();
                        string exisitingEmail = userInfo[2].Trim().ToLower();
                        if (mvm.Email.ToLower() == exisitingEmail || mvm.PhoneNumber == existingPhoneNumber)
                        {
                            detailsExists = true;
                            MessageBox.Show("Telefonnummer eller email eksisterer allerede.");
                            break;
                        }
                    }
                    if (detailsExists == false)
                    {
                        StreamWriter sw = new StreamWriter(freelancersPath, true);
                        sw.Write($"{mvm.FirstName},{mvm.LastName},{mvm.Email},{mvm.PhoneNumber},{mvm.Password}");
                        sw.WriteLine("");
                        sw.Close();
                        MessageBox.Show("Du er blevet registreret.");
                    }
                }
            }
        }
    }
}

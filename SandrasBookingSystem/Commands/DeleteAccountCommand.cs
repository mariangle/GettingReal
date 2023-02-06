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
    public class DeleteAccountCommand : ICommand
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
                if (mvm.AuthenticatedUser == null)
                    result = false;
            }
            CommandManager.InvalidateRequerySuggested();
            return result;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                string freelancersPath = "..\\..\\..\\Freelancers.txt";
                var document = File.ReadAllLines(freelancersPath);

                if (string.IsNullOrEmpty(mvm.ConfirmPassword))
                {
                    MessageBox.Show("Du skal skrive din adgangskode for at bekræfte.");
                }
                else
                {
                    bool passwordIsTrue = false;
                    foreach (var user in document)
                    {
                        string[] userInfo = user.Split(",");
                        string existingPassword = userInfo[4];
                        if (mvm.ConfirmPassword.ToLower() == existingPassword)
                        {
                            var oldLines = System.IO.File.ReadAllLines(freelancersPath);
                            var newLines = oldLines.Where(line => !line.Contains(mvm.ConfirmPassword));
                            System.IO.File.WriteAllLines(freelancersPath, newLines);
                            passwordIsTrue = true;
                            mvm.Freelancers.Remove(mvm.AuthenticatedUser);
                            MessageBox.Show("Din profil er blevet slettet");
                            break;
                        }
                    }
                    if (passwordIsTrue == false)
                    {
                        MessageBox.Show("Forkert adgangskode.");
                    }
                }
            }
        }
    }
}
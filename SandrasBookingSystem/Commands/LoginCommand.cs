using SandrasBookingSystem.Models;
using SandrasBookingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace SandrasBookingSystem.Commands
{
    public class LoginCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            bool result = true;
            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                string freelancersPath = "..\\..\\..\\Freelancers.txt";

                if (string.IsNullOrEmpty(mvm.LoginEmail) || string.IsNullOrEmpty(mvm.LoginPassword))
                {
                    MessageBox.Show("Alle felter skal udfyldes.");

                }
                else
                {
                    bool isLoggedIn = false;

                    StreamReader sr = new StreamReader(freelancersPath);
                    string newDocument = sr.ReadToEnd(); // læser dokumentet
                    sr.Close(); // Lukker dokumentet igen

                    var document = File.ReadAllLines(freelancersPath);
                    foreach (var usr in document)
                    {
                        string[] userInfo = usr.Split(",");
                        string storedPassword = userInfo[4].Trim();
                        string storedEmail = userInfo[2].Trim().ToLower();
                        if (mvm.LoginEmail.ToLower() == storedEmail && mvm.LoginPassword == storedPassword)
                        {
                            isLoggedIn = true;
                            break;
                        }
                    }
                    if (isLoggedIn)
                    {
                        MessageBox.Show("Du er logget ind.");

                        string line;

                        System.IO.StreamReader file =
                            new System.IO.StreamReader(freelancersPath);
                        while ((line = file.ReadLine()) != null)
                        {
                            string[] word = line.Split(',');
                            Freelancer freelancer = new Freelancer(word[0], word[1], word[2], word[3], word[4]);
                            mvm.Freelancers.Add(freelancer);
                            mvm.AuthenticatedUser = freelancer;
                        }
                        file.Close();
                        string line1;

                        System.IO.StreamReader file1 =
                            new System.IO.StreamReader("..\\..\\..\\Bookings.txt");
                        while ((line1 = file1.ReadLine()) != null)
                        {
                            string[] word = line1.Split(',');
                            mvm.Bookings.Add(new Booking(DateTime.Parse(word[0]), word[1], word[2], word[3], word[4], word[5], word[6], word[7], word[8]));
                        }
                        file1.Close();
                    }
                    else
                    {
                        MessageBox.Show("Forkert email eller adgangskode.");
                    }
                }
            }

        }
    }
}
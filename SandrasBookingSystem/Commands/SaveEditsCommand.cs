using SandrasBookingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace SandrasBookingSystem.Commands
{
    public class SaveEditsCommand : ICommand
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

            }
        }
    }
}
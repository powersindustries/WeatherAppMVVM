using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public SearchCommand(WeatherViewModel viewModel)
        {
            ViewModel = viewModel;
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public event EventHandler CanExecuteChanged
        {
            add    { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(parameter as string);
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public void Execute(object parameter)
        {
            ViewModel.MakeQuery();
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public WeatherViewModel ViewModel { get; set; }


    }
}

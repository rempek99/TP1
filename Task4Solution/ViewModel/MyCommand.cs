using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class MyCommand : ICommand
    {
        private Action m_action;

        public MyCommand(Action action) 
        {
            this.m_action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.m_action();
        }

        
    }
}

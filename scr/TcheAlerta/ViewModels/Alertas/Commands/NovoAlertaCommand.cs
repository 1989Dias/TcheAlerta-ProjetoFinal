using System;

namespace TcheAlerta.ViewModels.Alertas.Commands
{
    public class NovoAlertaCommand
    {
        private AlertaViewModel viewModelAlerta;

        public NovoAlertaCommand(AlertaViewModel viewModelAlerta) {
            this.viewModelAlerta = viewModelAlerta;
        }

        //public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            viewModelAlerta.AbrirPaginaNovoAlerta();
        }
    }
}

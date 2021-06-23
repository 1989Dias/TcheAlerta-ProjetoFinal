using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TcheAlerta.ViewModels
{
    public interface IPaginaServico
    {
        Task PushAsync(Page page);
        Task PushModalAsync(Page page);
        Task PopModalAsync();
        Task<bool> DisplayAlertAsync(string title, string message, string ok, string cancel);
        Task DisplayAlertAsync(string title, string message, string cancel);
        Task DisplayAlert(string title, string message, string cancel);
    }
}

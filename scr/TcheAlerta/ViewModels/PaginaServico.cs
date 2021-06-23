using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TcheAlerta.ViewModels
{
    public class PaginaServico : IPaginaServico
    {
        public Task DisplayAlert(string title, string message, string cancel) {
            return App.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlertAsync(string title, string message, string ok, string cancel) {
            return await App.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task DisplayAlertAsync(string title, string message, string cancel) {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel); 
        }

        public async Task PopModalAsync() {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page) {
            await App.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PushModalAsync(Page page) {
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }      

    }
}

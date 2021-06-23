using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TcheAlerta.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged  
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null) {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return;

            storage = value;
            OnPropertyChanged(propertyName);
        }           

        //Método de navegação entre páginas.
        public async Task PushAsync(Page page) {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}

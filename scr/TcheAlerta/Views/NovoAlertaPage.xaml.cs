using TcheAlerta.ViewModels.Alertas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TcheAlerta.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoAlertaPage : ContentPage {
       
        public NovoAlertaPage() {          
            BindingContext = new AlertaViewModel();
           
            InitializeComponent();            
        }
    }
}
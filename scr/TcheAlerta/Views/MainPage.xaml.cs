using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcheAlerta.Models;
using TcheAlerta.ViewModels;
using TcheAlerta.ViewModels.Alertas;
using TcheAlerta.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TcheAlerta
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {       
        AlertaViewModel viewModel;
        public MainPage() {
            InitializeComponent();

            viewModel = new AlertaViewModel();
            BindingContext = viewModel;
        }
       
        private void mnuItem1_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new NovoAlertaPage());
        }             

        protected override void OnAppearing() {
            base.OnAppearing();
            viewModel.CarregarAlertas();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                var alerta = e.SelectedItem as Alerta;
                              
                Navigation.PushAsync(new AlertaRecebidoPage(alerta.Id.ToString()));                
            }
        } 
    }
}

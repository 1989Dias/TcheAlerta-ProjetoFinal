using System;
using TcheAlerta.ViewModels;
using TcheAlerta.ViewModels.Alertas;
using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;
using Xamarin.Forms.Xaml;

namespace TcheAlerta.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertaRecebidoPage : ContentPage
    {
        const string AlertaNaoSelecionado = "Não há alerta selecionado!";

        private readonly IPaginaServico _paginaServico;

        public string Observacao { get; set; }

        public AlertaRecebidoPage() {
            _paginaServico = new PaginaServico();
            InitializeComponent();
        }

        public AlertaRecebidoPage(string IdAlerta) {
            InitializeComponent();
            BindingContext = new AlertaViewModel(IdAlerta);
        }

        private void calendar_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new MainPage());
        }

        private void shared_Clicked(object sender, EventArgs e) {
            var AlertaRecebido = BindingContext as AlertaViewModel;

            try {
                if (!string.IsNullOrEmpty(AlertaRecebido.Titulo)) {
                    var Titulo = AlertaRecebido.Titulo;
                    var Observacao = AlertaRecebido.Observacao;

                    string Mensagem = $"{Titulo}{System.Environment.NewLine}{Observacao}";

                    Chat.Open("", Mensagem);
                } else {
                    _paginaServico.DisplayAlert("Erro", AlertaNaoSelecionado , "OK");
                }
            } catch (Exception ex) {
                _paginaServico.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void delete_Clicked(object sender, EventArgs e) {
            try {
                var AlertaRecebido = BindingContext as AlertaViewModel;
                              
                if (AlertaRecebido.Id > 0) {
                    AlertaRecebido.ExcluirAlerta(AlertaRecebido.Id);
                } else {
                    _paginaServico.DisplayAlert("Erro", AlertaNaoSelecionado, "OK");
                }
              
            } catch (Exception ex) {
                _paginaServico.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
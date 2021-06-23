using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TcheAlerta.Data.Repositories;
using TcheAlerta.Models;
using TcheAlerta.Services;
using TcheAlerta.ViewModels.Alertas.Commands;
using TcheAlerta.Views;
using Xamarin.Forms;

namespace TcheAlerta.ViewModels.Alertas
{
    public class AlertaViewModel : BaseViewModel
    {
        INotificationManager notificationManager;

        private readonly AlertaRepository _alertaRepository;

        public NovoAlertaPage NovoAlertaPage { get; set; }
        public ObservableCollection<Alerta> Alertas { get; set; }
        public NovoAlertaCommand NovoAlertaCommand { get; set; }

        public ICommand SalvarAlertaCommand { get; private set; }
        public ICommand RecuperarAlertaCommand { get; private set; }

        private readonly IPaginaServico _paginaServico;

        public AlertaViewModel() {
            this.Data = DateTime.Today;
            this.Hora = DateTime.Now.TimeOfDay;

            NovoAlertaCommand = new NovoAlertaCommand(this);
            SalvarAlertaCommand = new Command(async () => await ExecuteSalvarAlertaCommand());

            _paginaServico = new PaginaServico();
            _alertaRepository = new AlertaRepository();

            Alertas = new ObservableCollection<Alerta>(GetAlertas());
            GetAlertas();
            notificationManager = DependencyService.Get<INotificationManager>();
        }

        public AlertaViewModel(NovoAlertaPage _novoAlertaPage) {
            NovoAlertaPage = _novoAlertaPage;
        }

        public AlertaViewModel(string Id) {
            _paginaServico = new PaginaServico();

            if (string.IsNullOrEmpty(Id)) {
                _paginaServico.PushAsync(new MainPage());
            } else {
                var iId = Convert.ToInt16(Id);

                _alertaRepository = new AlertaRepository();
                ExecuteRecuperarAlertaCommand(iId);
            }
        }

        public int Id { get; set; }

        private string _titulo;
        public string Titulo {
            get { return _titulo; }
            set {
                SetProperty(ref _titulo, value);
                OnPropertyChanged(nameof(Titulo));
            }
        }

        private string _observacao;
        public string Observacao {
            get { return _observacao; }
            set {
                SetProperty(ref _observacao, value);
                OnPropertyChanged(nameof(_observacao));
            }
        }

        private DateTime _data;
        public DateTime Data {
            get { return _data; }
            set {
                SetProperty(ref _data, value);
                OnPropertyChanged(nameof(_data));
            }
        }

        private TimeSpan _hora;
        public TimeSpan Hora {
            get { return _hora; }
            set {
                SetProperty(ref _hora, value);
                OnPropertyChanged(nameof(_hora));
            }
        }

        public Alerta NovoAlerta() {
            Alerta alerta = new Alerta() {
                Titulo = Titulo,
                Observacao = Observacao,
                Data = Data,
                Hora = Hora
            };

            return alerta;
        }

        public async void AbrirPaginaNovoAlerta() {
            await _paginaServico.PushAsync(new NovoAlertaPage());
        }

        private async Task ExecuteSalvarAlertaCommand() {
            try {
                Salvar();
                await _paginaServico.DisplayAlertAsync("", "Alerta adicionado com sucesso!", "Ok");
            } catch (Exception Erro) {
                await _paginaServico.DisplayAlertAsync("Adicionar alerta", "Erro ao adicionar alerta" + Erro, "Ok");
            }
        }

        private async Task ExecuteRecuperarAlertaCommand(int Id) {
            try {
                Alerta alerta = new Alerta();
                alerta = _alertaRepository.GetAsync(Id);

                this.Id = alerta.Id;
                this.Titulo = alerta.Titulo;
                this.Observacao = alerta.Observacao;
            } catch (Exception Erro) {
                await _paginaServico.DisplayAlertAsync("Recuperar alerta", "Erro ao recuperar alerta" + Erro, "Ok");
            }
        }

        public void ExcluirAlerta(int Id) {
            try {
                Alerta alerta = new Alerta();
                alerta = _alertaRepository.GetAsync(Id);

                _alertaRepository.DeleteAsync(alerta);
                _paginaServico.DisplayAlert("Exclusão de alerta", $"Alerta {alerta.Titulo} excluído!", "Ok");
                _paginaServico.PushAsync(new MainPage());
            } catch (Exception Erro) {
                _paginaServico.DisplayAlert("Exclusão de alerta", "Erro ao excluir alerta" + Erro, "Ok");
            }
        }

        private List<Alerta> GetAlertas() {
            return _alertaRepository.GetListAsync();
        }

        public void CarregarAlertas() {
            GetAlertas();
        }

        private Alerta GetAlerta() {
            foreach (Alerta alerta in GetAlertas()) {
                if (alerta.Titulo == this.Titulo && alerta.Data == this.Data && alerta.Hora == this.Hora) {
                    return alerta;
                }
            }

            return null;
        }

        private void Salvar() {
            try {
                Alerta alerta = new Alerta();

                alerta = NovoAlerta();
                _alertaRepository.AddAsync(alerta);

                alerta = GetAlerta();
                if (alerta != null) {
                    Util util = new Util();

                    var TotalSegundos = util.GetSegundos(DateTime.Today, DateTime.Now.TimeOfDay, alerta.Data, alerta.Hora);
                    notificationManager.SendNotification(alerta.Titulo, alerta.Observacao, alerta.Id.ToString(), DateTime.Now.AddSeconds(TotalSegundos));
                    //CrossLocalNotifications.Current.Show(alerta.Titulo, alerta.Observacao, alerta.Id, DateTime.Now.AddSeconds(TotalSegundos));
                    _paginaServico.PushAsync(new MainPage());
                } else {
                    _paginaServico.DisplayAlertAsync("Adicionar alerta", "Alerta não encontrado", "Ok");
                }
            } catch (Exception Erro) {
                _paginaServico.DisplayAlertAsync("Adicionar alerta", "Erro ao adicionar alerta" + Erro, "Ok");
            }
        }
    }
}

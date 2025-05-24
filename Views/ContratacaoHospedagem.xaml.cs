using System;
using System.Collections.ObjectModel;
using MauiAppHotel.Models;

namespace MauiAppHotel.Views
{
    public partial class ContratacaoHospedagem : ContentPage
    {
        private ObservableCollection<QuartoModel> quartos;

        public ContratacaoHospedagem()
        {
            InitializeComponent();

            // Inicializa a lista de quartos
            quartos = new ObservableCollection<QuartoModel>
            {
                new QuartoModel { Descricao = "Suíte Luxo", Preco = 350 },
                new QuartoModel { Descricao = "Suíte Premium", Preco = 500 }
            };

            // Define a fonte de dados do Picker
            pck_quarto.ItemsSource = quartos;
            pck_quarto.ItemDisplayBinding = new Binding("Descricao"); // Exibe a descrição no Picker
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (pck_quarto.SelectedItem is QuartoModel quartoSelecionado)
            {
                int adultos = (int)stp_adultos.Value;
                int criancas = (int)stp_criancas.Value;
                DateTime checkin = dtpck_checkin.Date;
                DateTime checkout = dtpck_checkout.Date;

                if (checkout <= checkin)
                {
                    await DisplayAlert("Erro", "Check-out deve ser após o Check-in.", "OK");
                    return;
                }

                await Navigation.PushAsync(new ResumoReserva(quartoSelecionado, adultos, criancas, checkin, checkout));
            }
            else
            {
                await DisplayAlert("Erro", "Selecione uma acomodação.", "OK");
            }
        }
    }
}

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

         
            quartos = new ObservableCollection<QuartoModel>
                    {
                        new QuartoModel { Descricao = "Suíte Luxo", Preco = 350 },
                        new QuartoModel { Descricao = "Suíte Premium", Preco = 500 }
                    };

           
            if (pck_quarto != null)
            {
                pck_quarto.ItemsSource = quartos;
                pck_quarto.ItemDisplayBinding = new Binding("Descricao"); // Exibe a descrição no Picker
            }
        }

      

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (pck_quarto?.SelectedItem is QuartoModel quartoSelecionado)
            {
                int adultos = (int)(stp_adultos?.Value ?? 0);
                int criancas = (int)(stp_criancas?.Value ?? 0);
                DateTime checkin = dtpck_checkin?.Date ?? DateTime.MinValue;
                DateTime checkout = dtpck_checkout?.Date ?? DateTime.MinValue;

                if (checkout <= checkin)
                {
                    await DisplayAlert("Erro", "Check-out deve ser após o Check-in.", "OK");
                    return;
                }
                else
                {
                    await Navigation.PushAsync(new ResumoReserva(quartoSelecionado, adultos, criancas, checkin, checkout));
                }
            }
            else
            {
                await DisplayAlert("Erro", "Selecione uma acomodação.", "OK");
            }
        }
    }
}

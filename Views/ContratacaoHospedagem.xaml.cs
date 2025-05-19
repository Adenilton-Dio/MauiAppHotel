using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel.Views
{
    public partial class ContratacaoHospedagem : ContentPage
    {
        public ContratacaoHospedagem()
        {
            InitializeComponent();
        }

        private void OnSobreClicked(object sender, EventArgs e)
        {
            DisplayAlert("Sobre", "Desenvolvedor: Adenilton Gomes " +
                "atonper@hotmail.com", "OK");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // Exemplo: ação ao clicar no botão
            DisplayAlert("Confirmação", "Hospedagem contratada com sucesso!", "OK");
        }
    }
}

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
            try
            {
                Navigation.PushAsync(new HospedagemContratada());


            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}





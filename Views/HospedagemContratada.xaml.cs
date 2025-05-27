using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel.Views
{
    public partial class HospedagemContratada : ContentPage
    {
        public HospedagemContratada()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(); // volta para a página anterior
        }
    }
}

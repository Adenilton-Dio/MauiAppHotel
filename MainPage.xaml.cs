using MauiAppHotel.Models;
using MauiAppHotel.Views;

namespace MauiAppHotel;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void IrParaPagamento_Clicked(object sender, EventArgs e)
    {
        // Criar um exemplo de quarto
        var quartoExemplo = new QuartoModel
        {
            Descricao = "Suíte Luxo com vista para o mar",
            Preco = (int)450.00
        };

        // Dados para exemplo
        int adultos = 2;
        int criancas = 1;
        DateTime checkin = DateTime.Today.AddDays(1);
        DateTime checkout = DateTime.Today.AddDays(5);

        // Navegar para a página Pagamento
        await Navigation.PushAsync(new Pagamento(quartoExemplo, adultos, criancas, checkin, checkout));
    }
}

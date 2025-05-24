using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class Pagamento : ContentPage
{
    private readonly Quarto _quarto;
    private readonly int _adultos;
    private readonly int _criancas;
    private readonly DateTime _checkin;
    private readonly DateTime _checkout;
    private QuartoModel quartoExemplo;

    public Pagamento(Quarto quarto, int adultos, int criancas, DateTime checkin, DateTime checkout)
    {
        InitializeComponent();

        _quarto = quarto;
        _adultos = adultos;
        _criancas = criancas;
        _checkin = checkin;
        _checkout = checkout;

        BindingContext = this;

        lblDescricao.Text = _quarto.Descricao;

        // Calcula valor total baseado em dias e quantidade de pessoas
        int dias = (_checkout - _checkin).Days;
        if (dias <= 0) dias = 1;

        double total = dias * (_adultos * _quarto.ValorDiariaAdulto + _criancas * _quarto.ValorDiariaCrianca);

        lblAdultos.Text = _adultos.ToString();
        lblCriancas.Text = _criancas.ToString();
        lblCheckin.Text = _checkin.ToString("dd/MM/yyyy");
        lblCheckout.Text = _checkout.ToString("dd/MM/yyyy");
        lblTotal.Text = total.ToString("C");
    }

    public Pagamento(QuartoModel quartoExemplo, int adultos, int criancas, DateTime checkin, DateTime checkout)
    {
        this.quartoExemplo = quartoExemplo;
        _adultos = adultos;
        _criancas = criancas;
        _checkin = checkin;
        _checkout = checkout;
    }

    private async void Confirmar_Clicked(object sender, EventArgs e)
    {
        if (pck_pagamento.SelectedIndex == -1)
        {
            await DisplayAlert("Erro", "Selecione uma forma de pagamento.", "OK");
            return;
        }

        await Navigation.PushAsync(new Confirmacao());
    }
}

using System;
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ResumoReserva : ContentPage
{
    private readonly QuartoModel _quarto;
    private readonly int _adultos;
    private readonly int _criancas;
    private readonly DateTime _checkin;
    private readonly DateTime _checkout;

    public ResumoReserva(QuartoModel quarto, int adultos, int criancas, DateTime checkin, DateTime checkout)
    {
        InitializeComponent();

        _quarto = quarto;
        _adultos = adultos;
        _criancas = criancas;
        _checkin = checkin;
        _checkout = checkout;

        lblQuarto.Text = $"Quarto: {_quarto.Descricao}";
        lblPreco.Text = $"Preço da diária: R$ {_quarto.Preco:F2}";
        lblAdultos.Text = $"Adultos: {_adultos}";
        lblCriancas.Text = $"Crianças: {_criancas}";
        lblCheckin.Text = $"Check-in: {_checkin:dd/MM/yyyy}";
        lblCheckout.Text = $"Check-out: {_checkout:dd/MM/yyyy}";
    }
}

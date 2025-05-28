using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        // Atribuição do App atual para acessar dados globais
        PropriedadesApp = (App)Application.Current;

        // Verifica se a lista está preenchida antes de atribuir
        if (PropriedadesApp.lista_quartos != null && PropriedadesApp.lista_quartos.Any())
        {
            pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;
        }

        // Define limites das datas
        dtpck_checkin.MinimumDate = DateTime.Today;
        dtpck_checkin.MaximumDate = DateTime.Today.AddMonths(1);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Verifica se uma acomodação foi selecionada
            if (pck_quarto.SelectedItem is not Quarto quartoSelecionado)
            {
                await DisplayAlert("Aviso", "Selecione uma acomodação válida.", "OK");
                return;
            }

            if (dtpck_checkout.Date <= dtpck_checkin.Date)
            {
                await DisplayAlert("Erro", "Check-out deve ser depois do check-in.", "OK");
                return;
            }

            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = quartoSelecionado,
                QuantidadeAdultos = (int)stp_adultos.Value,
                QuantidadeCriancas = (int)stp_criancas.Value,
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date,
            };

            await Navigation.PushAsync(new HospedagemContratada
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        // Atualiza as datas do check-out quando o check-in é modificado
        var novaDataCheckin = e.NewDate;

        dtpck_checkout.MinimumDate = novaDataCheckin.AddDays(1);
        dtpck_checkout.MaximumDate = novaDataCheckin.AddMonths(6);

        // Corrige o valor de check-out se estiver fora do novo intervalo
        if (dtpck_checkout.Date <= novaDataCheckin)
        {
            dtpck_checkout.Date = novaDataCheckin.AddDays(1);
        }
    }
}

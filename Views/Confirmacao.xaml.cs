namespace MauiAppHotel.Views
{
    public partial class Confirmacao : ContentPage
    {
        public Confirmacao()
        {
            InitializeComponent();
        }

        private async void VoltarInicio_Clicked(object sender, EventArgs e)
        {
            // Volta para a primeira página da pilha de navegação
            await Navigation.PopToRootAsync();
        }
    }
}

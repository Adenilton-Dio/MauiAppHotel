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
            // Volta para a primeira p�gina da pilha de navega��o
            await Navigation.PopToRootAsync();
        }
    }
}

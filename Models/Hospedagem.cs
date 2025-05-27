namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }

        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }

        public DateTime DataCheckIn { get; set; }

        public DateTime DataCheckOut { get; set; }

        public int Estadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }

        public double ValorTotal
        {
            get
            {
                double valor_adultos = QuantidadeAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_Criancas = QuantidadeCriancas * QuartoSelecionado.ValorDiariaCrianca;

                double total = (valor_adultos + valor_Criancas) * Estadia;
                return total;
            }
        }
    }
 }


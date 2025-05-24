namespace MauiAppHotel.Models
{
    public class QuartoModel
    {
        public string Descricao { get; set; }
        public double ValorDiariaAdulto { get; set; }
        public double ValorDiariaCrianca { get; set; }
        public int Preco { get; internal set; }
    }
}

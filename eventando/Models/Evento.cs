namespace eventando.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public double Preco { get; set; }

        public ICollection<Participante> Participantes { get; set; }
    }
}

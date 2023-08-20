namespace eventando.Models
{
    public class Participante
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public Evento EventoInfo { get; set; }
    }
}

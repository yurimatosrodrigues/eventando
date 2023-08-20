using eventando.Models;
using Microsoft.EntityFrameworkCore;

namespace eventando.Dados
{
    public class EventosContext : DbContext
    {
        public EventosContext(DbContextOptions<EventosContext> opcoes)
            : base(opcoes){ }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Evento>().ToTable("TBEventos");
            modelBuilder.Entity<Participante>().ToTable("TBParticipantes");
        }
    }
}

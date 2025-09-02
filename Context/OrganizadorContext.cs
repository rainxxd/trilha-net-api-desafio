using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
        }

        // Representa a tabela Tarefas no banco
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade Tarefa
            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.ToTable("Tarefas"); // Nome da tabela

                entity.HasKey(t => t.Id); // Chave primária

                entity.Property(t => t.Titulo)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(t => t.Descricao)
                      .HasMaxLength(500);

                entity.Property(t => t.Data)
                      .IsRequired();

                entity.Property(t => t.Status)
                      .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

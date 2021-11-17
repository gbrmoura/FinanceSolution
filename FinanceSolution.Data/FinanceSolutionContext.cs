using Microsoft.EntityFrameworkCore;
using FinanceSolution.Data.Models;

namespace FinanceSolution.Data
{
    public class FinanceSolutionContext : DbContext
    {
        public FinanceSolutionContext(DbContextOptions<FinanceSolutionContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<UsuarioModel>()
                .Property(p => p.Status)
                .HasDefaultValue(1);
            
            modelBuilder.Entity<LancamentoModel>()
                .Property(p => p.Status)
                .HasDefaultValue(1);

            modelBuilder.Entity<LancamentoTipoModel>()
                .Property(p => p.Status)
                .HasDefaultValue(1);
            
            modelBuilder.Entity<LancamentoArquivoModel>()
                .Property(p => p.Status)
                .HasDefaultValue(1);
            
            modelBuilder.Entity<MetodoPagamentoModel>()
                .Property(p => p.Status)
                .HasDefaultValue(1);
        }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<LancamentoModel> Lancamento { get; set; }
        public DbSet<LancamentoArquivoModel> LancamentoArquivo { get; set; }
        public DbSet<LancamentoTipoModel> LancamentoTipo { get; set; }
        public DbSet<MetodoPagamentoModel> MetodoPagamento { get; set; }
    }
}

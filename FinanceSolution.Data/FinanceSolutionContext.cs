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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<PaymentMethodModel> PaymentMethod { get; set; }
        public DbSet<AccountAccrualsModel> AccountAccruals { get; set; }
        public DbSet<AccountFileModel> AccountFile { get; set; }
        public DbSet<AccountEntryModel> AccountEntry { get; set; }
    }
}

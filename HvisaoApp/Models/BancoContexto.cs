using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HvisaoApp.Models
{
    public class BancoContexto : DbContext
    {
        public BancoContexto() : base("Lentes")
        {   
        }

        public DbSet<Lentes> Lentes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                 .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(255));

            modelBuilder.Entity<Lentes>()
                .HasKey(p => p.SolicitacaoId);
        }
    }
}
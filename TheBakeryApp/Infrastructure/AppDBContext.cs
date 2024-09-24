using Microsoft.EntityFrameworkCore;
using TheBakeryApp.Model;

namespace TheBakeryApp.Infrastructure
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VendaProduto>()
                .HasKey(vp => new { vp.VendaId, vp.ProdutoId });

            modelBuilder.Entity<VendaProduto>()
                .HasOne(vp => vp.Venda)
                .WithMany(v => v.VendasProduto)
                .HasForeignKey(vp => vp.VendaId);

            modelBuilder.Entity<VendaProduto>()
                .HasOne(vp => vp.Produto)
                .WithMany(p => p.VendasProduto)

                .HasForeignKey(vp => vp.ProdutoId);
        }
        public DbSet<TheBakeryApp.Model.CupomFiscal> CupomFiscal { get; set; } = default!;
    }
}

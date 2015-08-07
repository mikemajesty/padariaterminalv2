using Model.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Model.Data
{
    public class _DbContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<VendaComComandaAtiva> VendaComComandaAtiva { get; set; }
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<TipoCadastro> TipoCadastro { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {           
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Usuarios>().ToTable("Usuarios");
            modelBuilder.Entity<Comanda>().ToTable("Comanda");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<TipoCadastro>().ToTable("TipoCadastro");
            //modelBuilder.Entity<Cliente>().ToTable("Cliente");
            //modelBuilder.Entity<TipoPagamento>().ToTable("TipoPagamento");
            modelBuilder.Entity<VendaComComandaAtiva>().ToTable("VendaComComandaAtiva");
            //modelBuilder.Entity<Venda>().ToTable("Venda");
            //modelBuilder.Entity<Caixa>().ToTable("Caixa");
            //modelBuilder.Entity<Fiado>().ToTable("Fiado"); 
            //modelBuilder.Entity<MovimentacaoCaixa>().ToTable("MovimentacaoCaixa");
            //modelBuilder.Entity<MovimentacaoProduto>().ToTable("MovimentacaoProduto");
           
        }
    }
}

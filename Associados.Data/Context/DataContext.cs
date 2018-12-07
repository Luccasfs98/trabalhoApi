using Associados.Domain.AssociadoRoot;
using Associados.Domain.DependenteRoot;
using Associados.Domain.UsuarioRoot;
using Microsoft.EntityFrameworkCore;

namespace Associados.Data.Context 
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
        : base(options)
        { }

        public DbSet<Associado> Associado { get; set; }

        public DbSet<Dependente> Dependente { get; set; } 

        public DbSet<Usuario> Usuario { get; set;}
    }

}
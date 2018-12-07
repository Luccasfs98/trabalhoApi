using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associados.Data.Context;
using Associados.Domain;
using Associados.Domain.Interfaces;
using Associados.Domain.UsuarioRoot;
using Microsoft.EntityFrameworkCore;

namespace Associados.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
    private DataContext context;

        public UsuarioRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task Add(Usuario obj)
        {
            await context.AddAsync(obj);
            await context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            context.Remove(GetById(id));
            await context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await context.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetById(long id)
        {
            return await context.Usuario.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Usuario obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task <Usuario> AuthUser(Usuario user)
        {
            return await context
                .Usuario
                .SingleOrDefaultAsync(i => i.Login == user.Login &&
                                        i.Password == user.Password);
        }
    }

}
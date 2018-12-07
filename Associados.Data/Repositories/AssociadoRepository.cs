using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associados.Data.Context;
using Associados.Domain.AssociadoRoot;
using Associados.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Associados.Data.Repositories
{
    public class AssociadoRepository : IAssociadoRepository
    {

        private DataContext context;

        public AssociadoRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task Add(Associado obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
             context.Remove(GetById(id));
             await context.SaveChangesAsync();

        }

        public async Task<List<Associado>> GetAll()
        {
            return await context.Associado.Include(i => i.Dependentes).ToListAsync();
        }

        public async Task<Associado> GetById(long id)
        {
            return await context.Associado.Include(e => e.Dependentes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Associado obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }

}
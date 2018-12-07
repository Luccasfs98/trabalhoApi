using System.Collections.Generic;
using System.Threading.Tasks;
using Associados.Data.Context;
using Associados.Domain.DependenteRoot;
using Associados.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Associados.Data.Repositories
{
    public class DependenteRepository : IDependenteRepository
    {
        private DataContext context;

        public DependenteRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task Add(Dependente obj)
        {
            await context.Dependente.AddAsync(obj);
            await context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            context.Remove(GetById(id));
            await context.SaveChangesAsync();        
        }

        public async Task<List<Dependente>> GetAll()
        {
            return await context.Dependente.ToListAsync();
        }

        public async Task<Dependente> GetById(long id)
        {
            return await context.Dependente.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Dependente obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }

}
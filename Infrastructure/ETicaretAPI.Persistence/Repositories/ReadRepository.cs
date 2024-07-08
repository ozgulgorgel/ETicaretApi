using ETicaretApi.Application.Repositories;
using ETicaretApi.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDBContext _context;
        public ReadRepository(ETicaretAPIDBContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            var query = Table.AsQueryable();
           
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            var query = Table.Where(method);
           
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            var query = Table.AsQueryable();
           
            return await query.FirstOrDefaultAsync(method);
        }
        public async Task<T> GetByIdAsync(string id)
        {
            var s = await Table.FindAsync(Guid.Parse(id));
            return s;
        }
      //=>    await Table.FindAsync(id);
          //return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        

     
    }

}

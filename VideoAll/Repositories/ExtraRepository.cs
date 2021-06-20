using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VideoAll.Interfaces;

namespace VideoAll.Repositories
{
    public class ExtraRepository<TDbContext>  where TDbContext : DbContext
    {
        protected TDbContext dbContext;

        public ExtraRepository(TDbContext context)
        {
            dbContext = context;
        }
        public async Task<IEnumerable<TDbContext>> GetWhere(Expression<Func<TDbContext, bool>> predicate)
        {
            return await dbContext.Set<TDbContext>().Where(predicate).ToListAsync();
        }
      
    }
}

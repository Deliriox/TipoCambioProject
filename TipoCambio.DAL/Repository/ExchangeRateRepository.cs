using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TipoCambio.DAL.IRepository;
using TipoCambio.Entities;

namespace TipoCambio.DAL.Repository
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        protected DbContext Context;
        protected DbSet<ExchangeRate> Set;

        public ExchangeRateRepository(ExchangeContext context)
        {
            Context = context;
            Set = Context.Set<ExchangeRate>();
        }

        
        //Get all ExchangeRate
        public virtual async Task<IEnumerable<ExchangeRate>> GetAll()
        {
            var result = await Set.AsNoTracking().ToListAsync();

            if (result.Count == 0)
                return null;

            return result;
        }

        // Get ExchangeRate by a param.
        public virtual async Task<ExchangeRate> GetBy(params object[] p)
        {
            return await Set.FindAsync(p);
        }

        // Create/Insert values into ExchangeRate table.
        public virtual async Task<IEnumerable<ExchangeRate>> Create(IList<ExchangeRate> exchangeRates)
        {
            List<ExchangeRate> parse = exchangeRates.ToList();
            foreach(var entity in exchangeRates)
            {
                Set.Add(entity);
            }
            await Context.SaveChangesAsync();
            return parse.AsEnumerable();
        }
    }
}

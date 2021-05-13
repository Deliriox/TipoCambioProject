using System.Collections.Generic;
using System.Threading.Tasks;
using TipoCambio.Entities;

namespace TipoCambio.DAL.IRepository
{
    public interface IExchangeRateRepository
    {
        Task<IEnumerable<ExchangeRate>> GetAll();
        Task<ExchangeRate> GetBy(params object[] p);
        Task<IEnumerable<ExchangeRate>> Create(IList<ExchangeRate> exchangeRates);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TipoCambio.Models;

namespace TipoCambio.BL.Manager
{
    public interface IExchangeRateManager
    {
        Task<IEnumerable<ExchangeRateModel>> GetAllExchangeRate();
        Task<ExchangeRateModel> GetExchangeRateById(int id);
        Task<IEnumerable<ExchangeRateModel>> CreateExchangeRate(IList<ExchangeRateModel> exchangeRateModels);
    }
}

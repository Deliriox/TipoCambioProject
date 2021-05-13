using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TipoCambio.DAL.IRepository;
using TipoCambio.Entities;
using TipoCambio.Models;

namespace TipoCambio.BL.Manager
{
    public class ExchangeRateManager : IExchangeRateManager
    {
        private readonly IMapper _mapper;
        private readonly IExchangeRateRepository _exchangeRateRepository;        

        public ExchangeRateManager(IMapper mapper, IExchangeRateRepository exchangeRateRepository)
        {
            _mapper = mapper;
            _exchangeRateRepository = exchangeRateRepository;
        }

        // Manager in charge of get all ExchangeRate.
        public async Task<IEnumerable<ExchangeRateModel>> GetAllExchangeRate()
        {
            var exchangeRateList = await _exchangeRateRepository.GetAll();
            return _mapper.Map<IEnumerable<ExchangeRate>, IEnumerable<ExchangeRateModel>>(exchangeRateList);
        }

        // Manager in charge of get a ExchangeRate by ID.
        public async Task<ExchangeRateModel> GetExchangeRateById(int id)
        {
            var exchangeRateFound = await _exchangeRateRepository.GetBy(id);
            return _mapper.Map<ExchangeRate, ExchangeRateModel>(exchangeRateFound);
        }

        // Manager in charge of inserte a row into ExchangeRate.
        public async Task<IEnumerable<ExchangeRateModel>> CreateExchangeRate(IList<ExchangeRateModel> exchangeRateModels)
        {
            var exchangeRateList = _mapper.Map<IList<ExchangeRateModel>, IList<ExchangeRate>>(exchangeRateModels);
            IEnumerable<ExchangeRate> result = await _exchangeRateRepository.Create(exchangeRateList);
            var exchangeRateModelList = _mapper.Map<IEnumerable<ExchangeRate>, IEnumerable<ExchangeRateModel>>(result);
            return exchangeRateModelList;
        }
    }
}

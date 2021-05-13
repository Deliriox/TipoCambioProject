using AutoMapper;
using TipoCambio.Entities;
using TipoCambio.Models;

namespace TipoCambio.BL.Mapper
{
    public class ExchangeRateMapper : Profile
    {
        public ExchangeRateMapper()
        {
            // Mapper from ExchangeRate to ExchangeRateModel and vice versa.
            CreateMap<ExchangeRate, ExchangeRateModel>().ReverseMap();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TipoCambio.BL.Manager;
using TipoCambio.Models;

namespace TipoCambio.Controllers
{
    [ApiController]
    [Route("api/ExchangeRate")]
    public class ExchangeRateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ILogger<ExchangeRateController> _logger;
        private readonly IExchangeRateManager _exchangeManager;

        public ExchangeRateController(ILogger<ExchangeRateController> logger, IExchangeRateManager exchangeRateManager)
        {
            _logger = logger;
            _exchangeManager = exchangeRateManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExchangeRateModel>>> Get()
        {
            var test = await _exchangeManager.GetAllExchangeRate();
            return Ok(test);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<ExchangeRateModel>>> GetById(int id)
        {
            var test = await _exchangeManager.GetExchangeRateById(id);
            return Ok(test);
        }

        [HttpPost]
        public async Task<ActionResult<ExchangeRateModel>> Create(IList<ExchangeRateModel> exchangeRate)
        {
            var result = await _exchangeManager.CreateExchangeRate(exchangeRate);
            if (result.Any())
                return Ok();
            return BadRequest();
        }
    }
}

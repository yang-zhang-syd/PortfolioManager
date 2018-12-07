using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioManager.API.Attributes;
using PortfolioManager.API.Models;
using PortfolioManager.Domain.AggregatesModel.StockAggregate;
using Swashbuckle.AspNetCore.Annotations;

namespace PortfolioManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        /// <summary>
        /// Create a new stock
        /// </summary>
        /// <param name="data">StockCreateModel</param>
        /// <returns>Stock created</returns>
        [HttpPost]
        [ValidateModelState]
        [SwaggerOperation("CreateStock")]
        public async Task<Stock> CreateStock([FromBody] StockCreateModel data)
        {
            var stock = _stockRepository.Add(new Stock(data.Symbol));
            await _stockRepository.UnitOfWork.SaveEntitiesAsync();
            return stock;
        }
    }
}
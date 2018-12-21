using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// <param name="data">StockModel</param>
        /// <returns>Stock created</returns>
        [HttpPost]
        [ValidateModelState]
        [SwaggerOperation("CreateStock")]
        public async Task<IActionResult> CreateStock([FromBody] StockModel data)
        {
            var existing = await _stockRepository.FindAsync(data.Symbol);
            if (existing != null)
            {
                return Conflict($"Stock {data.Symbol} already exists");
            }

            var stock = _stockRepository.Add(new Stock(data.Symbol));
            await _stockRepository.UnitOfWork.SaveEntitiesAsync();
            return Ok(stock);
        }

        /// <summary>
        /// Delete a stock record
        /// </summary>
        /// <param name="stockId">stock id</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Stock not found</response>
        [HttpDelete]
        [Route("{stockId}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteStock")]
        public async Task<IActionResult> DeleteStock([Required] int stockId)
        {
            var stock = await _stockRepository.GetAsync(stockId);
            if (stock == null)
            {
                return NotFound($"Stock {stockId} not found");
            }

            await _stockRepository.DeleteAsync(stockId);
            await _stockRepository.UnitOfWork.SaveEntitiesAsync();
            return StatusCode(204);
        }

        /// <summary>
        /// Get stock by id.
        /// </summary>
        /// <param name="stockId">stock id</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Account not found</response>
        [HttpGet]
        [Route("{stockId}")]
        [ValidateModelState]
        [SwaggerOperation("GetStock")]
        public async Task<IActionResult> GetStockById([Required] int stockId)
        {
            var stock = await _stockRepository.GetAsync(stockId);
            if (stock == null)
            {
                return NotFound($"Stock {stockId} not found.");
            }

            return Ok(stock);
        }

        /// <summary>
        /// Update an existing stock record.
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="data"></param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Stock not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPut]
        [Route("{stockId}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateStock")]
        public async Task<IActionResult> UpdateStock(int stockId, [FromBody] StockModel data)
        {
            var stock = await _stockRepository.GetAsync(stockId);
            if (stock == null)
            {
                return NotFound($"Stock {stockId} not found.");
            }

            stock.Symbol = data.Symbol;
            await _stockRepository.UpdateAsync(stock);
            await _stockRepository.UnitOfWork.SaveEntitiesAsync();
            return Ok();
        }
    }
}
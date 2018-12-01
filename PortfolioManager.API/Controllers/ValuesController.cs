using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;
using PortfolioManager.Domain.AggregatesModel.StockAggregate;

namespace PortfolioManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IStockRepository _stockRepository;

        public ValuesController(IAccountRepository accountRepository, IStockRepository stockRepository)
        {
            _accountRepository = accountRepository;
            _stockRepository = stockRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Account> Get(int id)
        {
            var account = await _accountRepository.GetAsync(id);
            return account;
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            var account = new Account("Yang Zhang", "yang.zhang@icloud.com", AccountStatus.Created);

            var stock = await _stockRepository.FindAsync("GOOG");
            if (stock == null)
            {
                stock = new Stock("GOOG");
                stock.AddStockPrice(1020, DateTime.Now);
                _stockRepository.Add(stock);
            }

            account.AddTransaction(stock.Id, 100, 1020, TransactionType.Buy, 10, DateTime.Now);
            _accountRepository.Add(account);
            await _accountRepository.UnitOfWork.SaveEntitiesAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

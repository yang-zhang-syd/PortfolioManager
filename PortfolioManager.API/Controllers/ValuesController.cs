using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;

namespace PortfolioManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public ValuesController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
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
            var account = new Account("Yang Zhang", "yang.zhang@icloud.com");
            account.AddTransaction("GOOG", 100, 1020, TransactionType.Buy);
            _accountRepository.Add(account);
            await _accountRepository.UnitOfWork.SaveChangesAsync();
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.AccountAggregate
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account Add(Account account);
        Task<Account> GetAsync(int id);
    }
}

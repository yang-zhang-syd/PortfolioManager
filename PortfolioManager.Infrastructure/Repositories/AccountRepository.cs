using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Account Add(Account account)
        {
            return _context.Accounts.Add(account).Entity;
        }

        public StockHolding AddStockHolding(StockHolding stockHolding)
        {
            return _context.StockHoldings.Add(stockHolding).Entity;
        }

        public async Task<Account> GetAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                await _context.Entry(account).Collection(i => i.Transactions).LoadAsync();
            }

            return account;
        }
    }
}

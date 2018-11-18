using System;
using System.Collections.Generic;
using System.Text;
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
    }
}

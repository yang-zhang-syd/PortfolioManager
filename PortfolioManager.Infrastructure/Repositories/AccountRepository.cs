﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PortfolioManagerDbContext _context;

        public AccountRepository(PortfolioManagerDbContext context)
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

        public async Task<bool> DeleteAsync(int id)
        {
            var account = await _context.Accounts.SingleOrDefaultAsync(a => a.Id == id);
            if (account == null)
            {
                return false;
            }

            account.SetStatus(AccountStatus.Deleted);
            return true;
        }

        public async Task<bool> UpdateAsync(Account account)
        {
            var accountToUpdate = await _context.Accounts.SingleOrDefaultAsync(a => a.Id == account.Id);
            if (account == null)
            {
                return false;
            }

            accountToUpdate.Name = account.Name;
            accountToUpdate.Email = account.Email;

            return true;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortfolioManager.Domain.Exceptions;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.AccountAggregate
{
    public class AccountStatus : Enumeration
    {
        public static AccountStatus Created = new AccountStatus(1, nameof(Created).ToLowerInvariant());
        public static AccountStatus Deleted = new AccountStatus(2, nameof(Deleted).ToLowerInvariant());

        public AccountStatus(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<AccountStatus> List() =>
            new[] { Created, Deleted};

        public static AccountStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new PortfolioManagerDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static AccountStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new PortfolioManagerDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}

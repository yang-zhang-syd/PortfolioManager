using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortfolioManager.Domain.Exceptions;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.AccountAggregate
{
    public class TransactionType : Enumeration
    {
        public static TransactionType Buy = new TransactionType(1, nameof(Buy).ToLowerInvariant());
        public static TransactionType Sell = new TransactionType(2, nameof(Sell).ToLowerInvariant());

        protected TransactionType()
        {
        }

        public TransactionType(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<TransactionType> List() =>
            new[] { Buy, Sell };

        public static TransactionType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new PortfolioManagerDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static TransactionType From(int id)
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

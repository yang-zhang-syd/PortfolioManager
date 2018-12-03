using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;

namespace PortfolioManager.API.Models
{
    public class TransactionAddModel
    {
        public TransactionType Type { get; set; }
        public int Units { get; set; }
        public int Price { get; set; }
        public int Commission { get; set; }
        public DateTime DateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioManager.Domain.Exceptions
{
    public class PortfolioManagerDomainException : Exception
    {
        public PortfolioManagerDomainException()
        { }

        public PortfolioManagerDomainException(string message)
            : base(message)
        { }

        public PortfolioManagerDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

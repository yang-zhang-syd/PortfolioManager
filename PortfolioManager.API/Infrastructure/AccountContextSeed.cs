using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using PortfolioManager.Infrastructure;

namespace PortfolioManager.API.Infrastructure
{
    public class AccountContextSeed
    {
        public async Task SeedAsync(PortfolioManagerDbContext context, IHostingEnvironment env, IOptions<AccountSettings> settings, ILogger<AccountContextSeed> logger)
        {
            var policy = CreatePolicy(logger, nameof(AccountContextSeed));

            await policy.ExecuteAsync(async () =>
            {
                using (context)
                {
                    context.Database.Migrate();
                    await context.SaveChangesAsync();
                }
            });
        }

        private Policy CreatePolicy(ILogger<AccountContextSeed> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogTrace($"[{prefix}] Exception {exception.GetType().Name} with message ${exception.Message} detected on attempt {retry} of {retries}");
                    }
                );
        }
    }
}

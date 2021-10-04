using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yab.Data;
using Yab.MultiTenancy;
using Yab.Threading;
using Yab.UnitOfWork;

namespace Yab.EntityFrameworkCore.Uow
{
    public class UowEfDbContextProvider<TDbContext> : IEfDbContextProvider<TDbContext>
        where TDbContext : DbContext
    {
        private readonly IUowManager _uowManager;
        private readonly IConnectionStringResolver _connectionStringResolver;
        private readonly ICancellationTokenProvider _cancellationTokenProvider;
        private readonly ICurrentTenant _currentTenant;
        private readonly EfDbContextOptions _options;
        private readonly ILogger<UowEfDbContextProvider<TDbContext>> _logger;

        public UowEfDbContextProvider(
            IUowManager uowManager,
            IConnectionStringResolver connectionStringResolver,
            ICancellationTokenProvider cancellationTokenProvider,
            ICurrentTenant currentTenant,
            IOptions<EfDbContextOptions> options,
            ILogger<UowEfDbContextProvider<TDbContext>> logger)
        {
            _uowManager = uowManager;
            _connectionStringResolver = connectionStringResolver;
            _cancellationTokenProvider = cancellationTokenProvider;
            _currentTenant = currentTenant;
            _options = options.Value;
            _logger = logger;
        }

        public Task<TDbContext> GetDbContextAsync()
        {
            throw new NotImplementedException();
        }
    }
}

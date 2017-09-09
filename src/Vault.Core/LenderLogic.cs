using System;
using System.Threading.Tasks;
using Serilog;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public class LenderLogic
    {
        private readonly ILogger _logger;
        private readonly ILenderRepository _repository;

        public LenderLogic(ILenderRepository repository, ILogger logger)
        {
            _logger = logger?.ForContext<LenderLogic>() ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<OperationResult<Lender>> CreateAsync(Lender lender)
        {
            _logger.Debug("Entering: {lender}", lender);

            return _repository.CreateAsync(lender);
        }
    }
}

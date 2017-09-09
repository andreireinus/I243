using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public class LenderLogic
    {
        private readonly ILenderRepository _repository;

        public LenderLogic(ILenderRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<OperationResult<Lender>> CreateAsync(Lender lender)
        {
            return _repository.CreateAsync(lender);
        }
    }
}

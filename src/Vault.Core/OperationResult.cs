using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Vault.Core
{
    public class OperationResult<T>
    {
        public OperationResult(T entity)
        {
            Entity = entity;
            Success = true;
        }

        public bool Success { get; }
        public T Entity { get; set; }
        public string[] ErrorMessages { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Vault.Core
{
    
    public class OperationResult<T> : OperationResult
    {
        public OperationResult(T entity)
        {
            Entity = entity;
            Success = true;
        }

        public T Entity { get; }
    }

    public class OperationResult
    {
        public bool Success { get; protected set; } = true;
        public string[] ErrorMessages { get; set; }
    }
}

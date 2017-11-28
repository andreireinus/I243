using System.Linq;

namespace Vault.Core
{
    
    public class OperationResult<T> : OperationResult
    {
        public OperationResult(T entity)
        {
            Entity = entity;
            Success = true;
        }

        public OperationResult(params string[] errorMessages) : base(errorMessages)
        {
        }

        public OperationResult(string message, params string[] errorMessages) : base(errorMessages.Concat(new[]{message}).ToArray())
        {
        }

        public T Entity { get; }
    }

    public class OperationResult
    {
        public OperationResult()
        {
        }

        protected OperationResult(string[] errorMessages)
        {
            ErrorMessages = errorMessages;
            Success = !errorMessages.Any();
        }

        public bool Success { get; protected set; } = true;
        public string[] ErrorMessages { get; protected set; } = { };
    }
}

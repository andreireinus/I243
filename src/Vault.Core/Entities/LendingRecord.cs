using System;

namespace Vault.Core.Entities
{
    public class LendingRecord : IEntity
    {
        public int Id { get; set; }
        public Lender Lender { get; set; }
        public LibraryItem LibraryItem { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime? Returned { get; set; }
    }
}
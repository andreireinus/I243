using System.Collections.Generic;

namespace Vault.Core.Entities
{
    public class Lender : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<LendingRecord> LendingHistory { get; set; }
    }
}

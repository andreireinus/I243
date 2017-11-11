using System.ComponentModel.DataAnnotations;

namespace Vault.Core
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}

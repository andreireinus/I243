using System.ComponentModel.DataAnnotations;
using Vault.Core;

namespace Vault.UI.Admin.Models.Lender
{
    public class EditViewModel :  CreateViewModel, IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
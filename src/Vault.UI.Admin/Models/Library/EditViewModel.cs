using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vault.Core;

namespace Vault.UI.Admin.Models.Library
{
    public class EditViewModel : CreateViewModel, IEntity
    {
        [Required]
        public int Id { get; set; }
    }

    public class LendingViewModel
    {
        [Required]
        public int BookId { get; set; }

        public string BookName { get; set; }
        [Required]
        public int LenderId { get; set; }

        public SelectListItem[] Lenders { get; set; }   

        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
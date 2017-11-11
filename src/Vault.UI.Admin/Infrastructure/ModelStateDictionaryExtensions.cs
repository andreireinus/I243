using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Vault.UI.Admin.Infrastructure
{
    public static class ModelStateDictionaryExtensions
    {
        public static void AddOperationResultErrors(this ModelStateDictionary stateDictionary, string[] errors)
        {
            foreach (var error in errors)
            {
                stateDictionary.AddModelError("Generic", error);
            }
        }
    }
}

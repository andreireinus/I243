using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vault.Core.Entities;

namespace Vault.UI.Admin.ModelMapping
{
    public static class LocationExtenstions
    {
        public static SelectListItem[] ToSelectListItem(this IEnumerable<Location> locations)
        {
            return locations.Select(l => new SelectListItem
            {
                Text = l.Name,
                Value = l.Id.ToString(CultureInfo.InvariantCulture)
            }).ToArray();
        }
    }
}

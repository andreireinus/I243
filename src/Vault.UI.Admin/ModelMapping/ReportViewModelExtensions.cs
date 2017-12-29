using System.Collections.Generic;
using System.Linq;
using Vault.Core;
using Vault.UI.Admin.Models;

namespace Vault.UI.Admin.ModelMapping
{
    public static class ReportViewModelExtensions
    {
        public static ReportResult ToViewModel(this IEnumerable<ReportInteractor.Row> rows, string title, int index)
        {
            return new ReportResult
            {
                Title = title,
                Index = index,
                Rows = rows.Select(a => a.ToViewModel()).ToArray()
            };
        }

        public static ReportRow ToViewModel(this ReportInteractor.Row row)
        {
            return new ReportRow
            {
                Author = row.Author,
                Title = row.Title,
                LoanedBy = row.LoadedTo,
                LoanedUntil = row.LoanedUntil?.ToString("F") ?? ""
            };
        }
    }
}

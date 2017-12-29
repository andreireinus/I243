namespace Vault.UI.Admin.Models
{
    public class ReportResult
    {
        public string Title { get; set; }

        public ReportRow[] Rows { get; set; }
        public int Index { get; set; }
    }
    public class ReportRow
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string LoanedBy { get; set; }
        public string LoanedUntil { get; set; }
    }
}

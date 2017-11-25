using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vault.UI.AdminForm.ClientApi;
using Vault.UI.AdminForm.ClientApi.Models;

namespace Vault.UI.AdminForm
{
    public partial class MainForm : Form
    {
        private readonly IVaultAPI _api;
        private readonly List<Lender> _lenders = new List<Lender>();
        private readonly List<Book> _books = new List<Book>();

        private MainForm()
        {
            InitializeComponent();
        }

        public MainForm(IVaultAPI api) : this()
        {
            _api = api;
        }

        private void btnCreateLibraryItem_Click(object sender, System.EventArgs e)
        {
            var book = new Book();
            var form = new BookChangeForm(_api, book);
            form.OnCreate(newbook =>
            {
                _books.Add(newbook);
                dgBooks.DataSource = null;
                dgBooks.DataSource = _books;
            });
            form.Show(this);
        }

        private async void MainForm_Load(object sender, System.EventArgs e)
        {
            _lenders.AddRange(await _api.LenderGetAllAsync());
            _lenders.Add(new Lender());
            dgLenders.DataSource = _lenders;

            _books.AddRange(await _api.BookGetAllAsync());
            dgBooks.DataSource = _books;
        }

        private async void dgLenders_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var lender = _lenders[e.RowIndex];

            await Save(lender);
        }

        private async Task Save(Lender lender)
        {
            if (string.IsNullOrWhiteSpace(lender.Name) || string.IsNullOrWhiteSpace(lender.Email))
            {
                return;
            }

            if (lender.Id == null)
            {
                var result = await _api.LenderCreateAsync(null, lender.Name, lender.Email);
                lender.Id = result.Id;
                _lenders.Add(new Lender());
            }
            else
            {
                await _api.LenderUpdateAsync(lender.Id.Value, lender.Id.Value, lender.Name, lender.Email);
            }
            dgLenders.DataSource = null;
            dgLenders.DataSource = _lenders;
        }

        private void dgBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 3)
            {
                return;
            }

            var book = _books[e.RowIndex];
            e.Value = book.IsAvailable.HasValue && book.IsAvailable.Value 
                ? "Lend out" 
                : "Mark returned";
        }

        private void dgBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgBooks.Columns[e.ColumnIndex] is DataGridViewButtonColumn 
                && e.RowIndex >= 0
                && e.ColumnIndex == 3)
            {
                var book = _books[e.RowIndex];

                var record = new LendingRecord();
                var form = new LendingForm(record, _api);
                form.ShowDialog(this);
            }
        }
    }
}

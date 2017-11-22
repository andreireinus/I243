using System;
using System.Windows.Forms;
using Vault.UI.AdminForm.ClientApi;
using Vault.UI.AdminForm.ClientApi.Models;

namespace Vault.UI.AdminForm
{
    public partial class BookChangeForm : Form
    {
        private readonly IVaultAPI _api;
        private readonly Book _book;

        public BookChangeForm(IVaultAPI api, Book book)
        {
            _api = api;
            _book = book;
            InitializeComponent();

            bookBindingSource.DataSource = _book;
        }

        private Action<Book> _actionOnCreate;

        private async void buttonSave_Click(object sender, System.EventArgs e)
        {
            if (!_book.Id.HasValue)
            {
                var result = await _api.BookCreateAsync(null, _book.Author, _book.Name);
                _actionOnCreate(result);
                Close();
            }
            else
            {
                var result = await _api.BookUpdateAsync(_book.Id.Value, _book.Id.Value, _book.Author, _book.Name);
                //_actionOnCreate(result);
            }
        }

        public void OnCreate(Action<Book> action)
        {
            _actionOnCreate = action;
        }
    }
}

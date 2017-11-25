using System;
using System.Windows.Forms;
using Vault.UI.AdminForm.ClientApi;
using Vault.UI.AdminForm.ClientApi.Models;

namespace Vault.UI.AdminForm
{
    public partial class LendingForm : Form
    {
        private readonly LendingRecord _record;
        private readonly IVaultAPI _api;

        public LendingForm(LendingRecord record, IVaultAPI api)
        {
            InitializeComponent();

            _record = record;
            _api = api;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void LendingForm_Load(object sender, EventArgs e)
        {
            var lenders = await _api.LenderGetAllAsync();
            lenderSource.DataSource = lenders;
        }
    }
}

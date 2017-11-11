using System.Windows.Forms;
using Vault.UI.AdminForm.ClientApi;

namespace Vault.UI.AdminForm
{
    public partial class MainForm : Form
    {
        private readonly IVaultAPI _api;

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

        }
    }
}

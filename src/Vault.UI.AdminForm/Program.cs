﻿using System;
using System.Windows.Forms;
using Vault.UI.AdminForm.ClientApi;

namespace Vault.UI.AdminForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var api = new VaultAPI();
            api.BaseUri = new Uri("http://localhost:55451");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(api));
        }
    }
}

namespace Vault.UI.AdminForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpDashboard = new System.Windows.Forms.TabPage();
            this.tpLibrary = new System.Windows.Forms.TabPage();
            this.dgBooks = new System.Windows.Forms.DataGridView();
            this.panelLibraryTop = new System.Windows.Forms.Panel();
            this.btnCreateLibraryItem = new System.Windows.Forms.Button();
            this.tpLenders = new System.Windows.Forms.TabPage();
            this.dgLenders = new System.Windows.Forms.DataGridView();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lendout = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lenderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl.SuspendLayout();
            this.tpLibrary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBooks)).BeginInit();
            this.panelLibraryTop.SuspendLayout();
            this.tpLenders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLenders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lenderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpDashboard);
            this.tabControl.Controls.Add(this.tpLibrary);
            this.tabControl.Controls.Add(this.tpLenders);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(769, 527);
            this.tabControl.TabIndex = 0;
            // 
            // tpDashboard
            // 
            this.tpDashboard.Location = new System.Drawing.Point(4, 22);
            this.tpDashboard.Name = "tpDashboard";
            this.tpDashboard.Size = new System.Drawing.Size(761, 501);
            this.tpDashboard.TabIndex = 2;
            this.tpDashboard.Text = "Dashboard";
            this.tpDashboard.UseVisualStyleBackColor = true;
            // 
            // tpLibrary
            // 
            this.tpLibrary.Controls.Add(this.dgBooks);
            this.tpLibrary.Controls.Add(this.panelLibraryTop);
            this.tpLibrary.Location = new System.Drawing.Point(4, 22);
            this.tpLibrary.Name = "tpLibrary";
            this.tpLibrary.Padding = new System.Windows.Forms.Padding(3);
            this.tpLibrary.Size = new System.Drawing.Size(761, 501);
            this.tpLibrary.TabIndex = 0;
            this.tpLibrary.Text = "Library";
            this.tpLibrary.UseVisualStyleBackColor = true;
            // 
            // dgBooks
            // 
            this.dgBooks.AllowUserToAddRows = false;
            this.dgBooks.AllowUserToDeleteRows = false;
            this.dgBooks.AutoGenerateColumns = false;
            this.dgBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.Author,
            this.nameDataGridViewTextBoxColumn,
            this.Lendout});
            this.dgBooks.DataSource = this.bookBindingSource;
            this.dgBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBooks.Location = new System.Drawing.Point(3, 39);
            this.dgBooks.Name = "dgBooks";
            this.dgBooks.ReadOnly = true;
            this.dgBooks.Size = new System.Drawing.Size(755, 459);
            this.dgBooks.TabIndex = 1;
            this.dgBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBooks_CellContentClick);
            this.dgBooks.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgBooks_CellFormatting);
            // 
            // panelLibraryTop
            // 
            this.panelLibraryTop.Controls.Add(this.btnCreateLibraryItem);
            this.panelLibraryTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLibraryTop.Location = new System.Drawing.Point(3, 3);
            this.panelLibraryTop.Name = "panelLibraryTop";
            this.panelLibraryTop.Size = new System.Drawing.Size(755, 36);
            this.panelLibraryTop.TabIndex = 0;
            // 
            // btnCreateLibraryItem
            // 
            this.btnCreateLibraryItem.Location = new System.Drawing.Point(6, 4);
            this.btnCreateLibraryItem.Name = "btnCreateLibraryItem";
            this.btnCreateLibraryItem.Size = new System.Drawing.Size(75, 23);
            this.btnCreateLibraryItem.TabIndex = 0;
            this.btnCreateLibraryItem.Text = "Create new";
            this.btnCreateLibraryItem.UseVisualStyleBackColor = true;
            this.btnCreateLibraryItem.Click += new System.EventHandler(this.btnCreateLibraryItem_Click);
            // 
            // tpLenders
            // 
            this.tpLenders.Controls.Add(this.dgLenders);
            this.tpLenders.Location = new System.Drawing.Point(4, 22);
            this.tpLenders.Name = "tpLenders";
            this.tpLenders.Padding = new System.Windows.Forms.Padding(3);
            this.tpLenders.Size = new System.Drawing.Size(761, 501);
            this.tpLenders.TabIndex = 1;
            this.tpLenders.Text = "Lenders";
            this.tpLenders.UseVisualStyleBackColor = true;
            // 
            // dgLenders
            // 
            this.dgLenders.AllowUserToAddRows = false;
            this.dgLenders.AllowUserToDeleteRows = false;
            this.dgLenders.AllowUserToResizeColumns = false;
            this.dgLenders.AllowUserToResizeRows = false;
            this.dgLenders.AutoGenerateColumns = false;
            this.dgLenders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLenders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgLenders.DataSource = this.lenderBindingSource;
            this.dgLenders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgLenders.Location = new System.Drawing.Point(3, 3);
            this.dgLenders.Name = "dgLenders";
            this.dgLenders.Size = new System.Drawing.Size(755, 495);
            this.dgLenders.TabIndex = 2;
            this.dgLenders.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLenders_CellEndEdit);
            // 
            // Author
            // 
            this.Author.DataPropertyName = "Author";
            this.Author.HeaderText = "Author";
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            // 
            // Lendout
            // 
            this.Lendout.HeaderText = "Lend out / Return";
            this.Lendout.Name = "Lendout";
            this.Lendout.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookBindingSource
            // 
            this.bookBindingSource.DataSource = typeof(Vault.UI.AdminForm.ClientApi.Models.Book);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Email";
            this.dataGridViewTextBoxColumn3.HeaderText = "Email";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // lenderBindingSource
            // 
            this.lenderBindingSource.DataSource = typeof(Vault.UI.AdminForm.ClientApi.Models.Lender);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 527);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Vault 13";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tpLibrary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBooks)).EndInit();
            this.panelLibraryTop.ResumeLayout(false);
            this.tpLenders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgLenders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lenderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpLibrary;
        private System.Windows.Forms.TabPage tpLenders;
        private System.Windows.Forms.TabPage tpDashboard;
        private System.Windows.Forms.DataGridView dgBooks;
        private System.Windows.Forms.Panel panelLibraryTop;
        private System.Windows.Forms.Button btnCreateLibraryItem;
        private System.Windows.Forms.BindingSource lenderBindingSource;
        private System.Windows.Forms.DataGridView dgLenders;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource bookBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Lendout;
    }
}


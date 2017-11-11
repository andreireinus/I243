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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpLibrary = new System.Windows.Forms.TabPage();
            this.tpLenders = new System.Windows.Forms.TabPage();
            this.tpDashboard = new System.Windows.Forms.TabPage();
            this.panelLibraryTop = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCreateLibraryItem = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tpLibrary.SuspendLayout();
            this.panelLibraryTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // tpLibrary
            // 
            this.tpLibrary.Controls.Add(this.dataGridView1);
            this.tpLibrary.Controls.Add(this.panelLibraryTop);
            this.tpLibrary.Location = new System.Drawing.Point(4, 22);
            this.tpLibrary.Name = "tpLibrary";
            this.tpLibrary.Padding = new System.Windows.Forms.Padding(3);
            this.tpLibrary.Size = new System.Drawing.Size(761, 501);
            this.tpLibrary.TabIndex = 0;
            this.tpLibrary.Text = "Library";
            this.tpLibrary.UseVisualStyleBackColor = true;
            // 
            // tpLenders
            // 
            this.tpLenders.Location = new System.Drawing.Point(4, 22);
            this.tpLenders.Name = "tpLenders";
            this.tpLenders.Padding = new System.Windows.Forms.Padding(3);
            this.tpLenders.Size = new System.Drawing.Size(761, 501);
            this.tpLenders.TabIndex = 1;
            this.tpLenders.Text = "Lenders";
            this.tpLenders.UseVisualStyleBackColor = true;
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
            // panelLibraryTop
            // 
            this.panelLibraryTop.Controls.Add(this.btnCreateLibraryItem);
            this.panelLibraryTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLibraryTop.Location = new System.Drawing.Point(3, 3);
            this.panelLibraryTop.Name = "panelLibraryTop";
            this.panelLibraryTop.Size = new System.Drawing.Size(755, 36);
            this.panelLibraryTop.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(755, 459);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnCreateLibraryItem
            // 
            this.btnCreateLibraryItem.Location = new System.Drawing.Point(6, 4);
            this.btnCreateLibraryItem.Name = "btnCreateLibraryItem";
            this.btnCreateLibraryItem.Size = new System.Drawing.Size(75, 23);
            this.btnCreateLibraryItem.TabIndex = 0;
            this.btnCreateLibraryItem.Text = "Create new";
            this.btnCreateLibraryItem.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 527);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Vault 13";
            this.tabControl.ResumeLayout(false);
            this.tpLibrary.ResumeLayout(false);
            this.panelLibraryTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpLibrary;
        private System.Windows.Forms.TabPage tpLenders;
        private System.Windows.Forms.TabPage tpDashboard;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelLibraryTop;
        private System.Windows.Forms.Button btnCreateLibraryItem;
    }
}


namespace BSAF
{
    partial class BSAFMainMDIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BSAFMainMDIForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBeneficiaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchBenefaciaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "Main Menu";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBeneficiaryToolStripMenuItem,
            this.searchBenefaciaryToolStripMenuItem});
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.homeToolStripMenuItem.Text = "Beneficiary";
            // 
            // addBeneficiaryToolStripMenuItem
            // 
            this.addBeneficiaryToolStripMenuItem.Name = "addBeneficiaryToolStripMenuItem";
            this.addBeneficiaryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addBeneficiaryToolStripMenuItem.Text = "Add Beneficiary";
            this.addBeneficiaryToolStripMenuItem.Click += new System.EventHandler(this.AddBeneficiaryToolStripMenuItem_Click);
            // 
            // searchBenefaciaryToolStripMenuItem
            // 
            this.searchBenefaciaryToolStripMenuItem.Name = "searchBenefaciaryToolStripMenuItem";
            this.searchBenefaciaryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.searchBenefaciaryToolStripMenuItem.Text = "Search Beneficiary";
            this.searchBenefaciaryToolStripMenuItem.Click += new System.EventHandler(this.SearchBenefaciaryToolStripMenuItem_Click);
            // 
            // BSAFMainMDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "BSAFMainMDIForm";
            this.Text = "BSAF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BSAFMainMDIForm_FormClosing);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBeneficiaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchBenefaciaryToolStripMenuItem;
    }
}


namespace Katalog_Muzyki
{
    partial class Main_Window
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
            this.listView_Catalog = new System.Windows.Forms.ListView();
            this.contextMenuStrip_list = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_list.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_Catalog
            // 
            this.listView_Catalog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Catalog.ContextMenuStrip = this.contextMenuStrip_list;
            this.listView_Catalog.FullRowSelect = true;
            this.listView_Catalog.Location = new System.Drawing.Point(12, 27);
            this.listView_Catalog.Name = "listView_Catalog";
            this.listView_Catalog.Size = new System.Drawing.Size(903, 431);
            this.listView_Catalog.TabIndex = 0;
            this.listView_Catalog.UseCompatibleStateImageBehavior = false;
            this.listView_Catalog.View = System.Windows.Forms.View.Details;
            this.listView_Catalog.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_Catalog_ColumnClick);
            // 
            // contextMenuStrip_list
            // 
            this.contextMenuStrip_list.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip_list.Name = "contextMenuStrip_list";
            this.contextMenuStrip_list.Size = new System.Drawing.Size(108, 70);
            this.contextMenuStrip_list.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_list_Opening);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Dodaj";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edytuj";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Usuń";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.grupToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(927, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.zapiszToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.loadToolStripMenuItem.Text = "Wczytaj";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.filterToolStripMenuItem.Text = "Filtruj";
            // 
            // grupToolStripMenuItem
            // 
            this.grupToolStripMenuItem.Name = "grupToolStripMenuItem";
            this.grupToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.grupToolStripMenuItem.Text = "Grupuj";
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 470);
            this.Controls.Add(this.listView_Catalog);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main_Window";
            this.Text = "Music Catalog";
            this.Load += new System.EventHandler(this.Main_Window_Load);
            this.contextMenuStrip_list.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_Catalog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grupToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_list;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
    }
}


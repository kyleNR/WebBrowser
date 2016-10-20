namespace WebBrowser
{
    partial class Browser
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
            this.URLBox = new System.Windows.Forms.TextBox();
            this.bckbutton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setHomepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fwdbutton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateTabToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox = new System.Windows.Forms.TextBox();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTabToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // URLBox
            // 
            this.URLBox.Location = new System.Drawing.Point(102, 30);
            this.URLBox.Name = "URLBox";
            this.URLBox.Size = new System.Drawing.Size(670, 20);
            this.URLBox.TabIndex = 0;
            this.URLBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.URLBox_KeyDown);
            // 
            // bckbutton
            // 
            this.bckbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bckbutton.Location = new System.Drawing.Point(12, 30);
            this.bckbutton.Name = "bckbutton";
            this.bckbutton.Size = new System.Drawing.Size(43, 20);
            this.bckbutton.TabIndex = 2;
            this.bckbutton.Text = "<-";
            this.bckbutton.UseVisualStyleBackColor = true;
            this.bckbutton.Click += new System.EventHandler(this.bckbutton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.homeToolStripMenuItem,
            this.bookmarksToolStripMenuItem,
            this.historyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTabToolStripMenuItem,
            this.duplicateTabToolStripMenuItem,
            this.closeTabToolStripMenuItem1,
            this.refreshToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newTabToolStripMenuItem
            // 
            this.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem";
            this.newTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.newTabToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.newTabToolStripMenuItem.Text = "New Tab";
            this.newTabToolStripMenuItem.Click += new System.EventHandler(this.newTabToolStripMenuItem_Click);
            // 
            // duplicateTabToolStripMenuItem
            // 
            this.duplicateTabToolStripMenuItem.Name = "duplicateTabToolStripMenuItem";
            this.duplicateTabToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.duplicateTabToolStripMenuItem.Text = "Duplicate Tab";
            this.duplicateTabToolStripMenuItem.Click += new System.EventHandler(this.duplicateTabToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setHomepageToolStripMenuItem,
            this.addBookmarkToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // setHomepageToolStripMenuItem
            // 
            this.setHomepageToolStripMenuItem.Name = "setHomepageToolStripMenuItem";
            this.setHomepageToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.setHomepageToolStripMenuItem.Text = "Set Homepage";
            this.setHomepageToolStripMenuItem.Click += new System.EventHandler(this.setHomepageToolStripMenuItem_Click);
            // 
            // addBookmarkToolStripMenuItem
            // 
            this.addBookmarkToolStripMenuItem.Name = "addBookmarkToolStripMenuItem";
            this.addBookmarkToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.addBookmarkToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addBookmarkToolStripMenuItem.Text = "Add Bookmark";
            this.addBookmarkToolStripMenuItem.Click += new System.EventHandler(this.addBookmarkToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextTabToolStripMenuItem,
            this.previousTabToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // nextTabToolStripMenuItem
            // 
            this.nextTabToolStripMenuItem.Name = "nextTabToolStripMenuItem";
            this.nextTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Tab)));
            this.nextTabToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.nextTabToolStripMenuItem.Text = "Next Tab";
            this.nextTabToolStripMenuItem.Click += new System.EventHandler(this.nextTabToolStripMenuItem_Click);
            // 
            // previousTabToolStripMenuItem
            // 
            this.previousTabToolStripMenuItem.Name = "previousTabToolStripMenuItem";
            this.previousTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Tab)));
            this.previousTabToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.previousTabToolStripMenuItem.Text = "Previous Tab";
            this.previousTabToolStripMenuItem.Click += new System.EventHandler(this.previousTabToolStripMenuItem_Click);
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // bookmarksToolStripMenuItem
            // 
            this.bookmarksToolStripMenuItem.Name = "bookmarksToolStripMenuItem";
            this.bookmarksToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.bookmarksToolStripMenuItem.Text = "Bookmarks";
            this.bookmarksToolStripMenuItem.Click += new System.EventHandler(this.bookmarksToolStripMenuItem_Click);
            // 
            // fwdbutton
            // 
            this.fwdbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fwdbutton.Location = new System.Drawing.Point(53, 30);
            this.fwdbutton.Name = "fwdbutton";
            this.fwdbutton.Size = new System.Drawing.Size(43, 20);
            this.fwdbutton.TabIndex = 5;
            this.fwdbutton.Text = "->\r\n";
            this.fwdbutton.UseVisualStyleBackColor = true;
            this.fwdbutton.Click += new System.EventHandler(this.fwdbutton_Click);
            // 
            // tabControl
            // 
            this.tabControl.HotTrack = true;
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl.Location = new System.Drawing.Point(12, 56);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 27);
            this.tabControl.TabIndex = 6;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabContextMenuStrip
            // 
            this.tabContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeTabToolStripMenuItem,
            this.duplicateTabToolStripMenuItem1});
            this.tabContextMenuStrip.Name = "contextMenuStrip1";
            this.tabContextMenuStrip.Size = new System.Drawing.Size(148, 48);
            this.tabContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.tabContextMenuStrip_Opening);
            // 
            // closeTabToolStripMenuItem
            // 
            this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
            this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.closeTabToolStripMenuItem.Text = "Close Tab";
            // 
            // duplicateTabToolStripMenuItem1
            // 
            this.duplicateTabToolStripMenuItem1.Name = "duplicateTabToolStripMenuItem1";
            this.duplicateTabToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.duplicateTabToolStripMenuItem1.Text = "Duplicate Tab";
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.White;
            this.textBox.Location = new System.Drawing.Point(12, 81);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(760, 465);
            this.textBox.TabIndex = 0;
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.historyToolStripMenuItem.Text = "History";
            // 
            // closeTabToolStripMenuItem1
            // 
            this.closeTabToolStripMenuItem1.Name = "closeTabToolStripMenuItem1";
            this.closeTabToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeTabToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.closeTabToolStripMenuItem1.Text = "Close Tab";
            this.closeTabToolStripMenuItem1.Click += new System.EventHandler(this.closeTabToolStripMenuItem1_Click);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.fwdbutton);
            this.Controls.Add(this.bckbutton);
            this.Controls.Add(this.URLBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Browser";
            this.Text = "Web Browser";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bckbutton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button fwdbutton;
        private System.Windows.Forms.ToolStripMenuItem newTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setHomepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBookmarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousTabToolStripMenuItem;
        public System.Windows.Forms.TextBox textBox;
        public System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateTabToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip tabContextMenuStrip;
        public System.Windows.Forms.TextBox URLBox;
        public System.Windows.Forms.ToolStripMenuItem bookmarksToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem1;
    }
}


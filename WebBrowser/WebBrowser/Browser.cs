using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Browser : Form
    {
        public int lockTab;
        private WebBrowser wb;
        
        public delegate void tabPageDelegate(TabPage tp);
        public tabPageDelegate tabControlAddDelegate;

        public Browser()
        {
            InitializeComponent();
            lockTab = tabControl.SelectedIndex;
            wb = new WebBrowser(this);
            InitialiseWindow();
            tabControlAddDelegate = new tabPageDelegate(AddTabPage);
        }

        private void InitialiseWindow()
        {
            URLBox.Text = wb.GetHomepage();
            wb.NewTab();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.Right))
            {
                wb.Forward();
                return true;
            } else if (keyData == (Keys.Alt | Keys.Left))
            {
                wb.Backward();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.D))
            {
                URLBox.Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void SetTextBoxMethod(String text)
        {
            if (textBox.Cursor == Cursors.WaitCursor)
                textBox.Cursor = Cursors.Default;
            textBox.Text = text;
        }

        public void AddTabPage(TabPage tp)
        {
            tabControl.Controls.Add(tp);
            tabControl.SelectedTab = tp;
            lockTab = tabControl.SelectedIndex;
            tp.Text = lockTab.ToString();
        }

        public void tabPageLoadingMethod()
        {
            textBox.Cursor = Cursors.WaitCursor;
        }

        private void bckbutton_Click(object sender, EventArgs e)
        {
            wb.Backward();
        }

        private void fwdbutton_Click(object sender, EventArgs e)
        {
            wb.Forward();
        }

        private void URLBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Modifiers == Keys.Control)
                    URLBox.Text = "http://www." + URLBox.Text + ".com";
                wb.Query(URLBox.Text);
            }
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.NewTab();
        }

        public void historyTabItem_Click(object sender, EventArgs e, String url)
        {
            wb.Query(url);
        }

        public void bookmarksTabItem_Click(object sender, EventArgs e, Website website)
        {
            wb.Query(website.GetURL());
        }

        public void editBookmarkItem_Click(object sender, EventArgs e, Website website, ToolStripMenuItem bookmarkTab)
        {
            String name = Microsoft.VisualBasic.Interaction.InputBox("Edit Bookmark Name", "Edit Bookmark", website.GetName(), -1, -1);
            if (name == "")
                name = website.GetName();
            website.SetName(name);
            String url = Microsoft.VisualBasic.Interaction.InputBox("Edit Bookmark Url", "Edit Bookmark", website.GetURL(), -1, -1);
            if (url == "")
                url = website.GetURL();
            website.SetURL(url);
            bookmarkTab.Name = url;
            bookmarkTab.Text = website.ToStringShort(name, url);
            wb.SaveData();
        }

        public void deleteBookmarkItem_Click(object sender, EventArgs e,Bookmarks bookmarks, Website website, ToolStripMenuItem bookmarkTab)
        {
            bookmarks.Remove(website);
            bookmarksToolStripMenuItem.DropDownItems.Remove(bookmarkTab);
            wb.SaveData();
        }

        public void DeleteHistoryItems()
        {
            while (historyToolStripMenuItem.DropDownItems.Count > 0)
            {
                historyToolStripMenuItem.DropDownItems.RemoveAt(0);
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String homepage = wb.GetHomepage();
            URLBox.Text = homepage;
            wb.Query(homepage);
        }

        private void addBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.AddBookmark();
        }

        private void setHomepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.SetHomepage();
        }

        private void duplicateTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.DuplicateTab();
        }

        private void tabControl_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (tabControl.TabCount > 0)
            {
                lockTab = tabControl.SelectedIndex;
                tabPageLoadingMethod();
                wb.SwitchTab(tabControl.SelectedIndex);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.Refresh();
        }

        private void nextTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == (tabControl.TabCount - 1))
                tabControl.SelectedIndex = 0;
            else
                tabControl.SelectedIndex++;
        }

        private void previousTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
                tabControl.SelectedIndex = (tabControl.TabCount - 1);
            else
                tabControl.SelectedIndex--;
        }

        private void tabContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Event {0}", e.ToString());
        }

        private void closeTabToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            wb.CloseTab();
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.ClearHistory();
            DeleteHistoryItems();
        }
    }
}

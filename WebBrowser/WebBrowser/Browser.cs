using System;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Browser : Form
    {
        private int lockTab; //Used to identify current tab and to block access from other tabs
        private WebBrowser wb;
        
        public delegate void tabPageDelegate(TabPage tp);
        public tabPageDelegate tabControlAddDelegate;

        public Browser()
        {
            InitializeComponent();
            lockTab = tabControl.SelectedIndex;
            wb = new WebBrowser(this);
            URLBox.Text = wb.GetHomepage();
            wb.NewTab();
            tabControlAddDelegate = new tabPageDelegate(AddTabPage);
        }

        public int GetLockTab()
        {
            return lockTab;
        }

        //Method override for shortcuts not linked to menu items
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

        //Add Tab Method
        public void AddTabPage(TabPage tp)
        {
            tabControl.Controls.Add(tp);
            tabControl.SelectedTab = tp;
            lockTab = tabControl.SelectedIndex;
            tp.Text = lockTab.ToString();
        }

        //Used to identify when page is being loaded in
        public void tabPageLoadingMethod()
        {
            textBox.Cursor = Cursors.WaitCursor;
        }

        //Back Button Click Event
        private void bckbutton_Click(object sender, EventArgs e)
        {
            wb.Backward();
        }

        //Forward Button Click Event
        private void fwdbutton_Click(object sender, EventArgs e)
        {
            wb.Forward();
        }

        //Used to add ENTER shortcut to URLBox for query
        //Used to add CTRL + ENTER shortcut to URLBox for quick query
        private void URLBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Modifiers == Keys.Control)
                    URLBox.Text = "http://www." + URLBox.Text + ".com";
                wb.Query(URLBox.Text);
            }
        }

        //New Tab Menu Item Click Event
        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.NewTab();
        }

        //History Menu Item Click Event
        public void historyTabItem_Click(object sender, EventArgs e, String url)
        {
            wb.Query(url);
        }

        //Bookmark Menu Item Click Event
        public void bookmarksTabItem_Click(object sender, EventArgs e, Website website)
        {
            wb.Query(website.GetURL());
        }

        //Edit Bookmark Menu Item Click Event
        public void editBookmarkItem_Click(object sender, EventArgs e, Website website, ToolStripMenuItem bookmarkTab)
        {
            //Creates Visual Basic InputBox for user input
            String name = Microsoft.VisualBasic.Interaction.InputBox("Edit Bookmark Name", "Edit Bookmark", website.GetName(), -1, -1);
            //If user enters no input, or cancels box then sets name to default
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

        //DeleteBookmark Menu Item Click Event
        public void deleteBookmarkItem_Click(object sender, EventArgs e,Bookmarks bookmarks, Website website, ToolStripMenuItem bookmarkTab)
        {
            bookmarks.Remove(website);
            bookmarksToolStripMenuItem.DropDownItems.Remove(bookmarkTab);
            wb.SaveData();
        }

        //Home Menu Item Click Event
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String homepage = wb.GetHomepage();
            URLBox.Text = homepage;
            wb.Query(homepage);
        }

        //Add Bookmark Menu Item Click Event
        private void addBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.AddBookmark();
        }

        //Set Homepage Menu Item Click Event
        private void setHomepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.SetHomepage();
        }

        //Duplicate Tab Menu Item Click Event
        private void duplicateTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.DuplicateTab();
        }

        //Change Selected Tab Event
        private void tabControl_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (tabControl.TabCount > 0)
            {
                lockTab = tabControl.SelectedIndex;
                tabPageLoadingMethod();
                wb.SwitchTab(tabControl.SelectedIndex);
            }
        }

        //Refresh Menu Item Click Event
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.Refresh();
        }

        //Next Tab Menu Item Click Event
        private void nextTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == (tabControl.TabCount - 1))
                tabControl.SelectedIndex = 0;
            else
                tabControl.SelectedIndex++;
        }

        //Previous Tab Menu Item Click Event
        private void previousTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
                tabControl.SelectedIndex = (tabControl.TabCount - 1);
            else
                tabControl.SelectedIndex--;
        }

        //Close Tab Menu Item Click Event
        private void closeTabToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            wb.CloseTab();
        }

        //Clear History Menu Item Click Event
        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.ClearHistory();
            DeleteHistoryItems();
        }

        //Remove History Menu Items Method
        public void DeleteHistoryItems()
        {
            while (historyToolStripMenuItem.DropDownItems.Count > 0)
            {
                historyToolStripMenuItem.DropDownItems.RemoveAt(0);
            }
        }
    }
}

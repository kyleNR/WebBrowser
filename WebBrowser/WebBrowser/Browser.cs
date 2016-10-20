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

        public delegate void stringDelegate(String text);
        public delegate void tabPageDelegate(TabPage tp);
        public delegate void stringTabPageDelegate(String text, TabPage tp);
        public stringDelegate textBoxSetDelegate;
        public tabPageDelegate tabControlAddDelegate;
        public stringTabPageDelegate tabPageTitleDelegate;

        public Browser()
        {
            InitializeComponent();
            lockTab = tabControl.SelectedIndex;
            wb = new WebBrowser(this);
            InitialiseWindow();
            textBoxSetDelegate = new stringDelegate(SetTextBoxMethod);
            tabControlAddDelegate = new tabPageDelegate(AddTabPage);
            tabPageTitleDelegate = new stringTabPageDelegate(SetTabPageTitle);
        }

        private void InitialiseWindow()
        {
            URLBox.Text = wb.GetHomepage();
            wb.NewTab();
        }

        public void SetTextBoxMethod(String text)
        {
            if (textBox.Cursor == Cursors.WaitCursor)
                textBox.Cursor = Cursors.Default;
            textBox.Text = text;
        }

        public void SetTabPageTitle(String title, TabPage tp)
        {
            tp.Text = title;
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

        private void bookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        public void historyTabItem_Click(object sender, EventArgs e, String url)
        {
            wb.Query(url);
        }

        public void bookmarksTabItem_Click(object sender, EventArgs e, String url)
        {
            wb.Query(url);
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
            //MessageBox.Show("You are in the TabControl.SelectedIndexChanged event.");
            lockTab = tabControl.SelectedIndex;
            tabPageLoadingMethod();
            wb.SwitchTab(tabControl.SelectedIndex);
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
    }
}

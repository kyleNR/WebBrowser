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

        private WebBrowser wb;

        public delegate void defaultDelegate();
        public delegate void stringDelegate(String text);
        public delegate void tabPageDelegate2(TabPage tp);
        public defaultDelegate tabPageLoading;
        public stringDelegate textBoxSetDelegate;
        public tabPageDelegate2 tabControlAddDelegate;

        public Browser()
        {
            InitializeComponent();
            wb = new WebBrowser(this);
            InitialiseWindow();
            tabPageLoading = new defaultDelegate(tabPageLoadingMethod);
            textBoxSetDelegate = new stringDelegate(SetTextBoxMethod);
            tabControlAddDelegate = new tabPageDelegate2(AddTabPage);
        }

        private void InitialiseWindow()
        {
            URLBox.Text = wb.GetHomepage();
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
            tp.Text = "New Tab";
        }

        public void tabPageLoadingMethod()
        {
            textBox.Text = "Loading";
            textBox.Cursor = Cursors.WaitCursor;
        }


        private void bckbutton_Click(object sender, EventArgs e)
        {
            
        }

        private void fwdbutton_Click(object sender, EventArgs e)
        {
            textBox.Text = "TESTING";
        }

        private void URLBox_Click(object sender, EventArgs e)
        {
            textBox.Text = "TESTINGS";
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {

            wb.NewTab();
        }

        private void bookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void setHomepageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void duplicateTabToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabControl_SelectedIndexChanged(Object sender, EventArgs e)
        {

            MessageBox.Show("You are in the TabControl.SelectedIndexChanged event.");
            wb.switchTab(tabControl.SelectedIndex);

        }
    }
}

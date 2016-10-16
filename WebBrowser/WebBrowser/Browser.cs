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

        public Browser()
        {
            InitializeComponent();
            wb = new WebBrowser();
            InitialiseWindow();
        }

        private void InitialiseWindow()
        {
            URLBox.Text = wb.GetHomepage();
            wb.SetTabControl(tabControl);
            wb.SetTextBox(textBox);
            

        }

        private void bckbutton_Click(object sender, EventArgs e)
        {
            wb.Back();
        }

        private void fwdbutton_Click(object sender, EventArgs e)
        {
            textBox.Text = "TESTING";
            wb.Forward();
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
    }
}

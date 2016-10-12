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
        public Browser()
        {
            InitializeComponent();
        }

        private void fwdbutton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "TESTING";
        }
    }
}

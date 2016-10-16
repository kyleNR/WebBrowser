using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace WebBrowser
{
    class Tab
    {
        private TabPage tp;

        private History history;
        private String url;
        private TextBox box;
        private String page;

        public Tab(TabPage tp, TextBox box)
        {
            this.tp = tp;
            this.box = box;
            this.page = "";
            history = new History();
        }

        public String AccessURL(String url)
        {
            page = GetHTTP(url);
            this.url = url;
            history.Add("", url);

            return page;
        }

        private String GetHTTP(String url)
        {
            /*
            using (var client = new HttpClient())
            {
                return client.GetStringAsync("http://www.google.com").ToString();
            }
            */
            using (var client = new WebClient())
            {
                try
                {
                    var responseString = client.DownloadString("http://www.google.com/dwdwdwdw");
                    return responseString;
                } catch (WebException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return "";

        }

        public void Forward()
        {

        }

        public void Back()
        {

        }
    }
}

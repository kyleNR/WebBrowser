using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;

namespace WebBrowser
{
    class Tab
    {
        private Browser browser;
        private WebBrowser wb;
        private TabPage tp;

        private History history;
        private String url;
        private String page;

        public Tab(Browser browser, WebBrowser wb)
        {
            this.browser = browser;
            this.wb = wb;
            this.page = "";
            history = new History();
            CreateTab();
        }

        public void AccessURL(String url)
        {
            browser.Invoke(browser.tabPageLoading);
            page = GetHTTP(url);
            this.url = url;
            history.Add("", url);
            browser.Invoke(browser.textBoxSetDelegate,page);
        }

        private void CreateTab()
        {
            tp = new TabPage();
            browser.Invoke(browser.tabControlAddDelegate, tp);
            AccessURL(wb.GetHomepage());
        }

        private String GetHTTP(String url)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var responseString = client.DownloadString("http://www.google.com/");
                    return responseString;
                } catch (WebException e)
                {
                    //MessageBox.Show(e.Message);
                    return e.Message;
                }
            }
        }

        public void Forward()
        {

        }

        public void Back()
        {

        }

        public void Close()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace WebBrowser
{
    class Tab
    {
        private Browser browser;
        private WebBrowser wb;
        private TabPage tp;

        private int index;
        public History history;
        public String url;
        public String page;

        public Tab(Browser browser, WebBrowser wb)
        {
            this.browser = browser;
            this.wb = wb;
            this.page = ""; 
            history = new History();
            CreateTab();
        }

        public Tab(Browser browser, WebBrowser wb, Tab tab)
        {
            this.browser = browser;
            this.wb = wb;
            this.page = tab.page;
            history = new History(tab.history);
            CreateTab();
        }

        public void AccessURL(String url)
        {
            CheckIndex();
            browser.Invoke(new MethodInvoker(delegate
            {
                if (index == browser.lockTab)
                {
                    //browser.tabPageLoadingMethod
                    browser.textBox.Cursor = Cursors.WaitCursor;
                }
            }));
            page = GetHTTP(url);
            this.url = url;
            history.Add(GetTitle(), url);
            DisplayPage();
        }

        private void CreateTab()
        {
            tp = new TabPage();
            wb.SetCurrentTab(this);
            browser.Invoke(browser.tabControlAddDelegate, tp);
            AccessURL(wb.GetHomepage());
            GetTitle();
        }

        private void CheckIndex()
        {
            browser.Invoke(new MethodInvoker(delegate
            {
                index = browser.tabControl.SelectedIndex;
            }));
        }

        private String GetHTTP(String url)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var responseString = client.DownloadString(url);
                    return responseString;
                } catch (WebException e)
                {
                    return e.Message;
                }
            }
        }

        private String GetTitle()
        {
            //Regex to grab <title>____<title>
            return index.ToString();
        }

        public void TabSwitch()
        {
            DisplayPage();
        }

        public void Refresh()
        {
            AccessURL(url);
        }

        private bool DisplayPage()
        {
            bool locked = true;
            CheckIndex();
            browser.Invoke(new MethodInvoker(delegate
            {
                if (index == browser.lockTab)
                {
                    locked = false;
                    //browser.Invoke(browser.textBoxSetDelegate, page);
                    if (browser.textBox.Cursor == Cursors.WaitCursor)
                        browser.textBox.Cursor = Cursors.Default;
                    browser.textBox.Text = page;
                    browser.URLBox.Text = url;
                }
            }));
            if (locked)
                return false;
            return true;
        }

        public void Forward()
        {

        }

        public void Back()
        {

        }

        public void Close()
        {
            CheckIndex();
            browser.Invoke(new MethodInvoker(delegate
            {
                if (index == browser.lockTab)
                {
                    browser.tabControl.Controls.Remove(tp);
                }
            }));
        }
    }
}

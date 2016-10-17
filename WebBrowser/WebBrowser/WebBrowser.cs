using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{

    class WebBrowser
    {
        private History history;
        private String homepage;
        private List<Website> bookmarks;
        private List<Tab> tabList;
        private Tab currentTab;

        private Browser browser;

        public WebBrowser(Browser browser)
        {
            this.browser = browser;
            history = new History();
            homepage = LoadHomepage();
            bookmarks = LoadBookmarks();
            tabList = new List<Tab>();
            
        }

        private String LoadHomepage()
        {
            // Try getting homepage
                //FileGetter fg = new FileGetter;
            // else
            return "http://www.google.com";
        }

        public String GetHomepage()
        {
            return homepage;
        }

        private List<Website> LoadBookmarks()
        {
            return new List<Website>();
        }

        public void NewTab()
        {
            /*
            TabPage tp = new TabPage("New Tab");
            TabControl tc = browser.tabControl;
            tc.Controls.Add(tp);
            tc.SelectedTab = tp;
            */

            Thread thread = new Thread(() => new Tab(browser, this));
            thread.Start();
        }

        private void NewThread(TabPage tp)
        {
            // Figure out how to do the event handler stuff.
            // Link thread with tab.
            currentTab = new Tab(browser, this);
            tabList.Add(currentTab);
        }

        public void switchTab(int index)
        {

            //currentTab = tabList[index];
        }
    }
}

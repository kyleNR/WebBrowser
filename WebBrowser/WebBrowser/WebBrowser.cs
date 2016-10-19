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

        public void SetHomepage()
        {

        }

        private List<Website> LoadBookmarks()
        {
            return new List<Website>();
        }

        public void NewTab()
        {
            Thread thread = new Thread(() => new Tab(browser, this));
            thread.Start();
        }

        public void DuplicateTab()
        {
            Thread thread = new Thread(() => new Tab(browser, this, currentTab));
            thread.Start();
        }

        public void SetCurrentTab(Tab tab)
        {
            currentTab = tab;
            if (!tabList.Contains(tab))
                tabList.Add(tab);
        }

        public void SwitchTab(int index)
        {
            currentTab = tabList[index];
            Thread thread = new Thread(() => currentTab.TabSwitch());
            thread.Start();
        }

        public void Refresh()
        {
            Thread thread = new Thread(() => currentTab.Refresh());
            thread.Start();
        }

        public void Query(String url)
        {
            Thread thread = new Thread(() => currentTab.AccessURL(url));
            thread.Start();
        }

        public void Forward()
        {

        }

        public void Back()
        {

        }
    }
}

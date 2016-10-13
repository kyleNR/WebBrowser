using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebBrowser
{
    struct Website
    {
        String name, url;
        public Website(String name, String url)
        {
            this.name = name;
            this.url = url;
        }
    }

    class WebBrowser
    {
        private List<String> history;
        private String homepage;
        private List<Website> bookmarks;
        private Tab currentTab;

        public WebBrowser()
        {
            history = new List<String>();
            homepage = LoadHomepage();
            bookmarks = LoadBookmarks();
            currentTab = new Tab();
        }

        private String LoadHomepage()
        {
            // Try getting homepage
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
            Thread thread = new Thread(new ThreadStart(newThread));
            //start new tab
            thread.Start();
        }

        private void newThread()
        {
            // Figure out how to do the event handler stuff.
            // Link thread with tab.
            currentTab = new Tab();
        }
    }
}

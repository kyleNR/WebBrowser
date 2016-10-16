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

        private TabControl tc;
        private TextBox tb;

        public WebBrowser()
        {
            history = new History();
            homepage = LoadHomepage();
            bookmarks = LoadBookmarks();
            tabList = new List<Tab>();
        }

        public void SetTextBox(TextBox tb)
        {
            this.tb = tb;
        }

        public void SetTabControl(TabControl tc)
        {
            this.tc = tc;
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
            //Thread thread = new Thread(new ParameterizedThreadStart(newThread));
            TabPage tp = new TabPage("New Tab");
            tc.Controls.Add(tp);
            tc.SelectedTab = tp;

            //Thread thread = new Thread(() => NewThread(tp));
            //thread.Start();
            TempThreadWorkAround(tp);
            tb.Text = currentTab.AccessURL(homepage);
        }

        private void NewThread(TabPage tp)
        {
            // Figure out how to do the event handler stuff.
            // Link thread with tab.
            currentTab = new Tab(tp, tb);
            tabList.Add(currentTab);

            
        }

        private void TempThreadWorkAround(TabPage tp)
        {
            currentTab = new Tab(tp, tb);
            tabList.Add(currentTab);
        }

        public void switchTab(int index)
        {
            currentTab = tabList[index];
        }

        public void Forward()
        {
            currentTab.Forward();
        }

        public void Back()
        {
            currentTab.Back();
        }
    }
}

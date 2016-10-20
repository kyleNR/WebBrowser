using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{

    public class WebBrowser
    {
        private History history;
        private Bookmarks bookmarks;
        private FileGetter fg;
        private String homepage;
        private List<Tab> tabList;
        private Tab currentTab;

        private Browser browser;

        public WebBrowser(Browser browser)
        {
            this.browser = browser;
            history = new History();
            bookmarks = new Bookmarks();
            fg = new FileGetter(history, bookmarks, "Data.xml");
            tabList = new List<Tab>();
            homepage = fg.GetHomepage();
            AddDataToForm();
        }

        public String GetHomepage()
        {
            return homepage;
        }

        public void SetHomepage()
        {
            homepage = browser.URLBox.Text;
            fg.SetHomepage(homepage);
            SaveData();
        }

        public History GetHistory()
        {
            return history;
        }

        public Bookmarks GetBookmarks()
        {
            return bookmarks;
        }

        private void AddDataToForm()
        {
            LoadBookmarks();
            LoadHistory();
        }

        public void SaveData()
        {
            Thread thread = new Thread(() => fg.SaveData());
            thread.Start();
        }

        private List<Website> LoadBookmarks()
        {
            foreach (Website website in bookmarks.GetWebsiteList())
            {
                var bookmarkTab = new System.Windows.Forms.ToolStripMenuItem()
                {
                    Name = website.GetURL(),
                    Text = website.ToStringShort(),
                };
                bookmarkTab.Click += (sender, e) => browser.bookmarksTabItem_Click(sender, e, website);
                var editBookmark = new System.Windows.Forms.ToolStripMenuItem()
                {
                    Text = "Edit Bookmark",
                };
                editBookmark.Click += (sender, e) => browser.editBookmarkItem_Click(sender, e, website, bookmarkTab);
                var deleteBookmark = new System.Windows.Forms.ToolStripMenuItem()
                {
                    Text = "Delete Bookmark",
                };
                deleteBookmark.Click += (sender, e) => browser.deleteBookmarkItem_Click(sender, e, bookmarks, website, bookmarkTab);
                bookmarkTab.DropDownItems.Add(editBookmark);
                bookmarkTab.DropDownItems.Add(deleteBookmark);
                browser.bookmarksToolStripMenuItem.DropDownItems.Add(bookmarkTab);
            }
            return new List<Website>();
        }

        private List<Website> LoadHistory()
        {
            foreach (Website website in history.GetWebsiteList())
            {
                var historyTab = new System.Windows.Forms.ToolStripMenuItem()
                {
                    Name = website.GetURL(),
                    Text = website.ToString(),
                };
                historyTab.Click += (sender, e) => browser.historyTabItem_Click(sender, e, website.GetURL());
                browser.historyToolStripMenuItem.DropDownItems.Add(historyTab);
            }
            return new List<Website>();
        }

        public void ClearHistory()
        {
            history.Clear();
            SaveData();
        }

        public void SetCurrentTab(Tab tab)
        {
            currentTab = tab;
            if (!tabList.Contains(tab))
                tabList.Add(tab);
        }

        public void AddBookmark()
        {
            Thread thread = new Thread(() => currentTab.AddBookmark());
            thread.Start();
            SaveData();
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
            SaveData();
        }

        public void Forward()
        {
            Thread thread = new Thread(() => currentTab.Forward());
            thread.Start();
        }

        public void Backward()
        {
            Thread thread = new Thread(() => currentTab.Backward());
            thread.Start();
        }

        public void CloseTab()
        {
            if (tabList.Count == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you would like to exit?", "Exit Program", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    fg.SaveData();
                    System.Windows.Forms.Application.Exit();
                }
                return;
            }
            int index = currentTab.GetIndex();
            tabList.Remove(currentTab);
            Thread thread = new Thread(() => currentTab.Close());
            thread.Start();
            foreach (Tab tab in tabList)
            {
                if (tab.GetIndex() > index)
                {
                    Thread tabThread = new Thread(() => tab.SetIndex(tab.GetIndex() - 1));
                    tabThread.Start();
                }
            }
        }
    }
}

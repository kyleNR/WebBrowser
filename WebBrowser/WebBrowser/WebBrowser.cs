using System;
using System.Collections.Generic;
using System.Threading;
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

        //Sets homepage based on URLBox and saves data
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

        //After data loaded from file dynamically add to GUI
        private void AddDataToForm()
        {
            LoadBookmarks();
            LoadHistory();
        }

        //Saves data in new thread to not slow down application
        public void SaveData()
        {
            Thread thread = new Thread(() => fg.SaveData());
            thread.Start();
        }

        //Dynamically add bookmarks to GUI menu
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
                //Dynamically add menu items to each bookmark
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
                //Add bookmark items to GUI
                bookmarkTab.DropDownItems.Add(editBookmark);
                bookmarkTab.DropDownItems.Add(deleteBookmark);
                browser.bookmarksToolStripMenuItem.DropDownItems.Add(bookmarkTab);
            }
            return new List<Website>();
        }

        //Dynamically add history to GUI menu
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

        //Removes history from system and file
        public void ClearHistory()
        {
            history.Clear();
            SaveData();
        }

        //Set tab to current tab
        //Used to add new tabs to tabList
        public void SetCurrentTab(Tab tab)
        {
            currentTab = tab;
            if (!tabList.Contains(tab))
                tabList.Add(tab);
        }

        //Add bookmark to system and save
        public void AddBookmark()
        {
            Thread thread = new Thread(() => currentTab.AddBookmark());
            thread.Start();
            SaveData();
        }

        //Create new tab in new thread
        public void NewTab()
        {
            Thread thread = new Thread(() => new Tab(browser, this));
            thread.Start();
        }

        //Create new tab as clone of current tab
        public void DuplicateTab()
        {
            Thread thread = new Thread(() => new Tab(browser, this, currentTab));
            thread.Start();
        }

        //Switch tab based off tab container index
        public void SwitchTab(int index)
        {
            currentTab = tabList[index];
            Thread thread = new Thread(() => currentTab.TabSwitch());
            thread.Start();
        }

        //Refresh page
        public void Refresh()
        {
            Thread thread = new Thread(() => currentTab.Refresh());
            thread.Start();
        }

        //Send request to url and save history
        public void Query(String url)
        {
            Thread thread = new Thread(() => currentTab.AccessURL(url));
            thread.Start();
            SaveData();
        }

        //Move current tab forwards
        public void Forward()
        {
            Thread thread = new Thread(() => currentTab.Forward());
            thread.Start();
        }

        //Move current tab backwards
        public void Backward()
        {
            Thread thread = new Thread(() => currentTab.Backward());
            thread.Start();
        }

        //Close current tab
        //Used to close application if one tab remaining
        public void CloseTab()
        {
            if (tabList.Count == 1)
            {
                //Creates Visual Basic MessageBox for user input with Yes/No to closing program
                DialogResult dialogResult = MessageBox.Show("Are you sure you would like to exit?", "Exit Program", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //Closing program - Save and Exit
                    fg.SaveData();
                    System.Windows.Forms.Application.Exit();
                }
                return;
            }
            //Remove tab from list of tabs before deleting it
            int index = currentTab.GetIndex();
            tabList.Remove(currentTab);
            Thread thread = new Thread(() => currentTab.Close());
            thread.Start();
            //Move each tab's index to represent its tab container position
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

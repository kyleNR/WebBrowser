using System;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace WebBrowser
{
    public class Tab
    {
        private Browser browser;
        private WebBrowser wb;
        private TabPage tp;

        private TabHistory tabHistory;
        private int index;
        private String url;
        private String page;

        public Tab(Browser browser, WebBrowser wb)
        {
            this.browser = browser;
            this.wb = wb;
            this.page = "";
            this.tabHistory = new TabHistory(wb.GetHistory());
            CreateTab();
        }

        //Second constructor used to duplicate tab
        public Tab(Browser browser, WebBrowser wb, Tab tab)
        {
            this.browser = browser;
            this.wb = wb;
            this.page = tab.page;
            this.url = tab.GetURL();
            tabHistory = new TabHistory(tab.GetTabHistory());
            DuplicateTab();
        }

        public String GetURL()
        {
            return url;
        }

        public String GetPage()
        {
            return page;
        }

        public TabHistory GetTabHistory()
        {
            return tabHistory;
        }

        public int GetIndex()
        {
            return index;
        }

        public void SetIndex(int index)
        {
            this.index = index;
        }

        //Access previous URL without checking it or adding to history
        public void AccessURL()
        {
            CheckIndex();
            browser.Invoke(new MethodInvoker(delegate
            {
                if (index == browser.GetLockTab())
                {
                    browser.tabPageLoadingMethod();
                }
            }));
            page = GetHTTP(url);
            DisplayPage();
        }

        //Access URL for query
        public void AccessURL(String url)
        {
            //Check for correct access to GUI
            CheckIndex();
            browser.Invoke(new MethodInvoker(delegate
            {
                if (index == browser.GetLockTab())
                {
                    browser.tabPageLoadingMethod();
                }
            }));
            //Get HTML
            page = GetHTTP(url);
            //Check if same URL
            if (this.url != url)
            {
                this.url = url;
                //Add to tab and global history
                tabHistory.Add(url);
                AddWebsiteToMenu(wb.GetHistory().Add(GetTitle(), url));
            }
            DisplayPage();
        }

        //Add bookmark dynamically using GUI
        public void AddBookmark()
        {
            Website website = wb.GetBookmarks().Add(GetTitle(), url);
            //Use Browser thread to add bookmark
            browser.Invoke(new MethodInvoker(delegate
            {
                String temp = Microsoft.VisualBasic.Interaction.InputBox("New Bookmark Name", "New Bookmark", website.GetName(), -1, -1);
                if (temp == "")
                    temp = GetTitle();
                website.SetName(temp);
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
                deleteBookmark.Click += (sender, e) => browser.deleteBookmarkItem_Click(sender, e, wb.GetBookmarks(), website, bookmarkTab);
                //Add bookmark items to GUI
                bookmarkTab.DropDownItems.Add(editBookmark);
                bookmarkTab.DropDownItems.Add(deleteBookmark);
                browser.bookmarksToolStripMenuItem.DropDownItems.Add(bookmarkTab);
            }));
        }

        //Add history dynnamically to GUI
        private void AddWebsiteToMenu(Website website)
        {
            browser.Invoke(new MethodInvoker(delegate
            {
                var historyTab = new System.Windows.Forms.ToolStripMenuItem()
                {
                    Name = website.GetURL(),
                    Text = website.ToString(),
                };
                historyTab.Click += (sender, e) => browser.historyTabItem_Click(sender, e, website.GetURL());
                browser.historyToolStripMenuItem.DropDownItems.Add(historyTab);
            }));
        }

        //Create new tab in GUI
        private void CreateTab()
        {
            tp = new TabPage();
            wb.SetCurrentTab(this);
            browser.Invoke(browser.tabControlAddDelegate, tp);
            AccessURL(wb.GetHomepage());
        }

        //Create duplicate tab in GUI
        private void DuplicateTab()
        {
            tp = new TabPage();
            wb.SetCurrentTab(this);
            browser.Invoke(browser.tabControlAddDelegate, tp);
            AccessURL();
        }

        //Check if tab index is the same as GUI tab index
        private void CheckIndex()
        {
            browser.Invoke(new MethodInvoker(delegate
            {
                index = browser.tabControl.SelectedIndex;
            }));
        }

        //Get HTML from URL
        private String GetHTTP(String url)
        {
            //Use regex to check for invalid URLs
            Match m = Regex.Match(url, @"([@!<>%~'{}()]|(\.\.))+");
            if (m.Success)
            {
                return "Not a valid URL";
            }
            else
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        var responseString = client.DownloadString(url);
                        return responseString;
                    }
                    catch (WebException e)
                    {
                        return e.Message;
                    }
                }
            }

        }

        //Use regex to check for title elements and set GUI tab title
        private String GetTitle()
        {
            Match m = Regex.Match(page, @"<title>\s*(.+?)\s*</title>");
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            else
            {
                return url;
            }
        }

        //Called when tabs switch
        //Displays already fetched HTML
        public void TabSwitch()
        {
            DisplayPage();
        }

        //Called on refresh
        //Requests last URL's HTML
        public void Refresh()
        {
            AccessURL();
        }

        //Moves forward in tab history if possible
        public void Forward()
        {
            String tempURL = tabHistory.Forward();
            if (url != tempURL)
            {
                url = tempURL;
                AccessURL();
            }
        }

        //Moves backward in tab history if possible
        public void Backward()
        {
            String tempURL = tabHistory.Backward();
            if (url != tempURL)
            {
                url = tempURL;
                AccessURL();
            }
        }

        //Closes Tab
        //Checks for clearance and then removes GUI tab
        public void Close()
        {
            CheckIndex();
            browser.Invoke(new MethodInvoker(delegate
            {
                if (index == browser.GetLockTab())
                {
                    browser.tabControl.Controls.Remove(tp);
                }
            }));
        }

        //Displays fetched URL in text box
        private bool DisplayPage()
        {
            bool locked = true;
            CheckIndex();
            browser.Invoke(new MethodInvoker(delegate
            {
                if (index == browser.GetLockTab())
                {
                    locked = false;
                    browser.textBox.Cursor = Cursors.Default;
                    browser.textBox.Text = page;
                    browser.URLBox.Text = url;
                    tp.Text = GetTitle();
                }
            }));
            if (locked)
                return false;
            return true;
        }
    }
}

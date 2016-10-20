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
using System.Text.RegularExpressions;

namespace WebBrowser
{
    public class Tab
    {
        private Browser browser;
        private WebBrowser wb;
        private TabPage tp;

        private int index;
        private History history;
        private TabHistory tabHistory;
        private Bookmarks bookmarks;
        private String url;
        private String page;

        public Tab(Browser browser, WebBrowser wb)
        {
            this.browser = browser;
            this.wb = wb;
            this.page = "";
            this.history = wb.GetHistory();
            this.tabHistory = new TabHistory(history);
            this.bookmarks = wb.GetBookmarks();
            CreateTab();
        }

        public Tab(Browser browser, WebBrowser wb, Tab tab)
        {
            this.browser = browser;
            this.wb = wb;
            this.page = tab.page;
            this.url = tab.GetURL();
            history = tab.GetHistory();
            tabHistory = new TabHistory(tab.GetTabHistory());
            DuplicateTab();
        }

        public String GetURL()
        {
            return url;
        }

        public History GetHistory()
        {
            return history;
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

        public void AccessURL()
        {
            CheckIndex();
            browser.Invoke(new MethodInvoker(delegate
            {
                if (index == browser.lockTab)
                {
                    browser.tabPageLoadingMethod();
                }
            }));
            page = GetHTTP(url);
            DisplayPage();
        }

        public void AccessURL(String url)
        {
            CheckIndex();
            browser.Invoke(new MethodInvoker(delegate
            {
                if (index == browser.lockTab)
                {
                    browser.tabPageLoadingMethod();
                }
            }));
            page = GetHTTP(url);
            if (this.url != url)
            {
                this.url = url;
                tabHistory.Add(url);
                AddWebsiteToMenu(history.Add(GetTitle(), url));
            }
            DisplayPage();
        }

        public void AddBookmark()
        {
            Website website = bookmarks.Add(GetTitle(), url);
            browser.Invoke(new MethodInvoker(delegate
            {
                var bookmarkTab = new System.Windows.Forms.ToolStripMenuItem()
                {
                    Name = website.GetURL(),
                    Text = website.ToString(),
                };
                bookmarkTab.Click += (sender, e) => browser.bookmarksTabItem_Click(sender, e, website.GetURL());
                browser.bookmarksToolStripMenuItem.DropDownItems.Add(bookmarkTab);
            }));
        }

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

        private void CreateTab()
        {
            tp = new TabPage();
            wb.SetCurrentTab(this);
            browser.Invoke(browser.tabControlAddDelegate, tp);
            AccessURL(wb.GetHomepage());
        }

        private void DuplicateTab()
        {
            tp = new TabPage();
            wb.SetCurrentTab(this);
            browser.Invoke(browser.tabControlAddDelegate, tp);
            AccessURL();
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
            Match m = Regex.Match(url, @"\.\.");
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

        public void TabSwitch()
        {
            DisplayPage();
        }

        public void Refresh()
        {
            AccessURL();
        }

        public void Forward()
        {
            String tempURL = tabHistory.Forward();
            if (url != tempURL)
                AccessURL();
        }

        public void Backward()
        {
            String tempURL = tabHistory.Backward();
            if (url != tempURL)
                AccessURL();
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
                    browser.textBox.Cursor = Cursors.Default;
                    browser.textBox.Text = page;
                    browser.URLBox.Text = url;
                    browser.Invoke(browser.tabPageTitleDelegate, GetTitle(), tp);
                }
            }));
            if (locked)
                return false;
            return true;
        }
    }
}

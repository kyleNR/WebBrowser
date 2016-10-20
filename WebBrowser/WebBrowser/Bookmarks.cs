using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{
    public class Bookmarks
    {
        private List<Website> bookmarks;

        public Bookmarks()
        {
            bookmarks = new List<Website>();
        }

        public Website Add(String name, String url)
        {

            Website website = new Website(name, url);
            bookmarks.Add(website);
            return website;
        }

        public void Add(Website website)
        {
            bookmarks.Add(website);
        }

        public void SetBookmarks(List<Website> bookmarks)
        {
            this.bookmarks = bookmarks;
        }

        public String GetXML()
        {
            String output = "<Bookmarks>";
            foreach (Website website in bookmarks)
            {
                output += String.Format("<Website><Name>{0}</Name><URL>{1}</URL><Time>{2}</Time></Website>", website.GetName(), website.GetURL(), website.GetTime());
            }
            output += "</Bookmarks>";
            return output;
        }
    }
}

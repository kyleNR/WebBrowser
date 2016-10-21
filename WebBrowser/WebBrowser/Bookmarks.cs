using System;
using System.Collections.Generic;

namespace WebBrowser
{
    public class Bookmarks
    {
        private List<Website> bookmarks;

        public Bookmarks()
        {
            bookmarks = new List<Website>();
        }

        public List<Website> GetWebsiteList()
        {
            return bookmarks;
        }

        //Adds item to bookmarks
        //Returns website to allow easy creation while adding to bookmarks
        public Website Add(String name, String url)
        {
            //Creates struct to hold item
            Website website = new Website(name, url);
            bookmarks.Add(website);
            return website;
        }

        //Adds item to bookmarks
        public void Add(Website website)
        {
            bookmarks.Add(website);
        }

        //Removes item from bookmarks
        public void Remove(Website website)
        {
            bookmarks.Remove(website);
        }

        public void SetBookmarks(List<Website> bookmarks)
        {
            this.bookmarks = bookmarks;
        }

        //Gets full bookmarks list in XML
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

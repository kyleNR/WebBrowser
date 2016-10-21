using System;
using System.Collections.Generic;

namespace WebBrowser
{

    public class History
    {
        private List<Website> webList;

        public History()
        {
            webList = new List<Website>();
        }

        public List<Website> GetWebsiteList()
        {
            return webList;
        }

        public int GetLength()
        {
            return webList.Count;
        }

        public void Add(Website website)
        {
            webList.Add(website);
        }

        //Adds item to history
        public Website Add(String name, String url)
        {
            //Creates struct to hold item
            Website website = new Website(name, url);
            webList.Add(website);
            return website;
        }

        //Clears history
        public void Clear()
        {
            webList.Clear();
        }

        //Gets full history in XML
        public String GetXML()
        {
            String output = "<History>";
            foreach (Website website in webList)
            {
                output += String.Format("<Website><Name>{0}</Name><URL>{1}</URL><Time>{2}</Time></Website>", website.GetName(), website.GetURL(), website.GetTime());
            }
            output += "</History>";
            return output;
        }
    }
}

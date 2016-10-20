using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{

    public class History
    {
        private List<Website> webList;

        public History()
        {
            webList = new List<Website>();
        }

        public List<String> GetWebsiteListString()
        {
            List<String> stringList = new List<String>();
            foreach (Website website in webList)
            {
                stringList.Add(website.ToString());
            }
            return stringList;
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

        public Website Add(String name, String url)
        {
            Website website = new Website(name, url);
            webList.Add(website);
            return website;
        }
        public void Clear()
        {
            webList.Clear();
        }

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

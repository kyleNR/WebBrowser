using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{

    struct Website
    {
        String name;
        String url;
        String time;
        public Website (String name, String url)
        {
            DateTime dateTime = DateTime.Now;
            this.name = name;
            this.url = url;
            this.time = dateTime.ToString();
        }
    }

    public class History
    {
        private int index;
        private List<Website> webList;

        public History()
        {
            webList = new List<Website>();
            index = -1;
        }

        public History(History oldHistory)
        {

            //webList = Duplicate(oldHistory);
        }

        public int GetIndex()
        {
            return index;
        }

        /*
        public List<Website> GetWebList()
        {
            return webList;
        }*/

        public int GetLength()
        {
            return webList.Count;
        }

        public void Add(String name, String url)
        {
            Website website = new Website(name, url);
            webList.Add(website);
            index++;
        }
    }
}

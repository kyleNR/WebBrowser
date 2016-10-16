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
        private List<Website> history;

        public History()
        {
            history = new List<Website>();
        }

        public int GetLength()
        {
            return history.Count;
        }

        public void Add(String name, String url)
        {
            Website website = new Website(name, url);
            history.Add(website);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{

    public class Website
    {
        private String name;
        private String url;
        private String time;

        public Website(String name, String url)
        {
            DateTime dateTime = DateTime.Now;
            this.name = name;
            this.url = url;
            this.time = dateTime.ToString();
        }

        public Website(String name, String url, String time)
        {
            this.name = name;
            this.url = url;
            this.time = time;
        }

        public override String ToString()
        {
            return String.Format("{0} : {1} : {2}",name,url,time);
        }

        public String GetName()
        {
            return name;
        }

        public String GetURL()
        {
            return url;
        }

        public String GetTime()
        {
            return time;
        }
    }
}

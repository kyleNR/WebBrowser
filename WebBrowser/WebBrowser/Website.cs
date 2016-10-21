using System;

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

        public override String ToString() { return String.Format("{0} : {1} : {2}",name,url,time); }
        public String ToString(String name) { return String.Format("{0} : {1} : {2}", name, url, time); }
        public String ToString(String name, String url) { return String.Format("{0} : {1} : {2}", name, url, time); }

        public String ToStringShort() { return String.Format("{0} : {1}", name, url); }
        public String ToStringShort(String name) { return String.Format("{0} : {1}", name, url); }
        public String ToStringShort(String name, String url) { return String.Format("{0} : {1}", name, url); }

        public String GetName()
        {
            return name;
        }

        public void SetName (String name)
        {
            this.name = name;
        }

        public String GetURL()
        {
            return url;
        }

        public void SetURL(String url)
        {
            this.url = url;
        }

        public String GetTime()
        {
            return time;
        }
    }
}

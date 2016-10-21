using System;
using System.Windows.Forms;
using System.Xml;

namespace WebBrowser
{
    public class FileGetter
    {
        private String homepage;
        private History history;
        private Bookmarks bookmarks;

        private String file;

        public FileGetter(History history, Bookmarks bookmarks, String file)
        {
            this.history = history;
            this.bookmarks = bookmarks;
            this.file = file;
            GetData();
        }

        public void SetHomepage(String homepage)
        {
            this.homepage = homepage;
        }

        //Grabs data from XML file
        private void GetData()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    //Checks each XML node to determine function
                    switch (node.Name)
                    {
                        case "Bookmarks":
                            SetBookmarks(node);
                            break;
                        case "History":
                            SetHistory(node);
                            break;
                        case "Homepage":
                            homepage = node.FirstChild.InnerText;
                            break;
                    }
                }
            } catch
            {
                //If no data loaded then homepage is set to default
                //Bookmarks and history kept blank
                homepage = "http://www.google.com";
            }
        }

        //Saves data to file
        public void SaveData()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(fileXMLFormat());
                doc.Save(file);
            } catch (Exception e)
            {
                MessageBox.Show(String.Format("{0}\nFailed To Save Data\n\nXML:\n{1}", e.Message, fileXMLFormat()));
            }
        }

        //Creates complete file to save
        private String fileXMLFormat()
        {
            return String.Format("<File>{0}{1}{2}</File>", homepageToXML(), history.GetXML(), bookmarks.GetXML());
        }

        //Converts homepage string to XML string
        private String homepageToXML()
        {
            return String.Format("<Homepage>{0}</Homepage>", homepage);
        }

        //Adds bookmarks data to application from data file
        public void SetBookmarks(XmlNode node)
        {
            foreach (XmlNode websiteNode in node.ChildNodes)
            {
                String name = "";
                String url = "";
                String time = "";

                foreach (XmlNode childNode in websiteNode.ChildNodes)
                {
                    switch (childNode.Name)
                    {
                        case "Name":
                            name = childNode.FirstChild.InnerText;
                            continue;
                        case "URL":
                            url = childNode.FirstChild.InnerText;
                            continue;
                        case "Time":
                            time = childNode.FirstChild.InnerText;
                            continue;
                    }
                }
                bookmarks.Add(new Website(name, url, time));
            }
        }

        //Adds history data to application from data file
        private void SetHistory(XmlNode node)
        {
            foreach (XmlNode websiteNode in node.ChildNodes)
            {
                String name = "";
                String url = "";
                String time = "";

                foreach (XmlNode childNode in websiteNode.ChildNodes)
                {
                    switch (childNode.Name)
                    {
                        case "Name":
                            name = childNode.FirstChild.InnerText;
                            continue;
                        case "URL":
                            url = childNode.FirstChild.InnerText;
                            continue;
                        case "Time":
                            time = childNode.FirstChild.InnerText;
                            continue;
                    }
                }
                history.Add(new Website(name, url, time));
            }
        }

        public String GetHomepage()
        {
            return homepage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void GetData()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                //MessageBox.Show(String.Format("{0}", doc.DocumentElement.ToString()));
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    //MessageBox.Show(node.Name);
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
                homepage = "http://www.google.com";
            }
        }

        public void SaveData()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(fileXMLFormat());
                doc.Save(file);
                //MessageBox.Show(String.Format("{0}", fileXMLFormat()));
            } catch (Exception e)
            {
                MessageBox.Show(String.Format("{0}\n{1}", e.Message, fileXMLFormat()));
            }
        }

        private String fileXMLFormat()
        {
            return String.Format("<File>{0}{1}{2}</File>", homepageToXML(), history.GetXML(), bookmarks.GetXML());
        }

        private String homepageToXML()
        {
            return String.Format("<Homepage>{0}</Homepage>", homepage);
        }

        public void SetBookmarks(XmlNode node)
        {
            foreach (XmlNode websiteNode in node.ChildNodes)
            {
                //MessageBox.Show(websiteNode.Name);
                String name = "";
                String url = "";
                String time = "";

                foreach (XmlNode childNode in websiteNode.ChildNodes)
                {
                    //MessageBox.Show(childNode.Name);
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
                        default:
                            MessageBox.Show(childNode.InnerText);
                            continue;
                    }
                }
                bookmarks.Add(new Website(name, url, time));
            }
        }

        private void SetHistory(XmlNode node)
        {
            foreach (XmlNode websiteNode in node.ChildNodes)
            {
                String name = "";
                String url = "";
                String time = "";

                foreach (XmlNode childNode in websiteNode.ChildNodes)
                {
                    //MessageBox.Show(childNode.Name);
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

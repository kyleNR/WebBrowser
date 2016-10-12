using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Browser());
        }
    }

    struct Bookmark
    {
        String name, url;
        public Bookmark(String name, String url)
        {
            this.name = name;
            this.url = url;
        }
    }

    class WebBrowser
    {
        private List<String> history;
        private String homepage;
        private List<Bookmark> bookmarks;

        public WebBrowser()
        {

        }

        private void NewTab()
        {
            Thread thread = new Thread(new ThreadStart(newThread));
            //start new tab
            thread.Start();
            thread.Join();
        }

        private void newThread()
        {
            Tab tab = new Tab();
        }
    }

    class Tab
    {

        private List<String> tabHistory;

        public Tab()
        {

        }
    }
}

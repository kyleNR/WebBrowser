using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{

    struct HistorySlice
    {
        Website website;
        DateTime time;
        public HistorySlice (Website website, DateTime time)
        {
            this.website = website;
            this.time = time;
        }
    }

    class History
    {
        private List<HistorySlice> history;

        public History()
        {
            history = new List<HistorySlice>();
        }

        public int GetLength()
        {
            return history.Count;
        }
    }
}

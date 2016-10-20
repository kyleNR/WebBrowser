using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{
    public class TabHistory
    {

        private History history;
        private Stack<String> pastList;
        private Stack<String> futureList;

        public TabHistory(History history)
        {
            this.history = history;
            pastList = new Stack<String>();
            futureList = new Stack<String>();
        }

        public TabHistory(TabHistory oldTH)
        {
            this.history = oldTH.GetHistory();
            pastList = Duplicate(oldTH.GetPastURLStringStack());
            futureList = Duplicate(oldTH.GetFutureURLStringStack());
            //Stack<String> temp = new Stack<string>();
            //foreach(String url in oldTH.GetPastURLStringStack())
            //{
                //futureList.Push(url);
                //Reverse(pastList);
            //}
            //foreach (String url in oldTH.GetFutureURLStringStack())
            //{
                //pastList.Push(url);
                //Reverse(futureList);
            //}
        }

        public History GetHistory()
        {
            return history;
        }

        public Stack<String> GetPastURLStringStack()
        {
            return pastList;
        }

        public Stack<String> GetFutureURLStringStack()
        {
            return futureList;
        }

        public void Add(String url)
        {
            pastList.Push(url);
            futureList.Clear();
        }

        public String Forward()
        {
            if (futureList.Count > 0)
            {
                String url = futureList.Pop();
                pastList.Push(url);
                return url;
            } else
            {
                return pastList.Peek();
            }
        }

        public String Backward()
        {
            if (pastList.Count > 1)
            {
                futureList.Push(pastList.Pop());
            }
            return pastList.Peek();
        }

        private Stack<String> Duplicate(Stack<String> stack)
        {
            Stack<String> tempStack = new Stack<String>();
            while (stack.Count > 0)
                tempStack.Push(stack.Pop());
            Stack<String> outStack = new Stack<String>();
            String temp;
            while (tempStack.Count > 0)
            {
                temp = tempStack.Pop();
                stack.Push(temp);
                outStack.Push(temp);
            }
            return outStack;
        }
    }
}

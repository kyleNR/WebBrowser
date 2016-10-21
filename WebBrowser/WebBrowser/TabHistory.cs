using System;
using System.Collections.Generic;

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

        //Second constructor for duplication
        public TabHistory(TabHistory oldTH)
        {
            this.history = oldTH.GetHistory();
            pastList = Duplicate(oldTH.GetPastURLStringStack());
            futureList = Duplicate(oldTH.GetFutureURLStringStack());
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

        //Adds new URL to tab history
        public void Add(String url)
        {
            pastList.Push(url);
            futureList.Clear();
        }

        //Moves tab history forward
        public String Forward()
        {
            if (futureList.Count > 0)
            {
                //Moves URL from future stack to past stack
                pastList.Push(futureList.Pop());
            }
            return pastList.Peek();
        }

        //Moves tab history backward
        public String Backward()
        {
            if (pastList.Count > 1)
            {
                //Moves URL from past stack to future stack
                futureList.Push(pastList.Pop());
            }
            return pastList.Peek();
        }

        //Duplicate stack
        //Returns new stack with same elements as stack input
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_DerekBanas
{
    class ProcessData
    {
        public delegate int BizRulesDelegate(int x, int y);
        public void Process(int x, int y, BizRulesDelegate biz)
        {
            var result = biz(x, y);
            Console.WriteLine("Result : {0}", result);
        }

        public void ProcessAction(int x, int y, Action<int,int> act)
        {
            act(x, y);
            Console.WriteLine("Action Processed");
        }
    }
}

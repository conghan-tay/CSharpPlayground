using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_DerekBanas
{
    class Customer
    {
        public string _City { get; set; }
        public string _FirstName { get; set; }
        public string _LastName { get; set; }
        //public Customer(string City, string FirstName, string LastName)
        //{
        //    _City = City;
        //    _FirstName = FirstName;
        //    _LastName = LastName;
        //}
    }
    public enum WorkType { Coding, Manual, Service}

    public class WorkPerformedEventArgs : EventArgs
    {
        public WorkPerformedEventArgs(int hours, WorkType workType)
        {
            Hours = hours;
            WorkType = workType;
        }
        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }

   // public delegate int WorkPerformedHandler(int hours, WorkType workType);

    class Worker
    {
        //public event WorkPerformedHandler WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for(int i = 0; i < hours; ++i)
            {
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            WorkPerformed?.Invoke(this, new WorkPerformedEventArgs(hours,workType));
        }

        protected virtual void OnWorkCompleted()
        {
            WorkCompleted?.Invoke(this,EventArgs.Empty);
        }
    }

    class MyMain
    {
        static void worker_WorkPerformed(object sender, WorkPerformedEventArgs eargs)
        {
            Console.WriteLine(eargs.Hours + " " + eargs.WorkType);
        }
        //static void Main(string[] args)
        //{
        //    ProcessData pd = new ProcessData();
        //    ProcessData.BizRulesDelegate addDel = (x, y) => x + y;
        //    ProcessData.BizRulesDelegate multDel = (x, y) => x * y;
        //    pd.Process(3, 4, addDel);
        //    pd.Process(3, 4, multDel);

        //    pd.ProcessAction(5, 6, (x, y) => Console.WriteLine(" Action Add Output {0}", x + y));

        //    Action<int, int> multAction = (x, y) =>
        //    {
        //        Console.WriteLine("Action Mult Ouput {0}", x * y);
        //    };

        //    pd.ProcessAction(5, 6, multAction);

        //    var custs = new List<Customer>
        //    {
        //       // new Customer("Pheonix", "John", "Jay"),
        //        new Customer{_City = "Pheonix", _FirstName = "John", _LastName = "lan" },
        //        new Customer{_City = "Pheonix", _FirstName = "Jason", _LastName = "Jay" },
        //        new Customer{_City = "Seattle", _FirstName = "Suki", _LastName = "Loki" }
        //    };

        //    var phxCust = custs.Where(c => c._City == "Pheonix").OrderBy(c => c._FirstName);

        //    foreach(var cust in phxCust)
        //    {
        //        Console.WriteLine("Pheonix Customer " + cust._FirstName);
        //    }

        //    var worker = new Worker();
        //    worker.WorkPerformed += /*new EventHandler<WorkPerformedEventArgs>(*/worker_WorkPerformed;
        //    worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs eargs)
        //    {
        //        Console.WriteLine("From Anonymous : " + eargs.Hours + " " + eargs.WorkType);
        //    };
        //    worker.WorkCompleted += (s, e) => Console.WriteLine("Work Completed From Lambda");
        //    worker.DoWork(8, WorkType.Service);

        //    while (true)
        //    {
        //        string input = Console.ReadLine();
        //        if (input == "*")
        //        {
        //            break;
        //        }
        //        else
        //        {

        //        }
        //    }
        //}
    }
}

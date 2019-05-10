using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_DerekBanas
{
    enum DuckType { RUSTY, STALE, DIRTY }
    class Duck {
        public int _Size;
        public DuckType _Dt;
        public Duck(int Size = 0, DuckType Dt = DuckType.DIRTY)
        {
            _Size = Size;
            _Dt = Dt;
        }

        public override string ToString()
        {
            return "Size " + _Size + " Type " + _Dt.ToString();
        }
    }
    interface IFeed
    {
        void Feed();
    }

    // Constraint it so that its a class that implements IFeed
    // new() constraint ensures T has default Constructor
    class MagicPool<T> where T: class, IFeed, new()
    {
        List<T> _list;
        public MagicPool()
        {
            _list = new List<T>();
            T sm = new T();
        }

        void FeedAll()
        {
            foreach(T anim  in _list)
            {
                anim.Feed();
            }
        }
    }

    class Node<T>
    {
        public T value;
        public void Print<K>(K sm)
        {
            Console.WriteLine(sm);
        }
    }

    class DuckCompareKind : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            if(x._Dt > y._Dt)
            {
                return -1;
            }
            return 1;
        }
    }
    class ClassComparison
    {
        //static void Main(string[] args)
        //{
        //    List<Duck> DuckList = new List<Duck>();
        //    DuckList.Add(new Duck(2, DuckType.RUSTY));
        //    DuckList.Add(new Duck(2, DuckType.DIRTY));
        //    DuckList.Add(new Duck(2, DuckType.STALE));

        //    DuckCompareKind KindCompare = new DuckCompareKind();
        //    DuckList.Sort(KindCompare);
        //    foreach(Duck duck in DuckList)
        //    {
        //        duck._Size = 1;
        //        Console.WriteLine(duck);
        //    }
        //    foreach (Duck duck in DuckList)
        //    {
        //        Console.WriteLine(duck);
        //    }

        //    List<Node<dynamic>> m_list = new List<Node<dynamic>>();
        //    m_list.Add(new Node<dynamic>());
        //    m_list[0].value = 5;
        //    m_list.Add(new Node<dynamic>());
        //    m_list[1].value = "Hello";

        //    foreach (Node<dynamic> duck in m_list)
        //    {
        //        Console.WriteLine(duck.value);
        //    }
        //    m_list[1].Print(20.2);
        //}
    }
}

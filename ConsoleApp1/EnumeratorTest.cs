using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_DerekBanas
{
    public struct Person
    {
        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class People : IEnumerable
    {
        private Person[] _people;

        public People (Person[] people)
        {
            _people = new Person[people.Length];
            Array.Copy(people, _people, people.Length);
        }
        //public IEnumerator GetEnumerator()
        //{
        //    //return (IEnumerator)GetEnumerator();
        //    return _people.GetEnumerator();
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
            //return _people.GetEnumerator();
        }

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;

        int position = -1;
        object IEnumerator.Current { get {
                return Current;
            } }

        public Person Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch(IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        
        public PeopleEnum(Person[] list)
        {
            _people = list;
        }
        public bool MoveNext()
        {
            Console.WriteLine("Move NExt");
            ++position;
            return (position < _people.Length);
        }

        public void Reset()
        {
            Console.WriteLine("Reset");
            position = -1;
        }
    }


    class EnumeratorTest
    {
        //static void Main(string[] args)
        //{
        //    Person[] peopleArray = new Person[3]
        //    {
        //        new Person("John", "Smith"),
        //        new Person("Jim", "Johnson"),
        //        new Person("Sue", "Rabon"),
        //    };

        //    People peopleList = new People(peopleArray);
        //    foreach (Person p in peopleList)
        //        Console.WriteLine(p.FirstName + " " + p.LastName);

        //    IEnumerator i = peopleArray.GetEnumerator();
        //    i.MoveNext();
        //    Person myPerson = (Person)i.Current;
        //    Console.WriteLine("{0} {1}", myPerson.FirstName, myPerson.LastName);
        //}
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_DerekBanas
{
    partial class PartialClass
    {
        public void OutputName()
        {
            Console.WriteLine("Name of Obj {0}", this.name);
        }
    }
        class Animal
    {
        private string name;
        public int id;
        public Animal(string name, int id = 0)
        {
            this.name = name;
            this.id = id;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(value != "")
                    name = value;
            }
        }

        public virtual string GetSpecies()
        {
            return "Animal";
        }

        public override string ToString()
        {
            return "Animal Class with name " + this.Name;
        }

        public Animal ShallowCopy()
        {
            return (Animal)this.MemberwiseClone();
        }

        public Animal DeepCopy()
        {
            Animal temp = ShallowCopy();
            temp.Name = String.Copy(Name);
            return temp;
        }
    }

    // C# only has public inheritance
    class Dog : Animal
    {
        public Dog(string name) :base(name)
        {
        }

        // new hides base class member definition
        // so no polymorphism
        //public new string GetSpecies()
        //{
        //    return "Dog";
        //}

        public override string GetSpecies()
        {
            return "Dog";
        }
    }

    struct BaseStruct
    {
        public int x;
    }
    

    abstract class X
    {
        public int x;
        public X(int num = 0)
        {
            this.x = num;
        }

        public virtual void OutPutNum()
        {
            Console.WriteLine("OuputNum from X {0}", this.x);
        }

        // Cannot declare body;
        public abstract void OutputClass(); 
    }

    class YPrivate : X
    {
        public int y;
        public YPrivate(int x, int y)
            : base(x)
        {
            this.y = y;
        }

        public override void OutputClass()
        {
            Console.WriteLine("Class is {0}", "Y Private Class");
        }

        /* Cannot change access modifiers*/
        //private override void OutPutNum()
        //{
        //    Console.WriteLine("OuputNum from Y {0}", this.x * this.y);
        //}
    }

    class Y : X
    {
        public int y;
        public Y(int x, int y) 
            :base(x)
        {
            this.y = y;
        }

        // Prevents child to override this fnc
        public sealed override void OutPutNum()
        {
            Console.WriteLine("OuputNum from Y {0}", this.x * this.y);
        }

        public override void OutputClass()
        {
            Console.WriteLine("Class is {0}", "Y Class");
        }
    }

    class Z : Y
    {
        public Z(int x, int y)
            :base(x,y)
        {

        }

        public override void OutputClass()
        {
            Console.WriteLine("Inherited From : ");
            base.OutputClass();
        }
    }

    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Enter Name:");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Name is  " + name);

        //    // anotherName is  string
        //    var anotherName = "Tom";
        //    Console.WriteLine("Another Name is a {0}", anotherName.GetTypeCode());
        //}
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("5.2%3= " + (5.2 % 3));
        //    Console.WriteLine("5/3= " + (5 /2));
        //    Console.WriteLine("Math.Ceiling 5.1 "+ Math.Ceiling(5.1));
        //}

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("5.2%3= " + (5.2 % 3));
        //    Console.WriteLine("5/3= " + (5 / 2));
        //    Console.WriteLine("Math.Ceiling 5.1 " + Math.Ceiling(5.1));
        //    string sampString = "A bunch of random words";
        //    Console.WriteLine("Index of bunch {0}", sampString.IndexOf("bunch"));
        //    Console.WriteLine("Same " + ("A" == "A"));
        //}
        //static void Main(string[] args)
        //{
        //    int[] my_array = { 1, 2, 3, 4, 5 };
        //    int my_arrayLength = my_array.Length;
        //    int[,] multArray = new int[5, 3];
        //    int[,] multArray2 = { { 0, 1 }, { 4, 5 } };
        //}

        static void SquareCopy(int x)
        {
            x *= x;
            Console.WriteLine("Value in Sqaure Copy {0}", x);
        }

        static void SquareRef(ref int x)
        {
            x += 10;
            Console.WriteLine("Value in Sqaure Copy {0}", x);
        }

        static void ChangeAnimal(Animal anim)
        {
            anim.Name = "anim_01_UpdatedChangeAnim";
        }

        static void SwapInts(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        // Not running asyn. running sync, becos Console blocks??
        /*
        static bool DoneWaiting = false;
        static async Task Waiting()
        {

            await Output();
            await Console.Out.WriteLineAsync("Done with Output");
            DoneWaiting = true;
        }

        static async Task Output(double dt = 2.0, int count = 5)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            int i = 0;
            double timePassed;
            while (i < count)
            {
                timePassed = stopwatch.ElapsedMilliseconds / 1000.0;
                if (timePassed > dt)
                {
                    stopwatch.Restart();
                    Console.Out.WriteLineAsync(i + " iter done");
                    ++i;
                }
            }
        }

        // Test Async
        static void Main(string[] args)
        {
            while (!DoneWaiting)
            {
                Waiting();
            }
        }
        */
        //static void Main(string[] args)
        //{
        //    Animal anim = new Animal("Spark");
        //    Animal dooger = new Dog("Dooger");

        //    Console.WriteLine("Animal is  {0}, Dooger is {1}", anim.GetSpecies(), dooger.GetSpecies());

        //    PartialClass pc = new PartialClass();
        //    pc.Name = "TEstPartial";
        //    pc.OutputName();

        //    // Instantiate Abstract will fail
        //    //X new_x = new X();

        //    X something = new Z(5, 6);
        //    something.OutPutNum();
        //    something.OutputClass();

        //    Animal anim_a = new Animal("anim_01");
        //    Animal anim_b = anim_a;
        //    anim_b.Name = "anim_01_Updated";

        //    Console.WriteLine("Anim To String {0}", anim_b);
        //    Console.WriteLine("Anim To String {0}", anim_a);

        //    ChangeAnimal(anim_a);
        //    Console.WriteLine("Anim To String {0}", anim_a);

        //    int x = 10;
        //    SquareCopy(x);
        //    Console.WriteLine("Value Outside {0}", x);
        //    SquareRef(ref x);
        //    Console.WriteLine("Value Outside {0}", x);

        //    int y = 88;
        //    Console.WriteLine("x {0}, y {1}", x, y);
        //    SwapInts(ref x, ref y);
        //    Console.WriteLine("x {0}, y {1}", x, y);

        //    Animal shallow_anim = anim_a.ShallowCopy();
        //    Animal deep_anim = anim_a.DeepCopy();

        //    shallow_anim.Name = "ShallowAnim";
        //    Console.WriteLine("Anim To String {0}", anim_a);
        //    deep_anim.Name = "DeepAnim";
        //    Console.WriteLine("Anim To String {0}", anim_a);

        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_DerekBanas
{
    interface ISampleInterface
    {
        int x { get; set; }
        int y { get; set; }

        Tuple<int, int> move(Tuple<int, int> moveAmt);
    }

    interface Movement
    {
        int x { get; set; }
        int y { get; set; }

        Tuple<int, int> move(Tuple<int, int> moveAmt);
    }

    class Player : ISampleInterface, Movement
    {
        // Auto properties, only need to define property and C# will generate field
        //public int x { get; set; } = 0;
        //public int y { get; set; } = 1;

        public int x { get; set; } = 0;
        public int y { get; set; } = 1;

        int Movement.x { get; set; } = 2;
        int Movement.y { get; set; } = 2;

        public Tuple<int, int> move(Tuple<int, int> moveAmt)
        {
            x += moveAmt.Item1;
            y += moveAmt.Item2;
            return new Tuple<int, int>(x,y);
        }

        Tuple<int, int> Movement.move(Tuple<int, int> moveAmt)
        {
            ((Movement)this).x += moveAmt.Item1;
            ((Movement)this).y += moveAmt.Item1;

            return new Tuple<int, int>(((Movement)this).x, ((Movement)this).y);
        }

        public override string ToString()
        {
            return "x: " + x + " y: " + y;
        }
    }

    class HeadFirst
    {
        /*
        static void Main(string[] args)
        {
            Player MainPlayer = new Player();
            //MainPlayer.move(new Tuple<int, int>(5, 5));

            ISampleInterface MainPlayerRef = MainPlayer;
            Movement MainPlayerMovement = MainPlayer;

            MainPlayerMovement.move(new Tuple<int, int>(3, 4));
            Console.WriteLine(MainPlayerMovement.x);
            Console.WriteLine(MainPlayer);
            Console.WriteLine(MainPlayerMovement);
            Console.WriteLine(MainPlayerRef);
        }
        */
    }
}

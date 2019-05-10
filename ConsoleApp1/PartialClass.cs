using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_DerekBanas
{
    partial class PartialClass
    {
        private string name;
        public string Name { get { return this.name; } set { this.name = value; } }
    }

    class TestInternal1
    {
        public static int num;
        internal static int i_num = 0;
    }
    
    class AccessInternal1
    {
        static int GetInternal()
        {
            return TestInternal1.i_num;
        }
    }
}

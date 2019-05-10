using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ConsoleApp_DerekBanas
{
    [DataContract]
    class Guy
    {
        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public int Age { get; private set; }

        public Guy(string name = "no_name", int age = 10)
        {
            Name = name;
            Age = age;
        }
    }
    //class RandomStuff
    //{
    //    static void Main()
    //    {
    //        bool? myBool = null;
    //    }
    //}

    public class XMLWrite
    {

        //static void Main(string[] args)
        //{
        //    WriteXML();
        //}

        public class Book
        {
            public String title;
        }

        public static void WriteXML()
        {
            Book overview = new Book();
            overview.title = "Serialization Overview";
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, overview);
            file.Close();
        }
    }
}

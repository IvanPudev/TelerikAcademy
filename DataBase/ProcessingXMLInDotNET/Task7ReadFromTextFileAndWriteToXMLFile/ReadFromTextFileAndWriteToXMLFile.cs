using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task7ReadFromTextFileAndWriteToXMLFile
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader txtReader = new StreamReader("../../Person.txt");
            Person person = new Person();
            List<Person> persons = new List<Person>();
            string line;
            int count = 1;
            using (txtReader)
            {
                while ((line = txtReader.ReadLine()) != null)
                {
                    
                    if (count % 3 == 1)
                    {
                        person.Name = line;
                    }
                    if (count % 3 == 2)
                    {
                        person.Address = line;
                    }
                    else
                    {
                        person.Phone = line;
                        persons.Add(person);
                    }
                    
                    count++;
                    
                    
                }
                    
            }

            XmlTextWriter writer = new XmlTextWriter("../../person.xml", Encoding.GetEncoding("windows-1251"));
            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("Persons");
                writer.WriteAttributeString("name", "Persons");
                foreach (var p in persons)
                {
                    WritePerson(writer, p.Name, p.Address, p.Phone);
                }
                
            }
            Console.WriteLine();
        }

        static void WritePerson(XmlWriter writer, string name, string address, string phone)
        {
            writer.WriteStartElement("person");
            writer.WriteElementString("name", name);
            writer.WriteElementString("address", address);
            writer.WriteElementString("phone", phone);
        }

        //static void Main()
        //{
        //    string fileName = "../../Person.txt";

        //    var filestream = new FileStream(fileName,
        //                        FileMode.Open,
        //                        FileAccess.Read,
        //                        FileShare.ReadWrite);
        //    var fileReader = new StreamReader(filestream, Encoding.UTF8, true, 128);
        //    XElement personXml = new XElement("persons");
        //    string name = "";
        //    string address = "";

        //    using (fileReader)
        //    {
        //        string line;
        //        int count = 1;
        //        while ((line = fileReader.ReadLine()) != null)
        //        {
        //            if (count % 3 == 1)
        //            {
        //                name = line;
        //            }
        //            else if (count % 3 == 2)
        //            {
        //                address = line;
        //            }
        //            else
        //            {
        //                var phone = line;

        //                personXml.Add(new XElement("person",
        //           new XElement("name", name),
        //           new XElement("address", address),
        //           new XElement("phone", phone)
        //   ));
        //            }
        //            count++;
        //        }
        //    }

        //    System.Console.WriteLine(personXml);
        //    personXml.Save("../../person.xml");
        //}
    }
}

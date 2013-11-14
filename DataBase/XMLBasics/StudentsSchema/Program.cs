using System;
using System.Linq;
using System.Xml.Xsl;

namespace StudentsSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            XslCompiledTransform xslTransform = new XslCompiledTransform();
            xslTransform.Load("../../Students.xslt");
            xslTransform.Transform("../../Students.xml", "../../Students.html");
        }
    }
}

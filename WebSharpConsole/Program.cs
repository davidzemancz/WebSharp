using System;
using System.IO;
using WebSharp.Html;
using WebSharp.Data;

namespace WebSharpConsole
{
    internal class Program
    {
        public class TestVariableDataProvider : IDataProvider
        {
            public object GetValue(string name)
            {
                if (name == "Name") return "Pepa";
                else if (name == "Surname") return "Novak";
                return "";
            }

            public void SetValue(string name, object value)
            {

            }
        }

        static void Main(string[] args)
        {
            string filename = "variables";
            string sourceFile = $@"TestHtmlFiles\{filename}.html";
            Console.WriteLine($"Source file {sourceFile}.");
            using TextReader reader = new StreamReader(sourceFile);

            string targetFile = sourceFile.Replace(".html", ".out.html");
            Console.WriteLine($"Target file {targetFile}.");
            using TextWriter writer = new StreamWriter(targetFile);

            Console.WriteLine($"Build started.");
            Page page = new Page(reader, writer);
            page.Build(new TestVariableDataProvider());
            Console.WriteLine($"Build completed.");
        }
    }
}
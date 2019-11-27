using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Handlers
{
    public class HandlersFileGenerator
    {
        public void Generate(string content,string name, string path = "")
        {
            using (var sw = File.CreateText($"{path}{name}"))
            {
                sw.Write(content);
            }
        }
    }
}

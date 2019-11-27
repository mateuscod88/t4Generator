using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Entities
{
    public class LiquiBaseFileGenerator
    {
        public void Generate<T>(string content)
        {
            using (var sw = File.CreateText($"{typeof(T).Name}.xml"))
            {
                sw.Write(content);
            }
        }
    }
}

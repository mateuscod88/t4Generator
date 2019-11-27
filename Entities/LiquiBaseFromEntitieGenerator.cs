using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class LiquiBaseFromEntitieGenerator
    {
        public void Generator<T>()
        {
            PropertiesGenerator p = new PropertiesGenerator();
            var propertys = p.Generate<T>();
            JsonEntitie je = new JsonEntitie(typeof(T).Name);
            je.Properties = propertys;
            var content = je.TransformText();
            new LiquiBaseFileGenerator().Generate<T>(content);
        }
    }
}

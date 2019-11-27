using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class PropertiesGenerator
    {
        private readonly string _className;

        public PropertiesGenerator(string className)
        {
            _className = className;
        }
        public PropertiesGenerator()
        {

        }
        public List<SinglePropertie> Generate<T>()
        {
            Type type = Type.GetType(typeof(T).FullName);
            var properties = type.GetProperties();
            var customProperties = new List<SinglePropertie>();
            foreach (var item in properties)
            {
                var singlePropertyType = item.Name.ToLower().Contains("id") ? CSharpToLiquiBaseMappings.Mappings["stringId"] : CSharpToLiquiBaseMappings.Mappings[item.PropertyType.Name.ToLower()];
                var singlePropertieConstrain = item.Name.ToLower() == "id" ? @"<constraints primaryKey='true'/>" : "<constraints nullable='true'/>";
                var additional = item.PropertyType.Name.ToLower() == "boolean" ? "defaultValueBoolean='false'": "";
                var singleProperty = new SinglePropertie { Name = item.Name, Type = singlePropertyType, Constraints = singlePropertieConstrain ,Additional = additional};
                customProperties.Add(singleProperty);
                Console.WriteLine(item.Name);
            }
            return customProperties;
        }
        
    }
}

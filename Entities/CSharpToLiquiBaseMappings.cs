using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public static class CSharpToLiquiBaseMappings
    {
        private static Dictionary<string, string> _mappings = new Dictionary<string, string> ();
        static  CSharpToLiquiBaseMappings()
        {
            _mappings.Add("string", "varchar(100)");
            _mappings.Add("stringId", "varchar(36)");
            _mappings.Add("datetime", "timestamp with time zone"); 
            _mappings.Add("boolean", "boolean");
            _mappings.Add("typnotatki", "varchar(16)");
        }
        public static Dictionary<string, string> Mappings => _mappings;
    }
}

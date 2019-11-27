using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    partial class JsonEntitie
    {
        public List<SinglePropertie> Properties { get; set; }
        public string _tableName { get; set; }
        public JsonEntitie(string tableName)
        {
            _tableName = tableName;
        }
    }
}

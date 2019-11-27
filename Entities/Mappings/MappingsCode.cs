using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Mappings
{
    public partial class Mappings
    {
        public string _nameSpace { get; set; }
        public string _name { get; set; }

        public Mappings(string nameSpace, string name)
        {
            _nameSpace = nameSpace;
            _name = name;
        }

    }
}

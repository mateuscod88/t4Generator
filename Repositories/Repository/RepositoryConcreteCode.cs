using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repository
{
    public partial class RepositoryConcrete
    {
        public string _nameSpace { get; set; }
        public string _name { get; set; }
        public string _operationName { get; set; }
        public RepositoryConcrete(string nameSpace, string name, string operationName)
        {
            _nameSpace = nameSpace;
            _name = name;
            _operationName = operationName;
        }
    }
}

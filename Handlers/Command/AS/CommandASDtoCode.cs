using System;
using System.Collections.Generic;
using System.Text;

namespace Handlers.Command.AS
{
    public partial class CommandASDto
    {
        public string _operationName { get; set; }

        public string _nameSpace { get; set; }
        public string  _name { get; set; }

        public CommandASDto(string nameSpace, string name, string operationName)
        {
            _nameSpace = nameSpace;
            _name = name;
            _operationName = operationName;
        }
    }
}

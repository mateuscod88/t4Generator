using System;
using System.Collections.Generic;
using System.Text;

namespace Handlers.Command.DS
{
    partial class CommandDSDto
    {
        public string _nameSpace { get; set; }
        public string _name { get; set; }
        public string _operationName { get; set; }
        public CommandDSDto(string nameSpace, string name, string operationName)
        {
            _nameSpace = nameSpace;
            _name = name;
            _operationName = operationName;
        }
    }

}

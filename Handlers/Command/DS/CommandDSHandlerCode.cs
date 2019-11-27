using System;
using System.Collections.Generic;
using System.Text;

namespace Handlers.Command.DS
{
    partial class CommandDSHandler
    {
        public string _nameSpace { get; set; }
        public string _name { get; set; }
        public string _operationName { get; set; }
        public CommandDSHandler(string nameSpace, string name,string operationName)
        {
            _nameSpace = nameSpace;
            _name = name;
            _operationName = operationName;
        }
    }
}

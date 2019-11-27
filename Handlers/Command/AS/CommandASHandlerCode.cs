using System;
using System.Collections.Generic;
using System.Text;

namespace Handlers.Command.AS
{
    public partial class CommandASHandler
    {
        private readonly string _nameSpace;
        private readonly string _name;
        private readonly string _operationName;

        public CommandASHandler(string nameSpace,string name, string operationName)
        {
            _nameSpace = nameSpace;
            _name = name;
            _operationName = operationName;
        }

    }
}

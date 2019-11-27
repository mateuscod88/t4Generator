using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.IRepository
{
    public partial class RepositoryInterface
    {
        public string _nameSpace { get; set; }
        public string _name { get; set; }
        ///<summary>
        ///<para>Operation Name</para>
        /// example : "command" or "query"
        /// <see cref="Entities.TypNotatki"/>
        /// </summary>

        public string _operationName { get; set; }

        public RepositoryInterface(
            string nameSpace,
            string name,
            string operationName)
        {
            _nameSpace = nameSpace;
            _name = name;
            _operationName = operationName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MongoDB.Component.Persistence
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class MongoDatabaseAttribute : Attribute
    {
        public string DatabaseName { get; }
        public MongoDatabaseAttribute(string dataBaseName)
        {
            DatabaseName = dataBaseName;
        }
    }
}

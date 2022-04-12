using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gadgets.Application.Common.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string name, object key)
            : base($"Entity \"{name}\" ({key}) not found")
        {

        }
    }
}

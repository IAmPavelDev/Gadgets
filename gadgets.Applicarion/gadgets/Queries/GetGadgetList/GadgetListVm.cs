using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gadgets.Application.gadgets.Queries.GetGadgetList
{
    public class GadgetListVm
    {
        public IList<GadgetLookupDto> gadgets { get; set; }
    }
}

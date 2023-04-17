using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCompany.Shared.Requests
{
    public class PageRequest
    {
        public int Page{ get; set; }
        public int PageSize { get; set; }
    }
}

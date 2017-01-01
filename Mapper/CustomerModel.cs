using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperSample
{
    public class CustomerModel
    {
        public int ClientId { get; set; }
        public string fName { get; set; }
        public string fLastName { get; set; }
        public string fEmail { get; set; }
        public string CreationDate { get; set; }
        public string Password { get; set; }
    }
}

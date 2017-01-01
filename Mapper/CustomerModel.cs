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
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CreationDate { get; set; }
        public string Password { get; set; }
    }
}

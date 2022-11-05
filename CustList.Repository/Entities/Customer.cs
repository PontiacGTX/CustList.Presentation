using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustList.Entities.Entities
{
    public class Customer
    {
        [Key]
        public int cId { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public IList<CustomerPhone> CustomerPhones { get; set; }

    }
}

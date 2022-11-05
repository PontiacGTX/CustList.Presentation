using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustList.Entities.Entities
{
    public  class CustomerPhone
    {
        [Key]
        public int cpId { get; set; }
        public string cpPhone { get; set; }
        public int cId { get; set; }
        [ForeignKey("cId")]
        public Customer Customer { get; set; }
    }
}

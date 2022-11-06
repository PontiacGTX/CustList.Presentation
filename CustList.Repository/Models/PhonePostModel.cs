using CustList.Entities.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustList.Entities.Models
{
    public  class PhonePostModel
    {
        public int cId { get; set; }
        [MaxLength(20)]
        [PhoneValidation("El numero de telefono no es valido")]
        public string Phone { get; set; }
    }
}

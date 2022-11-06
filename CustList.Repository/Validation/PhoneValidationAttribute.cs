using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustList.Entities.Validation
{
    internal class PhoneValidationAttribute:ValidationAttribute
    {
        public PhoneValidationAttribute(string error)
        {
            ErrorMessage = error;
        }
        public override bool IsValid(object? value)
        {
            if(value == null)
                return false;

            return System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), "^[0-9]*$");
        }
    }
}

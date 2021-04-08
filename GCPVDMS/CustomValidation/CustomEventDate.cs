using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GCPVDMS.CustomValidation
{
    public class CustomEventDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            DateTime yesterday = DateTime.Now.AddDays(-3);
            return dateTime > yesterday;
        }
    }

}

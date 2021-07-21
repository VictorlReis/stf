using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Dtos
{
    public class PersonPhoneUpdateDto
    {
        public int BusinessEntityID { get; set; }

        public string OldPhoneNumber { get; set; }
        public string PhoneNumber { get; set; }

        public int PhoneNumberTypeID { get; set; }
    }
}

using Examples.Charge.Application.Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Messages.Response
{
    public class PersonPhoneEditResponse : BaseResponse
    {
        public string PhoneNumber { get; set; }
    }
}

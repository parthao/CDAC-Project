using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBackEndAPI.Models
{
    public class ForgetPassword
    {
        public string email { get; set; }
        public string pass { get; set; }
        public int OTP { get; set; }
    }
}
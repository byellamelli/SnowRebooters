using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckAging.Models
{
    public class Email
    {
        public string toEmail { get; set; }

        public string Payee { get; set; }

        public string IssuedDate { get; set; }
    }
}
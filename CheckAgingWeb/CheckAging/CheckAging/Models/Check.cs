using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckAging.Models
{
    public class Check
    {
        public int Id { get; set; }

        public string DateIssued { get; set; }

        public string DateCleared { get; set; }

        public decimal Amount { get; set; }

        public string Payee { get; set; }

        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int ReviewCount { get; set; }

        public string ReviewedBy { get; set; }


    }
}

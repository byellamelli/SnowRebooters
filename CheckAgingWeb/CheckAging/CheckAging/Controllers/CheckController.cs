using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckAging.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheckAging.Controllers
{
    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Check> GetChecks()
        {
            // ToDo: business logic to pull out checks from database

            // hard code
            List<Check> lCheck= new List<Check>();
            lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com"});
            lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });

            return lCheck;
        }

    }
}

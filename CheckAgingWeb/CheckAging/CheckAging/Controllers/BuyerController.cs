using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckAging.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheckAging.Controllers
{
    [Route("api/[controller]")]
    public class BuyerController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Buyer> GetBuyers()
        {
            // ToDo: business logic to pull out buyer from database

            // hard code
            List<Buyer> lBuyer = new List<Buyer>();
            lBuyer.Add(new Buyer() { Id = 1, Name = "Tommy" });
            lBuyer.Add(new Buyer() { Id = 1, Name = "Norm" });
            lBuyer.Add(new Buyer() { Id = 1, Name = "Ken" });
            lBuyer.Add(new Buyer() { Id = 1, Name = "Bhavani" });

            return lBuyer;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CheckAging.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CheckAging.Controllers
{
    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        private readonly IConfiguration configuration;

        public CheckController(IConfiguration config)
        {
            configuration = config;
        }
        [HttpGet("[action]")]
        public IEnumerable<Check> GetChecks()
        {
             List<Check> lCheck= new List<Check>();
            
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var command = new SqlCommand("GetCheckData", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();

            using (SqlDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Check c = new Check();
                    c.DateIssued = Convert.ToDateTime(rdr["dateIssued"]);
                    c.DateCleared = Convert.ToDateTime(rdr["dateCleared"]);
                    c.Amount = Decimal.Parse(rdr["amount"].ToString());
                    c.Payee = rdr["name"].ToString();
                    c.PhoneNumber = rdr["Phone"].ToString();
                    c.EmailAddress = rdr["email"].ToString();
                    lCheck.Add(c);
                }
                connection.Close();
            }
            
            return lCheck;
        }

    }
}

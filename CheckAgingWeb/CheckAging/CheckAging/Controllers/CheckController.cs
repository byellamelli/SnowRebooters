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
            // ToDo: business logic to pull out checks from database

            // hard code
            List<Check> lCheck= new List<Check>();
            //lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com"});
            //lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            //lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            //lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            //lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            //lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            //lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            //lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            //lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            //lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });
            //lCheck.Add(new Check() { Id = 1, DateIssued = "01/02/2005", DateCleared = "01/02/2005", Amount = "$120", PhoneNumber = "801-998-9876", EmailAddress = "test1@gmail.com" });

            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            var command = new SqlCommand("GetCheckData", connection);
            command.CommandType = CommandType.StoredProcedure;
            // command.Parameters.AddWithValue("@WeatherID", 1);

            connection.Open();

            //List<Check> listWeather = new List<Check>();

            using (SqlDataReader rdr = command.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    Check c = new Check();

                    // c.Id = Convert.ToInt32(rdr["Id"]);
                    c.DateIssued = rdr["dateIssued"].ToString();
                    c.DateCleared = rdr["dateCleared"].ToString();
                    c.Amount = rdr["amount"].ToString();
                    // c.Payee = rdr["Id"].ToString();
                    c.PhoneNumber = rdr["Phone"].ToString();
                    c.EmailAddress = rdr["email"].ToString();

                    lCheck.Add(c);
                    // Console.WriteLine("Product: {0,-35} Total: {1,2}", rdr["ProductName"], rdr["Total"]);

                }



                // command.ExecuteNonQuery();

                connection.Close();
            }
            
            return lCheck;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CheckAging.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

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
            List<Check> lCheck = new List<Check>();

            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var command = new SqlCommand("GetCheckData", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();

            using (SqlDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Check c = new Check();
                    c.DateIssued = (Convert.ToDateTime(rdr["dateIssued"]).ToString("MM/dd/yyyy"));
                    c.DateCleared = (Convert.ToDateTime(rdr["dateCleared"]).ToString("MM/dd/yyyy"));
                    if (c.DateCleared == "01/01/1900")
                        c.DateCleared = "";
                    c.Amount = Decimal.Parse(rdr["amount"].ToString());
                    c.Payee = rdr["name"].ToString();
                    c.PhoneNumber = rdr["Phone"].ToString();
                    c.EmailAddress = rdr["email"].ToString();
                    c.ReviewCount = Convert.ToInt32(rdr["reviewCount"]);
                    c.ReviewedBy = rdr["reviewedBy"].ToString();
                    lCheck.Add(c);
                }
                connection.Close();
            }
            return lCheck;
        }

        [HttpPost("[action]")]
        public async Task SendanEmailAsync(string toEmail, string Payee, string IssuedDate)
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"<div><p><b>Hello {Payee}! Your check is not cashed yet. What is going on?</b></p></div>");
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine($"<div><p>Please let us know if you have the received the check we sent to you on {IssuedDate}. If not you can reach us at snowrebooters@avidxchange.com</p></div>");
                sb.AppendLine(string.Format("<div><p>Contact: 800-909-9999 </p></div>"));

                string emailbody = sb.ToString();
                string subject = "Reminder to cash your CHECK!";               

                var client = new SendGridClient("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");
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("snowrebooters@avidxchange.com"),
                    Subject = subject,
                    PlainTextContent = "",
                    HtmlContent = emailbody
                };
                msg.AddTo(new EmailAddress(toEmail));  

                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {

            }  
        }
    }
}

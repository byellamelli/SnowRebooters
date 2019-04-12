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
        public void SendanEmail(string toEmail)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("<div><p><b>Hello Norm, Your checks not cashed yet. What is going on?</b></p></div>"));
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine(string.Format("<div><p>Please let us know if you have the received the check we sent on Jan 22, 2019. If not you can reach us at ouremail@avidxchange.com</p></div>"));
                sb.AppendLine(string.Format("<div><p>Contact: 800-909-9999 </p></div>"));

                string emailbody = sb.ToString();
                string toaddress = toEmail;
                string fromaddress = "snowrebooters@avidxchange.com";
                string subject = "Reminder to cash your CHECK!";

                MailMessage mail = new MailMessage(toEmail, fromaddress);
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;               
                mail.Subject = subject;
                mail.Body = emailbody;
                //client.Port = 25;
                //client.Host = "smtp.gmail.com";
                client.Send(mail);
            }
            catch (Exception ex)
            {

            }  
        }
    }
}

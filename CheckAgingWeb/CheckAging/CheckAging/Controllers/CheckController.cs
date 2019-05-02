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
        public IEnumerable<Check> GetChecks(string days)
        {
            List<Check> lCheck = new List<Check>();
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var command = new SqlCommand("GetCheckData", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@days", days != null ? Convert.ToInt32(days) : Convert.ToInt32(0));
            connection.Open();
            
            using (SqlDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Check c = new Check();
                    c.DateIssued = (Convert.ToDateTime(rdr["dateIssued"]).ToString("MM/dd/yyyy"));
                    c.DateCleared = rdr["dateCleared"].ToString() != "" ? (Convert.ToDateTime(rdr["dateCleared"]).ToString("MM/dd/yyyy")): "";
                    if (c.DateCleared == "01/01/1900")
                        c.DateCleared = "";
                    c.Amount = Decimal.Parse(rdr["amount"].ToString());
                    c.Payee = rdr["name"].ToString();
                    c.PhoneNumber = rdr["Phone"].ToString();
                    c.EmailAddress = rdr["email"].ToString();
                    c.ReviewCount = Convert.ToInt32(rdr["reviewCount"]);
                    lCheck.Add(c);
                }
                connection.Close();
            }
            return lCheck;
        }
        [HttpPost("[action]")]
        public async Task SendanEmailAsync([FromBody]Email emailobject)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"<div><p><b>Hello {emailobject.Payee}! Your check is not cashed yet. What is going on?</b></p></div>");
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine($"<div><p>Please let us know if you have the received the check we sent to you on {emailobject.IssuedDate}. If not you can reach us at snowrebooters@avidxchange.com</p></div>");
                sb.AppendLine(string.Format("<div><p>Contact: 800-909-9999 </p></div>"));

                string emailbody = sb.ToString();
                string subject = "Reminder to cash your CHECK!";               

                var client = new SendGridClient("");
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("snowrebooters@avidxchange.com"),
                    Subject = subject,
                    PlainTextContent = "",
                    HtmlContent = emailbody
                };

                //Attachment att = new Attachment(new MemoryStream(myBytes), name);
                // Add attachment as txt/plain

                byte[] byteData = Encoding.ASCII.GetBytes("");
                msg.Attachments = new List<SendGrid.Helpers.Mail.Attachment>
                {
                    new SendGrid.Helpers.Mail.Attachment
                    {
                        Content = Convert.ToBase64String(byteData),
                        Filename = "Transcript.pdf",
                        Type = "txt/plain",
                        Disposition = "attachment"
                    }
                };
                msg.AddTo(new EmailAddress(emailobject.toEmail));  
                var response = await client.SendEmailAsync(msg);


                Int32 reviewCount = 0;
                Int32 checkId = 0;

               

        var selectString = "select chk.checkId, chk.reviewCount From [dbo].[checks] as chk" +
                          " INNER JOIN dbo.payments as p on p.paymentId=chk.paymentId" +
                          " INNER JOIN dbo.payee as pe on pe.payeeId=p.payeeId " +
                          " Where pe.email = @toEmail";


                var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));              
                SqlCommand command = new SqlCommand(selectString, connection);

                connection.Open();
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@toEmail", emailobject.toEmail);


                SqlDataReader reader = command.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                         checkId = reader.GetInt32(0);
                         reviewCount = reader.GetInt32(1);
                    }
                    reader.NextResult();
                }
                connection.Close();


                reviewCount++;
                var updateString = "update [dbo].[checks] SET reviewCount = "+  reviewCount  + " WHERE checkId = " + checkId;
                SqlCommand cmd = new SqlCommand(updateString, connection);
                connection.Open();

                cmd.ExecuteNonQuery();

                //GetChecks();
            }
            catch (Exception ex)
            {

            }  
        }
    }
}

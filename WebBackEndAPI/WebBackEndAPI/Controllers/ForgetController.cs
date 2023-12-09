using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebBackEndAPI.Models;
namespace WebBackEndAPI.Controllers
{
    static class Global
    {
        public static int MyOTP = 0;

    }
    

    [EnableCors("*", "*", "*")]
    public class ForgetController : ApiController
    {
        ProjectEntities3 db = new ProjectEntities3();
       

        [ResponseType(typeof(Object))]
        [Route("api/ForgetPass")]
        [HttpPost]
        public IHttpActionResult ForgetPass([FromBody] ForgetPassword credentials)
        {
           

            var user = from u in db.user_db
                           where u.email == credentials.email
                           select u.email;

            var result = user.FirstOrDefault();

            if (result == credentials.email)
            {
                
                return Ok(otpVerification(credentials.email,OTP()));
            }
            else
            {
                return NotFound();
            }

            //return Ok("Otp Send To your email successfully!!");

        }

        [ResponseType(typeof(Object))]
        [Route("api/OTPMatch")]
        [HttpPut]
        public IHttpActionResult MatchOTP([FromBody] ForgetPassword Otp)
        {
            user_db user = db.user_db.Single(c => c.email == Otp.email);
            

            if (Global.MyOTP == Otp.OTP)
            {
                user.pass_w = Otp.pass;
                
                db.SaveChanges();
                return Ok("Change");
            }
            else
            {
                return NotFound();
            }

            //return Ok("Otp Send To your email successfully!!");

        }

        public int OTP()
        {
            var random = new Random();
            var value = random.Next(1111,9999);
            return value;
        }
       

        public string otpVerification( String email ,int OTP)
        {
            Global.MyOTP = OTP;
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "timelesstreasuredac@gmail.com";
            string smtpPassword = "nmdrgwlkekybhgtz";

            // Create the email message
            MailMessage message = new MailMessage();
            message.From = new MailAddress(smtpUsername);
            message.To.Add(email);
            message.Subject = "Verification Code";
            message.Body = $"Your verification code is: {OTP}  please do not share this with anyone";

            // Configure the SMTP client
            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = true;

            // Send the email
            smtpClient.Send(message);

            return ("found");
        }
    }
}

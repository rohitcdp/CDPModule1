using System.Net.Mail;

namespace CDPModule1.Server.Utils
{
    public class MailSender
    {
        private readonly IConfiguration _configuration;

        public MailSender(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task<string> SendForgotPasswordLink(string email)
        {
            string fromMail =  _configuration.GetSection("MailSender:FromMail").Value;
            string password = _configuration["MailSender:Password"];
            string toMail = email;
            string link = "<p>https://localhost:7031/forgotPassword/" + email + "_" + DateTime.Now+"</p>";
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(toMail);
                mail.From = new MailAddress(fromMail,"CDP", System.Text.Encoding.UTF8);
                mail.Subject = "Forgot Password link";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = link;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false ;
                client.Credentials = new System.Net.NetworkCredential(fromMail, password,"gmail");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                await client.SendMailAsync(mail);
                return StatusConstant.SUCCESS;
            }catch(Exception ex)
            {
                return StatusConstant.FAILED;
            }
        }

        public async Task<string> SendEmailVerificationLink(string email)
        {
            string fromMail =  _configuration.GetSection("MailSender:FromMail").Value;
            string password = _configuration["MailSender:Password"];
            string toMail = email;
            string link = "<p>https://localhost:7031/emailVerfify/" + email + "_" + DateTime.Now + "</p>";
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(toMail);
                mail.From = new MailAddress(fromMail, "CDP", System.Text.Encoding.UTF8);
                mail.Subject = "Verify Email";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = link;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(fromMail, password, "gmail");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                await client.SendMailAsync(mail);
                return StatusConstant.SUCCESS;
            }
            catch (Exception ex)
            {
                return StatusConstant.FAILED;
            }
        }
    }
}

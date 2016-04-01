using System.Net;
using System.Net.Mail;

namespace BusinessLogicLayout.Functions.EventHandlers
{
    public class EmailHandler
    {
        public bool SendEmail(string mailTo, string subject, string mailText)
        {
            var mailFrom = Properties.Settings.Default.Email;
            var mailPassword = Properties.Settings.Default.EmailPassword;
            var newMessage = new MailMessage();
            newMessage.From = new MailAddress(Properties.Settings.Default.Email);
            newMessage.To.Add(mailTo);
            newMessage.Subject = subject;
            newMessage.Body = mailText;
            var sc = new SmtpClient(Properties.Settings.Default.SmptClient);
            sc.Port = 25;
            sc.Credentials = new NetworkCredential(Properties.Settings.Default.Email, mailPassword);
            sc.EnableSsl = true;
            sc.Send(newMessage);
            return true;
        }
         
    }
}
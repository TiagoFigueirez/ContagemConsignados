using System.Net;
using System.Net.Mail;
using System.Text;


namespace ContagemConsignados.Services
{
    public class EmailServices
    {
        public string? Address { get; set; } = "enviarvaleinvasive@gmail.com";
        public string? Password { get; set; } = "jwdj trbu hxnn payy";
        public string? SmtpAddress { get; set; } = "smtp.gmail.com";
        public int Port { get; set; } = 587;
        public bool SubmitEmail(string[] emails)
        {
            string? emailRecipients = "tiago.figueiredo@invasive.com.br";

            //foreach(string email in emails)
            //{
            //    emailRecipients += ";" + email;
            //}

            using(MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(Address, $"Contagem Consignados {DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")}") ;
                mail.To.Add(emailRecipients);
                mail.Subject = "Contagem de consignados";
                mail.Body = EmailBody();
                mail.IsBodyHtml = true;

                using(SmtpClient smtp = new SmtpClient(SmtpAddress, Port))
                {
                    try
                    {
                        smtp.Credentials = new NetworkCredential(Address, Password);
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(mail); 

                        return true;
                    }
                    catch
                    {
                        return false;
                    }

                }
            }
        }

        private string EmailBody()
        {
            
            return "";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public class Sender
    {
        private string _serverName;
        private int _port;

        public Sender(string srvSmtpName, int port)
        {
            _serverName = srvSmtpName;
            _port = port;
        }

        // public
        public void SendMail(string senderMail, string senderPassword, string receiverMail, Mail mail)
        {
            using (MailMessage m = new MailMessage())
            {
                m.From = new MailAddress(senderMail);
                m.To.Add(receiverMail);
                m.Subject = mail.Subject;
                m.Body = mail.Body;
                m.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(_serverName, _port))
                {
                    smtp.Credentials = new NetworkCredential(senderMail, senderPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                }
            }
        }
    }
    public class Mail
    {
        public Mail() { }

        public string Subject { get; set; }
        public string Body { get; set; }
    }
}

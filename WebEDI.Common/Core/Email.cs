using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace WebEDI.Common.Core
{
    public class Email
    {
        public static bool SendMail(string emailusername, string emailpass, string from, string to, string cc, string bcc, string subject, string content,string host, int port)
        {
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                //errorMsg = "From or to email address is null or empty.";
                return false;
            }

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(from);

            cc = to;
            //foreach (var s in toList)
            //{
            //    var mail = s.Trim();
            //    if (mail == string.Empty)
            //    {
            //        continue;
            //    }
            //    mailMessage.To.Add(mail);
            //}
            
            var ccList = cc.Split(';');
            int i = 0;
            foreach (var s in ccList)
            {
                var mail = s.Trim();

                if (mail == string.Empty)
                {
                    continue;
                }
                if (i == 0)
                {
                    mailMessage.To.Add(mail);
                }
                else
                {
                    mailMessage.CC.Add(mail);
                }
                i++;
            }
           
            if (bcc != null)
            {
                var bccList = bcc.Split(';');
                foreach (var s in bccList)
                {
                    var mail = s.Trim();
                    if (mail == string.Empty)
                    {
                        continue;
                    }
                    mailMessage.Bcc.Add(mail);
                }
            }
            mailMessage.Subject = subject;
            mailMessage.Body = content;
            mailMessage.IsBodyHtml = true;

            // Create the credentials to login to the gmail account associated with my custom domain
            string sendEmailsFrom = emailusername;
            string sendEmailsFromPassword = emailpass;
            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(sendEmailsFrom, sendEmailsFromPassword),
                EnableSsl = true,
                Timeout = 20000,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            try
            {
                client.Send(mailMessage);
               // errorMsg = null;
                return true;
            }
            catch (Exception ex)
            {
                //errorMsg = ex.Message;
                return false;
            }
        }
    }
}

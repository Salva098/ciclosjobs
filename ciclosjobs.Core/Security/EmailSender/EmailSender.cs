using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ciclosjobs.Core.Security.EmailSender
{
    public class EmailSender : IEmailSender
    {
        public void Send(string emailDestino,string code)
        {
            var fromAddress = new MailAddress("ciclojobs.info@gmail.com", "Ciclojobs");
            var toAddress = new MailAddress(emailDestino, "To Name");
            const string fromPassword = "2g#lqfekEPOIHUXMBA4XNRA^QqiVBt8*fp!jjD7J#j5Iun%tSj";
            const string subject = "Codigo de verificación";
            string body = "El Codigo de verificación es "+code;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        public void SendEmail(string emailalumno,string nombreEmpresa, string tituloOferta, string mensaje)
        {
            var fromAddress = new MailAddress("ciclojobs.info@gmail.com", "Ciclojobs");
            var toAddress = new MailAddress(emailalumno, "To Name");
            const string fromPassword = "2g#lqfekEPOIHUXMBA4XNRA^QqiVBt8*fp!jjD7J#j5Iun%tSj";
            string subject = "La empresa "+nombreEmpresa+" quiere contactar para la oferta "+tituloOferta;
            string body = "La empresa "+nombreEmpresa+" quiere estar en contacto con usted.\nHa escrito el siguiente mensaje : \n"+ mensaje ;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}

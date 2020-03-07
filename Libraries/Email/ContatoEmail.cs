using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoEmail(Contato contato) {
            /*
             * SMTP -> Servidor que vai enviar a mensagem.
             */
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("ricardo.oliveira.teles@gmail.com", "");
            smtp.EnableSsl = true;

            string corpoMsg = string.Format("<h2>Contato - LojaVirtual</h2>" +
                "<b>Nome:</b> {0} <br/>" +
                "<b>E-mail:</b> {1} <br/>" +
                "<b>Texto:</b> {2} <br/>" +
                "<br/> E-mail enviado automaticamente do site LojaVirtual.",
                contato.Nome, contato.Email, contato.Texto);
            /*
             * MailMessage -> Construir a mensagem.
             */
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("ricardo.oliveira.teles@gmail.com");
            mensagem.To.Add("ricardo.oliveira.teles@gmail.com");
            mensagem.Subject = "Contato - LojaVirtual - E-mail " + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            // Enviar mensagem via SMTP
            smtp.Send(mensagem);
        }
    }
}

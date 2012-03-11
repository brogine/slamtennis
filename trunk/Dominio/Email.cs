using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net.Mail;
using System.Net;

namespace Dominio
{
    public enum PrioridadEmail { Baja, Normal, Alta }
    public class Email
    {
        public Email()
        {
            XmlDocument doc = new XmlDocument();
            string dir = System.AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                doc.Load(dir + "\\CuentaEmail.xml");
            }
            catch (Exception)
            {
                throw new MailingException("No se pudo crear o instanciar el archivo de configuracion de modulo de mailing");
            }

            XmlNodeList ListaNodos = doc.GetElementsByTagName("Cuenta");
            CuentaEmail email = CuentaEmail.GetIntancia();
            
            XmlNode NodoCuenta = null;
            NodoCuenta = ListaNodos[0];            

            if (NodoCuenta != null)
            {
                email.Correo = NodoCuenta.Attributes["Email"].Value;
                this.Remitente = NodoCuenta.Attributes["nombre"].Value;
                email.Clave = NodoCuenta.Attributes["Clave"].Value;
                email.SMTP = new ServidorSMTP()
                {
                    Puerto = Convert.ToInt32(NodoCuenta.Attributes["Puerto"].Value),
                    RequiereAutenticacion = Convert.ToBoolean(NodoCuenta.Attributes["RequiereAutenticacion"].Value),
                    Host = NodoCuenta.Attributes["Servidor"].Value
                };
            }
            else
            {
                throw new MailingException("La cuenta de email predeterminada no puede ser recuperada...");
            }
            this.CuentaEmail = email;
        }
        
        public string Remitente { get; set; }
        public string EmailDestino { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        private CuentaEmail CuentaEmail { get; set; }
        public PrioridadEmail Prioridad { get; set; }

        public void Enviar()
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(this.EmailDestino));
            msg.From = new MailAddress(this.CuentaEmail.Correo,this.Remitente);
            msg.Subject = this.Asunto;
            msg.Body = this.Mensaje;

            SmtpClient clienteSmtp = new SmtpClient(this.CuentaEmail.SMTP.Host, this.CuentaEmail.SMTP.Puerto);
            clienteSmtp.Credentials = new NetworkCredential(this.CuentaEmail.Correo, this.CuentaEmail.Clave);
            clienteSmtp.EnableSsl = this.CuentaEmail.SMTP.RequiereAutenticacion;

            try
            {
                clienteSmtp.Send(msg);
            }
            catch (Exception ex)
            {
                throw new MailingException("No se puedo enviar el email...");
            }
        }
    }

}

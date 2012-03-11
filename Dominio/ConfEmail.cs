using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Dominio
{
    public class ConfEmail
    {
        public void GuardarCuenta(string nombre,string email, string clave)
        {
            XmlDocument doc = new XmlDocument();
            string dir = System.AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                doc.Load(dir + "\\CuentasSMTP.xml");
            }
            catch (Exception)
            {
                throw new MailingException("El archivo de Configuración no se encuentra.");
            }

            XmlNodeList ListaNodos = doc.GetElementsByTagName("Cuenta");
            string cuenta = email.Substring(email.IndexOf("@"), email.Length - email.IndexOf("@"));
            cuenta = cuenta.Replace("@", string.Empty);
            cuenta = cuenta.Substring(0, cuenta.IndexOf("."));
            ServidorSMTP server = new ServidorSMTP();
            XmlNode NodoCuenta = null;

            foreach (XmlNode item in ListaNodos)
            {
                if (item.Attributes["nombre"].Value == cuenta)
                {
                    NodoCuenta = item;
                    break;
                }
            }

            if (NodoCuenta != null)
            {
                server.RequiereAutenticacion = Convert.ToBoolean(NodoCuenta.Attributes["RequiereAutenticacion"].Value);
                server.Nombre = NodoCuenta.Attributes["nombre"].Value;
                server.Host = NodoCuenta.Attributes["Servidor"].Value;
                server.Puerto = Convert.ToInt32(NodoCuenta.Attributes["Puerto"].Value);
            }
            else
            {
                throw new MailingException("La cuenta ingresada no puede ser configurada automaticamente...");
            }
             
                                  
            try
            {
                doc = new XmlDocument();
                doc.Load(dir + "\\CuentaEmail.xml");
            }
            catch (Exception)
            {
                throw new MailingException("No se pudo crear o instanciar el archivo de configuracion de modulo de mailing");
            }

            XmlNodeList NodoEmail = doc.GetElementsByTagName("Cuenta");
            NodoEmail[0].Attributes["nombre"].Value = nombre;
            NodoEmail[0].Attributes["Email"].Value = email;
            NodoEmail[0].Attributes["Clave"].Value = clave;
            NodoEmail[0].Attributes["Servidor"].Value = server.Host;
            NodoEmail[0].Attributes["Puerto"].Value = server.Puerto.ToString();
            NodoEmail[0].Attributes["RequiereAutenticacion"].Value = server.RequiereAutenticacion.ToString();
            doc.Save(dir + "\\CuentaEmail.xml");            
        }

        public void GuardarCuenta(string nombre, string email, string clave, string servidor,int puerto, bool requiereautent)
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
            ListaNodos[0].Attributes["nombre"].Value = nombre;
            ListaNodos[0].Attributes["Email"].Value = email;
            ListaNodos[0].Attributes["Clave"].Value = clave;
            ListaNodos[0].Attributes["Servidor"].Value = servidor;
            ListaNodos[0].Attributes["Puerto"].Value = puerto.ToString();
            ListaNodos[0].Attributes["RequiereAutenticacion"].Value = requiereautent.ToString();

        }

    }
}

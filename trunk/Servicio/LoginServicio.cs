using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio;
using Dominio;

namespace Servicio
{
    public class LoginServicio : ILoginServicio
    {
        ILoginRepositorio loginRepo;
        public LoginServicio()
        {
            loginRepo = new LoginRepositorio();
        }

        #region Miembros de ILoginServicio

        public void Agregar(Servicio.InterfacesUI.ILoginUI ui)
        {
            if (!loginRepo.Existe(ui.Usuario))
                loginRepo.Agregar(new Dominio.Login(ui.Usuario, ui.Password, ui.Dni, ui.Estado));
            else
                throw new ServicioException("El usuario ingresado ya existe.");
        }

        public void Modificar(Servicio.InterfacesUI.ILoginUI ui)
        {
            Login bLogin = loginRepo.Obtener(ui.Usuario);
            bLogin.Usuario = ui.Usuario;
            bLogin.Password = ui.Password;
            bLogin.Estado = ui.Estado;
            loginRepo.Modificar(bLogin);
        }

        public void OlvidoPassword(string usuario)
        {
            Login bLogin = loginRepo.Obtener(usuario);
            if(bLogin.Estado)
            {
                //TODO: Get User Email
                Email email = new Email();
                email.Asunto = "Olvido Password - Slam Tennis";
                email.Remitente = "no-reply@slamtennis.com";
                //email.EmailDestino
            }
        }

        public int Validar(Servicio.InterfacesUI.ILoginUI ui)
        {
            if (!loginRepo.Existe(ui.Usuario))
                return 0;
            else
            {
                Login bLogin = loginRepo.Obtener(ui.Usuario);
                if (bLogin.Password == ui.Password && bLogin.Estado)
                    return bLogin.Dni;
                else
                    return 0;
            }
        }

        public bool PrimerInicio()
        {
            IEmpleadoRepositorio repoEmpleados = new EmpleadoRepositorio();
            if (repoEmpleados.getCantidad() > 0)
                return false;
            else
                return true;
        }

        #endregion
    }
}

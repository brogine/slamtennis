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
                loginRepo.Agregar(new Dominio.Login(ui.Usuario, ui.Password, ui.Estado), 123);
            else
                throw new ServicioExeption("El usuario ingresado ya existe.");
        }

        public void Modificar(Servicio.InterfacesUI.ILoginUI ui)
        {
            Login bLogin = loginRepo.Obtener(ui.Usuario);
            bLogin.Password = ui.Password;
            bLogin.Estado = ui.Estado;
            loginRepo.Modificar(bLogin);
        }

        public void OlvidoPassword(string usuario)
        {
            throw new NotImplementedException();
        }

        public bool Validar(Servicio.InterfacesUI.ILoginUI ui)
        {
            if (!loginRepo.Existe(ui.Usuario))
                return false;
            else
            {
                Login bLogin = loginRepo.Obtener(ui.Usuario);
                if (bLogin.Password == ui.Password && bLogin.Estado)
                    return true;
                else
                    return false;
            }
        }

        #endregion
    }
}

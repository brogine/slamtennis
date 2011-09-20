using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;

namespace Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio, IMapeador<Categoria>
    {
        protected Conexion conn;
        protected string sql;
        public CategoriaRepositorio()
        {
            conn = new Conexion();
        }
        #region Miembros de ICategoriaRepositorio

        public List<Categoria> Listar()
        {
            sql = " Select * From Categorias ";
            DataTable Dt = conn.Listar(sql);
            List<Categoria> Lista = new List<Categoria>();
            foreach (DataRow Dr in Dt.Rows)
            {
                Lista.Add(this.Mapear(Dr));
            }
            return Lista;
        }

        public bool Existe(int Id)
        {
            string Consulta = "Select Count(IdCategoria) from Categorias Where IdCategoria = " + Id;
            DataRow Fila = conn.Buscar(Consulta);
            int cantidad = Convert.ToInt32(Fila[0]);
            if (cantidad == 1)
                return true;
            else
                return false;
        }
        public Categoria Buscar(int Id)
        {
            sql = " Select * From Categorias Where IdCategoria = " + Id;
            DataRow Dr = conn.Buscar(sql);
            return this.Mapear(Dr);
        }

        public int Agregar(Categoria Categoria)
        {
            string Valores = "'" + Categoria.Nombre + "'," + Categoria.EdadMin + "," + Categoria.EdadMax+","+Categoria.Estado;
            return conn.Agregar("Categorias", "Nombre, EdadMinima, EdadMaxima, Estado", Valores);
        }

        public void Modificar(Categoria Categoria)
        {
            sql = " Update Categorias Set Nombre = '" + Categoria.Nombre + "', EdadMinima = " + Categoria.EdadMin +
                ", EdadMaxima = " + Categoria.EdadMax + ", Estado = "+Categoria.Estado +" where IdCategoria = " + Categoria.Id;
            conn.ActualizarOEliminar(sql);
        }
        #endregion

        #region Miembros de IMapeador<Categoria>

        public Categoria Mapear(System.Data.DataRow fila)
        {
            Categoria Retorno = null;
            if (fila != null)
            {
                int IdCateg = (fila.IsNull("IdCategoria") == true ? 0 : Convert.ToInt32(fila["IdCategoria"]));
                string Nombre = (fila.IsNull("Nombre") == true ? string.Empty : fila["Nombre"].ToString());
                int EdadMin = (fila.IsNull("EdadMin") == true ? 0 : Convert.ToInt32(fila["EdadMin"]));
                int EdadMax = (fila.IsNull("EdadMax") == true ? 0 : Convert.ToInt32(fila["EdadMax"]));
                bool Estado = (fila.IsNull("Estado") == true ? false : Convert.ToBoolean(fila["Estado"]));
                Retorno = new Categoria(IdCateg, Nombre, EdadMin, EdadMax, Estado);
            }
            return Retorno;
        }

        #endregion
    }
}

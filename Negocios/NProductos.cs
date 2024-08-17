using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NProductos
    {
        #region Agregar
        public int Agregar(EProductos obj, int Id_Usuario)
        {
            try
            {
                DProductos db = new DProductos();
                return db.Agregar(obj, Id_Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Modificar
        public int Modificar(EProductos obj, int Id_Usuario)
        {
            try
            {
                DProductos db = new DProductos();
                return db.Modificar(obj, Id_Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Eliminar
        public int Eliminar(int Id, int Id_Usuario)
        {
            try
            {
                DProductos db = new DProductos();
                return db.Eliminar(Id, Id_Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Mostrar
        public List<EProductos> Mostrar()
        {
            try
            {
                DProductos db = new DProductos();
                return db.Mostrar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

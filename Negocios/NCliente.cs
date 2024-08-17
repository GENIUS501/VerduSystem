using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NCliente
    {
        #region Agregar
        public int Agregar(EClientes obj, int Id_Usuario)
        {
            try
            {
                DClientes db = new DClientes();
                return db.Agregar(obj, Id_Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Modificar
        public int Modificar(EClientes obj, int Id_Usuario)
        {
            try
            {
                DClientes db = new DClientes();
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
                DClientes db = new DClientes();
                return db.Eliminar(Id, Id_Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Mostrar
        public List<EClientes> Mostrar()
        {
            try
            {
                DClientes db = new DClientes();
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

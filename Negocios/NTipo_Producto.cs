using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NTipo_Producto
    {
        #region Agregar
        public int Agregar(ETipo_Productos obj, int Id_Usuario)
        {
            try
            {
                DTipo_Producto db = new DTipo_Producto();
                return db.Agregar(obj, Id_Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Modificar
        public int Modificar(ETipo_Productos obj, int Id_Usuario)
        {
            try
            {
                DTipo_Producto db = new DTipo_Producto();
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
                DTipo_Producto db = new DTipo_Producto();
                return db.Eliminar(Id, Id_Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Mostrar
        public List<ETipo_Productos> Mostrar()
        {
            try
            {
                DTipo_Producto db = new DTipo_Producto();
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

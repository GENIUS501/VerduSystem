using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NVentas
    {
        #region Agregar
        public int Agregar(EVentas obj, List<EVentas_Detalles> objlista, int IdUsuario)
        {
            try
            {
                DVentas db = new DVentas();
                return db.Agregar(obj, objlista, IdUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Mostrar 
        public List<EVentas> Mostrar()
        {
            try
            {
                DVentas db = new DVentas();
                return db.Mostrar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EReporte_Ventas_Detalles> MostrarDetalle()
        {
            try
            {
                DVentas db = new DVentas();
                return db.MostrarDetalle();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Eliminar
        public int Eliminar(int ID)
        {
            try
            {
                DVentas db = new DVentas();
                return db.Eliminar(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Afectar inventario
        public int Afectar_Inventario(int Id_Producto)
        {
            try
            {
                DVentas db = new DVentas();
                return db.Afectar_Inventario(Id_Producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

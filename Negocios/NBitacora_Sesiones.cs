using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NBitacora_Sesiones
    {
        #region Agregar
        public int Agregar(EBitacora_Sesiones obj)
        {
            try
            {
                DBitacora_Sesiones db = new DBitacora_Sesiones();
                return db.Agregar(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Modificar
        public int Modificar(EBitacora_Sesiones obj)
        {
            try
            {
                DBitacora_Sesiones db = new DBitacora_Sesiones();
                return db.Modificar(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Listar
        public List<EBitacora_Sesiones> Mostrar()
        {
            try
            {
                DBitacora_Sesiones db = new DBitacora_Sesiones();
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

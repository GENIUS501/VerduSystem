using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NDevoluciones
    {
        #region Agregar
        public int Agregar(EDevoluciones Obj, int Usuario)
        {
            try
            {
                DDevoluciones BD = new DDevoluciones();
                return BD.Agregar(Obj, Usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Mostrar Unico
        public EVentas MostrarUnico(int ID)
        {
            try
            {
                DDevoluciones db = new DDevoluciones();
                return db.MostrarUnico(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Mostrar varios
        public List<EVentas> Mostrar()
        {
            try
            {
                DDevoluciones db = new DDevoluciones();
                return db.Mostrar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EDevoluciones> MostrarDev()
        {
            try
            {
                DDevoluciones db = new DDevoluciones();
                return db.MostrarDev();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EVentas> MostrarId(int ID)
        {
            try
            {
                DDevoluciones db = new DDevoluciones();
                return db.MostrarId(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EVentas> MostrarIdentificacion(string Cedula)
        {
            try
            {
                DDevoluciones db = new DDevoluciones();
                return db.MostrarCedula(Cedula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

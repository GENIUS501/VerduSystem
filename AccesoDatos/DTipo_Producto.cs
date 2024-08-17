using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AccesoDatos
{
    public class DTipo_Producto
    {
        DiamondEntities db = new DiamondEntities();
        EBitacora_Movimientos Entidad_Movimientos = new EBitacora_Movimientos();
        DBitacora_movimientos Movimientos = new DBitacora_movimientos();
        #region Agregar
        public int Agregar(ETipo_Productos obj, int Id_Usuario)
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    Tab_Tipo_Productos Objbd = new Tab_Tipo_Productos();
                    Objbd.Nombre = obj.Nombre;
                    Objbd.Descripcion = obj.Descripcion;
                    db.Tab_Tipo_Productos.Add(Objbd);

                    int Resultado = db.SaveChanges();

                    if (Resultado > 0)
                    {
                        Ts.Complete();
                        //Entidad_Movimientos.Id_Usuario = Id_Usuario;
                        //Entidad_Movimientos.modulo = "Tipo_Productos";
                        //Entidad_Movimientos.tipo_movimiento = "Agregar";
                        //Entidad_Movimientos.fecha_hora_movimiento = DateTime.Now;
                        //Movimientos.Agregar(Entidad_Movimientos);
                        return Resultado;
                    }
                    else
                    {
                        Ts.Dispose();
                        return 0;
                    }
                }
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
                List<ETipo_Productos> Lista = new List<ETipo_Productos>();
                Lista = db.Tab_Tipo_Productos
                .Select(x => new ETipo_Productos
                {
                    ID_Tipo_Producto = x.ID_Tipo_Producto,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                }).ToList();
                return Lista;
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
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var Objbd = db.Tab_Tipo_Productos.Where(x => x.ID_Tipo_Producto == obj.ID_Tipo_Producto).FirstOrDefault();
                    Objbd.Nombre = obj.Nombre;
                    Objbd.Descripcion = obj.Descripcion;
                    db.Entry(Objbd).State = EntityState.Modified;
                    int Resultado = db.SaveChanges();
                    if (Resultado > 0)
                    {
                        Ts.Complete();
                        //Entidad_Movimientos.Id_Usuario = Id_Usuario;
                        //Entidad_Movimientos.modulo = "Tipo_Productos";
                        //Entidad_Movimientos.tipo_movimiento = "Modificar";
                        //Entidad_Movimientos.fecha_hora_movimiento = DateTime.Now;
                        //Movimientos.Agregar(Entidad_Movimientos);
                        return Resultado;
                    }
                    Ts.Dispose();
                    return Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Eliminar
        public int Eliminar(int ID, int Id_Usuario)
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var Objbd = db.Tab_Tipo_Productos.Where(x => x.ID_Tipo_Producto == ID).FirstOrDefault();
                    db.Entry(Objbd).State = EntityState.Deleted;
                    int Resultado = db.SaveChanges();
                    if (Resultado > 0)
                    {
                        Ts.Complete();
                        //Entidad_Movimientos.Id_Usuario = Id_Usuario;
                        //Entidad_Movimientos.modulo = "Tipo_Productos";
                        //Entidad_Movimientos.tipo_movimiento = "Eliminar";
                        //Entidad_Movimientos.fecha_hora_movimiento = DateTime.Now;
                        //Movimientos.Agregar(Entidad_Movimientos);
                        return Resultado;
                    }
                    Ts.Dispose();
                    return Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

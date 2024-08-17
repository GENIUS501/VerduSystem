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
    public class DProductos
    {
        DiamondEntities db = new DiamondEntities();
        EBitacora_Movimientos Entidad_Movimientos = new EBitacora_Movimientos();
        DBitacora_movimientos Movimientos = new DBitacora_movimientos();
        #region Agregar
        public int Agregar(EProductos obj, int Id_Usuario)
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    Tab_Productos Objbd = new Tab_Productos();
                    Objbd.ID_Tipo_Producto = obj.ID_Tipo_Producto;
                    Objbd.Nombre = obj.Nombre;
                    Objbd.Descripcion = obj.Descripcion;
                    Objbd.Precio = obj.Precio;
                    Objbd.Cantidad = obj.Cantidad;
                    Objbd.Imagen = obj.Imagen;
                    db.Tab_Productos.Add(Objbd);

                    int Resultado = db.SaveChanges();

                    if (Resultado > 0)
                    {
                        Ts.Complete();
                        Entidad_Movimientos.Id_Usuario = Id_Usuario;
                        Entidad_Movimientos.modulo = "Productos";
                        Entidad_Movimientos.tipo_movimiento = "Agregar";
                        Entidad_Movimientos.fecha_hora_movimiento = DateTime.Now;
                        Movimientos.Agregar(Entidad_Movimientos);
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
        public List<EProductos> Mostrar()
        {
            try
            {
                List<EProductos> Lista = new List<EProductos>();
                Lista = db.Tab_Productos
                .Select(x => new EProductos
                {
                    ID_Producto = x.ID_Producto,
                    ID_Tipo_Producto = x.ID_Tipo_Producto,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    Precio = x.Precio,
                    Cantidad = x.Cantidad,
                    Imagen = x.Imagen
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
        public int Modificar(EProductos obj, int Id_Usuario)
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var Objbd = db.Tab_Productos.Where(x => x.ID_Producto == obj.ID_Producto).FirstOrDefault();
                    Objbd.ID_Tipo_Producto = obj.ID_Tipo_Producto;
                    Objbd.Nombre = obj.Nombre;
                    Objbd.Descripcion = obj.Descripcion;
                    Objbd.Precio = obj.Precio;
                    Objbd.Cantidad = obj.Cantidad;
                    Objbd.Imagen = obj.Imagen;
                    db.Entry(Objbd).State = EntityState.Modified;
                    int Resultado = db.SaveChanges();
                    if (Resultado > 0)
                    {
                        Ts.Complete();
                        Entidad_Movimientos.Id_Usuario = Id_Usuario;
                        Entidad_Movimientos.modulo = "Productos";
                        Entidad_Movimientos.tipo_movimiento = "Modificar";
                        Entidad_Movimientos.fecha_hora_movimiento = DateTime.Now;
                        Movimientos.Agregar(Entidad_Movimientos);
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
                    var Objbd = db.Tab_Productos.Where(x => x.ID_Producto == ID).FirstOrDefault();
                    db.Entry(Objbd).State = EntityState.Deleted;
                    int Resultado = db.SaveChanges();
                    if (Resultado > 0)
                    {
                        Ts.Complete();
                        Entidad_Movimientos.Id_Usuario = Id_Usuario;
                        Entidad_Movimientos.modulo = "Productos";
                        Entidad_Movimientos.tipo_movimiento = "Eliminar";
                        Entidad_Movimientos.fecha_hora_movimiento = DateTime.Now;
                        Movimientos.Agregar(Entidad_Movimientos);
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

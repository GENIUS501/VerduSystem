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
    public class DDevoluciones
    {
        DiamondEntities db = new DiamondEntities();
        EBitacora_Movimientos Entidad_Movimientos = new EBitacora_Movimientos();
        DBitacora_movimientos Movimientos = new DBitacora_movimientos();
        #region Agregar
        public int Agregar(EDevoluciones obj, int IdUsuario)
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var Ventas = db.Tab_Venta.Where(x => x.Numero_factura == obj.IdVenta).FirstOrDefault();
                    Tab_Devoluciones Objbd = new Tab_Devoluciones();
                    Objbd.CantidadProducto = Ventas.CantidadProducto;
                    Objbd.FechaDevolucion = DateTime.Now;
                    Objbd.IDCliente = Ventas.ID_Cliente;
                    Objbd.IdUsuario = Ventas.ID_Usuario;
                    Objbd.IdVenta = obj.IdVenta;
                    db.Entry(Objbd).State = EntityState.Added;
                    //db.Tab_Devoluciones.Add(Objbd);

                    int Resultado = db.SaveChanges();

                    if (Resultado > 0)
                    {
                        var VentasLista = db.Tab_Venta_detallada.Where(x => x.Numero_factura == obj.IdVenta).ToList();
                        foreach (var Item in VentasLista)
                        {
                            Afectar_Inventario(Item.ID_Producto);
                        }
                        Ts.Complete();
                        Entidad_Movimientos.Id_Usuario = IdUsuario;
                        Entidad_Movimientos.modulo = "Devoluciones";
                        Entidad_Movimientos.tipo_movimiento = "Agregar";
                        Entidad_Movimientos.fecha_hora_movimiento = DateTime.Now;
                        Movimientos.Agregar(Entidad_Movimientos);
                        return Objbd.IdDevolucion;
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

        #region Afectar inventario
        public void Afectar_Inventario(int Id_Producto)
        {
            try
            {
                var Objbd = db.Tab_Productos.Where(x => x.ID_Producto == Id_Producto).FirstOrDefault();
                Objbd.Cantidad = Objbd.Cantidad + 1;
                db.Entry(Objbd).State = EntityState.Modified;
                db.SaveChanges();
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
                EVentas Obj = new EVentas();
                var Objbd = db.Tab_Venta.Where(x => x.Numero_factura == ID).FirstOrDefault();
                Obj.CantidadProducto = Objbd.CantidadProducto;
                Obj.ID_Cliente = Objbd.ID_Cliente;
                Obj.ID_Usuario = Objbd.ID_Usuario;
                Obj.Numero_factura = Objbd.Numero_factura;
                Obj.Total = Objbd.Total;
                return Obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Mostrar varios
        public List<EDevoluciones> MostrarDev()
        {
            try
            {
                List<EDevoluciones> Lista = new List<EDevoluciones>();
                var Objbd = db.Tab_Devoluciones.ToList();
                Lista = Objbd.Select(Item => new EDevoluciones
                {
                    CantidadProducto = Item.CantidadProducto,
                    IDCliente = Item.IDCliente,
                    FechaDevolucion = Item.FechaDevolucion,
                    IdDevolucion = Item.IdDevolucion,
                    IdUsuario = Item.IdUsuario,
                    IdVenta = Item.IdVenta,
                    Monto = (int)db.Tab_Venta.Where(c => c.Numero_factura == Item.IdVenta).FirstOrDefault().Total
                }).ToList();

                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<EVentas> Mostrar()
        {
            try
            {
                List<EVentas> Lista = new List<EVentas>();
                var Objbd = db.Tab_Venta.ToList();
                var Devoluciones = db.Tab_Devoluciones.ToList();
                foreach (var Item in Objbd)
                {
                    var Devolucion = db.Tab_Devoluciones.Where(x => x.IdVenta == Item.Numero_factura).FirstOrDefault();
                    if (Devolucion == null)
                    {
                        Lista.Add(new EVentas()
                        {
                            CantidadProducto = Item.CantidadProducto,
                            ID_Cliente = Item.ID_Cliente,
                            Total = Item.Total,
                            ID_Usuario = Item.ID_Usuario,
                            Tipo_pago = Item.Tipo_pago,
                            Fecha_venta = Item.Fecha_venta,
                            Numero_factura = Item.Numero_factura
                        });
                    }
                }
                return Lista;
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
                List<EVentas> Lista = new List<EVentas>();
                var Objbd = db.Tab_Venta.Where(x => x.Numero_factura == ID).ToList();
                var Devoluciones = db.Tab_Devoluciones.ToList();
                foreach (var Item in Objbd)
                {
                    var Devolucion = db.Tab_Devoluciones.Where(x => x.IdVenta == Item.Numero_factura).FirstOrDefault();
                    if (Devolucion == null)
                    {
                        Lista.Add(new EVentas()
                        {
                            CantidadProducto = Item.CantidadProducto,
                            ID_Cliente = Item.ID_Cliente,
                            Total = Item.Total,
                            ID_Usuario = Item.ID_Usuario,
                            Numero_factura = Item.Numero_factura,
                            Tipo_pago = Item.Tipo_pago,
                            Fecha_venta = Item.Fecha_venta
                        });
                    }
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<EVentas> MostrarCedula(string Identificacion)
        {
            try
            {
                List<EVentas> Lista = new List<EVentas>();
                var Objbd = db.Tab_Venta.Where(x => x.Tab_Clientes.Cedula == Identificacion).ToList();
                var Devoluciones = db.Tab_Devoluciones.ToList();
                foreach (var Item in Objbd)
                {
                    var Devolucion = db.Tab_Devoluciones.Where(x => x.IdVenta == Item.Numero_factura).FirstOrDefault();
                    if (Devolucion == null)
                    {
                        Lista.Add(new EVentas()
                        {
                            CantidadProducto = Item.CantidadProducto,
                            ID_Cliente = Item.ID_Cliente,
                            Total = Item.Total,
                            ID_Usuario = Item.ID_Usuario,
                            Numero_factura = Item.Numero_factura,
                            Tipo_pago = Item.Tipo_pago,
                            Fecha_venta = Item.Fecha_venta
                        });
                    }
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}

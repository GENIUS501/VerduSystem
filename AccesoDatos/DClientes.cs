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
    public class DClientes
    {
        DiamondEntities db = new DiamondEntities();
        EBitacora_Movimientos Entidad_Movimientos = new EBitacora_Movimientos();
        DBitacora_movimientos Movimientos = new DBitacora_movimientos();
        #region Agregar
        public int Agregar(EClientes obj, int Id_Usuario)
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    Tab_Clientes Objbd = new Tab_Clientes();
                    Objbd.Cedula = obj.Cedula;
                    Objbd.Nombre = obj.Nombre;
                    Objbd.Primer_Apellido = obj.Primer_Apellido;
                    Objbd.Segundo_Apellido = obj.Segundo_Apellido;
                    Objbd.Correo = obj.Correo;
                    Objbd.Direccion = obj.Direccion;
                    Objbd.Telefono = obj.Telefono;
                    // Objbd.Genero = obj.Genero;
                    db.Tab_Clientes.Add(Objbd);

                    int Resultado = db.SaveChanges();

                    if (Resultado > 0)
                    {
                        Ts.Complete();
                        Entidad_Movimientos.Id_Usuario = Id_Usuario;
                        Entidad_Movimientos.modulo = "Clientes";
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
                if (ex.InnerException.HResult == -2146233087)
                {
                    throw new Exception("La cedula ingresada ya existe en el sistema");
                }
                else
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region Mostrar
        public List<EClientes> Mostrar()
        {
            try
            {
                List<EClientes> Lista = new List<EClientes>();
                Lista = db.Tab_Clientes
                .Select(x => new EClientes
                {
                    Cedula = x.Cedula,
                    Nombre = x.Nombre,
                    Primer_Apellido = x.Primer_Apellido,
                    Segundo_Apellido = x.Segundo_Apellido,
                    Correo = x.Correo,
                    Direccion = x.Direccion,
                    Telefono = x.Telefono,
                    Numero_Cliente = x.Numero_Cliente
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
        public int Modificar(EClientes obj, int Id_Usuario)
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var Objbd = db.Tab_Clientes.Where(x => x.Numero_Cliente == obj.Numero_Cliente).FirstOrDefault();
                    Objbd.Cedula = obj.Cedula.ToString();
                    Objbd.Nombre = obj.Nombre;
                    Objbd.Primer_Apellido = obj.Primer_Apellido;
                    Objbd.Segundo_Apellido = obj.Segundo_Apellido;
                    Objbd.Correo = obj.Correo;
                    Objbd.Direccion = obj.Direccion;
                    Objbd.Telefono = obj.Telefono;
                    // Objbd.Genero = obj.Genero;
                    db.Entry(Objbd).State = EntityState.Modified;
                    int Resultado = db.SaveChanges();
                    if (Resultado > 0)
                    {
                        Ts.Complete();
                        Entidad_Movimientos.Id_Usuario = Id_Usuario;
                        Entidad_Movimientos.modulo = "Clientes";
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
                    var Objbd = db.Tab_Clientes.Where(x => x.Numero_Cliente == ID).FirstOrDefault();
                    db.Entry(Objbd).State = EntityState.Deleted;
                    int Resultado = db.SaveChanges();
                    if (Resultado > 0)
                    {
                        Ts.Complete();
                        Entidad_Movimientos.Id_Usuario = Id_Usuario;
                        Entidad_Movimientos.modulo = "Clientes";
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

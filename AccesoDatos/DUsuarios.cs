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
    public class DUsuarios
    {
        DiamondEntities db = new DiamondEntities();
        EBitacora_Movimientos Entidad_Movimientos = new EBitacora_Movimientos();
        DBitacora_movimientos Movimientos = new DBitacora_movimientos();
        #region Agregar
        public int Agregar(EUsuario obj, int Id_Usuario)
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    Tab_Usuarios Objbd = new Tab_Usuarios();
                    Objbd.Cedula = obj.Cedula;
                    Objbd.Nombre = obj.Nombre;
                    Objbd.Nombre_Usuario = obj.Nombre_Usuario;
                    Objbd.Primer_Apellido = obj.Primer_Apellido;
                    Objbd.Segundo_Apellido = obj.Segundo_Apellido;
                    Objbd.Correo = obj.Correo;
                    Objbd.Telefono = obj.Telefono;
                    //Objbd.Genero = obj.Genero;
                    Objbd.Id_Rol = obj.Id_Rol;
                    Objbd.Estado = 1;
                    Objbd.Contrasena = obj.Contrasena;
                    db.Entry(Objbd).State = EntityState.Added;
                    int Resultado = db.SaveChanges();
                    if (Resultado > 0)
                    {
                        Ts.Complete();
                        Entidad_Movimientos.Id_Usuario = Id_Usuario;
                        Entidad_Movimientos.modulo = "Usuarios";
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

        #region Modificar
        public int Modificar(EUsuario obj, int Id_Usuario)
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var Objbd = db.Tab_Usuarios.Where(x => x.ID_Usuario == obj.ID_Usuario).FirstOrDefault();
                    Objbd.ID_Usuario = obj.ID_Usuario;
                    Objbd.Nombre = obj.Nombre;
                    Objbd.Nombre_Usuario = obj.Nombre_Usuario;
                    Objbd.Primer_Apellido = obj.Primer_Apellido;
                    Objbd.Segundo_Apellido = obj.Segundo_Apellido;
                    //Objbd.Genero = obj.Genero;
                    Objbd.Id_Rol = obj.Id_Rol;
                    Objbd.Correo = obj.Correo;
                    Objbd.Telefono = obj.Telefono;
                    Objbd.Cedula = obj.Cedula;
                    Objbd.Estado = 1;
                    if (obj.Contrasena == "********")
                    {

                    }
                    else
                    {
                        Objbd.Contrasena = obj.Contrasena;
                    }
                    db.Entry(Objbd).State = EntityState.Modified;
                    int Resultado = db.SaveChanges();
                    if (Resultado > 0)
                    {
                        Ts.Complete();
                        Entidad_Movimientos.Id_Usuario = Id_Usuario;
                        Entidad_Movimientos.modulo = "Usuarios";
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
                    var Objbd = db.Tab_Usuarios.Where(x => x.ID_Usuario == ID).FirstOrDefault();
                    db.Entry(Objbd).State = EntityState.Deleted;
                    int Resultado = db.SaveChanges();
                    if (Resultado > 0)
                    {
                        Ts.Complete();
                        Entidad_Movimientos.Id_Usuario = Id_Usuario;
                        Entidad_Movimientos.modulo = "Usuarios";
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


        #region Mostrar varios
        public List<EUsuario> Mostrar()
        {
            try
            {
                List<EUsuario> Lista = new List<EUsuario>();
                Lista = db.Tab_Usuarios
                .Select(x => new EUsuario
                {
                    ID_Usuario = x.ID_Usuario,
                    Cedula = x.Cedula,
                    Nombre = x.Nombre,
                    Primer_Apellido = x.Primer_Apellido,
                    Segundo_Apellido = x.Segundo_Apellido,
                    Nombre_Usuario = x.Nombre_Usuario,
                    //Genero = x.Genero,
                    Id_Rol = x.Id_Rol,
                 //   Estado = x.Estado,
                    Contrasena = x.Contrasena,
                    Telefono = x.Telefono,
                    Correo = x.Correo
                }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Login
        public EUsuario Login(string User, string Pass)
        {
            try
            {
                EUsuario Obj = new EUsuario();
                Obj = db.Tab_Usuarios
                .Select(x => new EUsuario
                {
                    ID_Usuario = x.ID_Usuario,
                    Nombre = x.Nombre,
                    Nombre_Usuario = x.Nombre_Usuario,
                    Primer_Apellido = x.Primer_Apellido,
                    Segundo_Apellido = x.Segundo_Apellido,
                    //Genero = x.Genero,
                    Id_Rol = x.Id_Rol,
                    //Estado = x.Estado,
                    Contrasena = x.Contrasena
                }).Where(x => x.Nombre_Usuario == User && x.Contrasena == Pass).FirstOrDefault();
                return Obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

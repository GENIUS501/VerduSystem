using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AccesoDatos
{
    public class DPermisos
    {
        DiamondEntities db = new DiamondEntities();
        #region Agregar
        public int Agregar(List<EPermisos> obj, int Id_Rol)//Viene de la vista obj
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var Permisos_Anteriores = db.Tab_Permisos.Where(x => x.Id_Rol == Id_Rol).ToList();
                    if (Permisos_Anteriores.Count > 0)
                    {
                        db.Tab_Permisos.RemoveRange(Permisos_Anteriores);
                    }
                    if (obj.Count > 0)
                    {
                        List<Tab_Permisos> Permisos = new List<Tab_Permisos>();
                        Permisos = obj
                        .Select(x => new Tab_Permisos
                        {
                            ID = x.ID,
                            Id_Rol = x.Id_Rol,
                            Accion = x.Accion,
                            Modulo = x.Modulo,
                        }).ToList();
                        db.Tab_Permisos.AddRange(Permisos);
                    }

                    int Resultado = db.SaveChanges();//Commit

                    if (Resultado > 0)
                    {
                        Ts.Complete();
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

        #region Mostrar Detallado
        public EPermisos Mostrar_Detallado(int id)
        {
            try
            {
                using (db)
                {
                    EPermisos Obj = new EPermisos();
                    var Objbd = db.Tab_Permisos.Where(a => a.ID == id).FirstOrDefault();
                    Obj.ID = Objbd.ID;
                    Obj.Id_Rol = Objbd.Id_Rol;
                    Obj.Modulo = Objbd.Modulo;
                    Obj.Accion = Objbd.Accion;
                    return Obj;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region Modificar
        public int Modificar(EPermisos Obj)
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    //Esto llena la entidad con los datos correspondientes a la entidad traida de la bd
                    var Objbd = db.Tab_Permisos.Find(Obj.ID);
                    Objbd.ID = Obj.ID;
                    Objbd.Modulo = Obj.Modulo;
                    Objbd.Id_Rol = Obj.Id_Rol;
                    Objbd.Accion = Obj.Accion;
                    //Guarda los cambios en bd
                    int Resultado = db.SaveChanges();//Commit

                    if (Resultado > 0)
                    {
                        Ts.Complete();
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

        #region Eliminar
        public int Eliminar(int Id)
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    //Esto llena la entidad con los datos correspondientes a la entidad traida de la bd
                    var Objbd = db.Tab_Permisos.Where(x => x.ID == Id).ToList();
                    //Asigna los valores traidos por la entidad traida de la vista a la entidad traida de la base de datos
                    db.Tab_Permisos.RemoveRange(Objbd);
                    //Guarda los cambios en bd
                    int Resultado = db.SaveChanges();//Commit

                    if (Resultado > 0)
                    {
                        Ts.Complete();
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

        #region Listar
        public List<EPermisos> Mostrar()
        {
            try
            {
                List<EPermisos> Obj = new List<EPermisos>();
                var Objbd = db.Tab_Permisos.ToList();
                foreach (var Item in Objbd)
                {
                    Obj.Add(new EPermisos()
                    {
                        ID = Item.ID,
                        Id_Rol = Item.Id_Rol,
                        Modulo = Item.Modulo,
                        Accion = Item.Accion
                    });
                }
                return Obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EPermisos> Mostrar(int Id)
        {
            try
            {
                List<EPermisos> Obj = new List<EPermisos>();
                var Objbd = db.Tab_Permisos.Where(x => x.Id_Rol == Id).ToList();
                foreach (var Item in Objbd)
                {
                    Obj.Add(new EPermisos()
                    {
                        ID = Item.ID,
                        Id_Rol = Item.Id_Rol,
                        Modulo = Item.Modulo,
                        Accion = Item.Accion
                    });
                }
                return Obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EPermisos> Mostrar(int Id, string Modulo)
        {
            try
            {
                List<EPermisos> Obj = new List<EPermisos>();
                var Objbd = db.Tab_Permisos.Where(x => x.Id_Rol == Id && x.Modulo == Modulo).ToList();
                foreach (var Item in Objbd)
                {
                    Obj.Add(new EPermisos()
                    {
                        ID = Item.ID,
                        Id_Rol = Item.Id_Rol,
                        Modulo = Item.Modulo,
                        Accion = Item.Accion
                    });
                }
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

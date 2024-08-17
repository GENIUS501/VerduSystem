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
    public class DBitacora_Sesiones
    {
        DiamondEntities db = new DiamondEntities();
        #region Agregar
        public int Agregar(EBitacora_Sesiones obj)//Viene de la vista Obj
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    Tab_Bitacora_Sesiones Objbd = new Tab_Bitacora_Sesiones();//Viene de la base de datos
                    Objbd.Id_Usuario = obj.Id_Usuario;
                    Objbd.fecha_hora_ingreso = obj.fecha_hora_ingreso;
                    db.Tab_Bitacora_Sesiones.Add(Objbd);

                    db.SaveChanges();//Commit

                    int Resultado = Objbd.codigo_ingreso_salida;

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

        #region Moodificar
        public int Modificar(EBitacora_Sesiones Obj)
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var Objbd = db.Tab_Bitacora_Sesiones.Where(x => x.codigo_ingreso_salida == Obj.codigo_ingreso_salida).FirstOrDefault();
                    Objbd.fecha_hora_salida = DateTime.Now;
                    db.Entry(Objbd).State = EntityState.Modified;
                    int Resultado = db.SaveChanges();
                    if (Resultado > 0)
                    {
                        Ts.Complete();
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

        #region Listar
        public List<EBitacora_Sesiones> Mostrar()
        {
            try
            {
                List<EBitacora_Sesiones> Obj = new List<EBitacora_Sesiones>();
                Obj = db.Tab_Bitacora_Sesiones.Select(x => new EBitacora_Sesiones
                {
                    Id_Usuario = x.Id_Usuario,
                    fecha_hora_ingreso = x.fecha_hora_ingreso,
                    fecha_hora_salida = x.fecha_hora_salida,
                    codigo_ingreso_salida = x.codigo_ingreso_salida
                }).ToList();
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

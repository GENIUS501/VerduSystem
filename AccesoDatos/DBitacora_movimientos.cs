using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AccesoDatos
{
    public class DBitacora_movimientos
    {
        DiamondEntities db = new DiamondEntities();
        #region Agregar
        public int Agregar(EBitacora_Movimientos obj)//Viene de la vista obj
        {
            try
            {
                using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    Tab_Bitacora_Movimientos Objbd = new Tab_Bitacora_Movimientos();//Viene de la base de datos
                    Objbd.Id_Usuario = obj.Id_Usuario;
                    Objbd.fecha_hora_movimiento = obj.fecha_hora_movimiento;
                    Objbd.tipo_movimiento = obj.tipo_movimiento;
                    Objbd.modulo = obj.modulo;
                    db.Tab_Bitacora_Movimientos.Add(Objbd);

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
        public List<EBitacora_Movimientos> Mostrar()
        {
            try
            {
                List<EBitacora_Movimientos> Obj = new List<EBitacora_Movimientos>();
                var Objbd = db.Tab_Bitacora_Movimientos.ToList();
                Obj = db.Tab_Bitacora_Movimientos
                .Select(Item => new EBitacora_Movimientos
                {
                    Id_Usuario = Item.Id_Usuario,
                    fecha_hora_movimiento = Item.fecha_hora_movimiento,
                    tipo_movimiento = Item.tipo_movimiento,
                    modulo = Item.modulo,
                    codigo_movimiento_usuario = Item.codigo_movimiento_usuario
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

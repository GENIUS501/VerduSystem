using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EBitacora_Sesiones
    {
        public int codigo_ingreso_salida { get; set; }
        public System.DateTime fecha_hora_ingreso { get; set; }
        public Nullable<System.DateTime> fecha_hora_salida { get; set; }
        public Nullable<int> Id_Usuario { get; set; }
    }
}

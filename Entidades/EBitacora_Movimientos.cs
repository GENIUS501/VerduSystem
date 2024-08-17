using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EBitacora_Movimientos
    {
        public int codigo_movimiento_usuario { get; set; }
        public System.DateTime fecha_hora_movimiento { get; set; }
        public string tipo_movimiento { get; set; }
        public string modulo { get; set; }
        public Nullable<int> Id_Usuario { get; set; }
    }
}

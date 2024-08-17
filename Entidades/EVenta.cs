using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EVenta
    {
        public int ID_Usuario { get; set; }
        public int ID_Cliente { get; set; }
        public string Tipo_pago { get; set; }
        public int Numero_factura { get; set; }
        public System.DateTime Fecha_venta { get; set; }
        public double Total { get; set; }
    }
}

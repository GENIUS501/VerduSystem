using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EReporte_Ventas_Detalles
    {
        public int ID { get; set; }
        public int IdVenta { get; set; }
        public double Costo { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoProducto { get; set; }
    }
}

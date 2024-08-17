using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EDevoluciones
    {
        public int IdDevolucion { get; set; }
        public int IdVenta { get; set; }
        public int IDCliente { get; set; }
        public System.DateTime FechaDevolucion { get; set; }
        public double CantidadProducto { get; set; }
        public int IdUsuario { get; set; }
        public int Monto { get; set; }
    }
}

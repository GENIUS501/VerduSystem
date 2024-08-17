using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EPermisos
    {
        public int ID { get; set; }
        public string Modulo { get; set; }
        public string Accion { get; set; }
        public int Id_Rol { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EUsuario
    {
        public int ID_Usuario { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public string Nombre_Usuario { get; set; }
        public int Id_Rol { get; set; }
        public string Contrasena { get; set; }
      //  public int Estado { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}

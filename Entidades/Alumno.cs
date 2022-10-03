using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellPaterno { get; set; }
        public string apellMaterno { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string curp { get; set; }
        public decimal sueldo { get; set; }
        public int idEstadoOrig { get; set; }
        public int idEstatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ItemTablaISR
    {
        public decimal LimInferior { get; set; }
        public decimal LimSuperior { get; set; }
        public decimal CuotaFija { get; set; }
        public decimal Excedente { get; set; }
        public decimal Subsidio { get; set; }
        public decimal ISR { get; set; }
    }
}

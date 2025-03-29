using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Model
{
    public class Ventas
    {
        public int Codigo_Venta { get; set; }
        public int Codigo_Transaccion { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public decimal Total { get; set; }
    }
}

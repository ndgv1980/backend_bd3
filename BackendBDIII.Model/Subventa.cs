using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Model
{
    public class Subventa
    {
        public int Codigo_Subventa { get; set; }
        public int Codigo_Venta { get; set; }
        public int Codigo_Producto { get; set; }
        public int Cantidad_Vendida { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}

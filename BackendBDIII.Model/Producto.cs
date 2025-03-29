using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Model
{
    public class Producto
    {
        public int Codigo_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public decimal Precio_Unitario { get; set; }
    }
}

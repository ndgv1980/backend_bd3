using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Model
{
    public class Stock
    {
        public int Codigo_Producto { get; set; }
        public int Nivel_Stock { get; set; }
        public int Codigo_Almacen { get; set; }
        public int Codigo_Estanteria { get; set; }
    }
}

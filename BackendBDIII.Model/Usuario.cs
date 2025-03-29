using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contra { get; set; }
        /// <summary>
        /// 1 if is admin; otherwise, 0.
        /// </summary>
        public int Administrador { get; set; }
    }
}

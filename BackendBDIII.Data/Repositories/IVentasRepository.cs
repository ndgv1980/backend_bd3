using BackendBDIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data.Repositories
{
    public interface IVentasRepository
    {
        Task<IEnumerable<Ventas>> GetAllSales();
        Task<bool> InsertSale(Ventas i_sale);
    }
}

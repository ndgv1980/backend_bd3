using BackendBDIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetStock();
        Task<bool> InsertStock(Stock i_stock);
        Task<bool> DeleteStock(Stock i_stock);
        Task<bool> UpdateStock(Stock i_stock);
    }
}

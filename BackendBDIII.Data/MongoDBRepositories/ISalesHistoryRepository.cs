using BackendBDIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data.MongoDBRepositories
{
    public interface ISalesHistoryRepository
    {
        public Task<bool> InsertSaleHistory(Ventas i_sale);
    }
}

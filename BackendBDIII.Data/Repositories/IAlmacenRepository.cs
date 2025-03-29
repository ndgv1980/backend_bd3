using BackendBDIII.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data.Repositories
{
    public interface IAlmacenRepository
    {
        Task<IEnumerable<Almacen>> GetAllStorageLocations();
        Task<bool> InsertStorageLocation(Almacen i_storageLocation);
        Task<bool> DeleteStorageLocation(Almacen i_storageLocation);
        Task<bool> UpdateStorageLocation(Almacen i_storageLocation);
    }
}

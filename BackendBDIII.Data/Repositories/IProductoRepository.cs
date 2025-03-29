using BackendBDIII.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllProducts();
        Task<bool> InsertProduct(Producto i_product);
        Task<bool> DeleteProduct(Producto i_product);
        Task<bool> UpdateProduct(Producto i_product);
    }
}

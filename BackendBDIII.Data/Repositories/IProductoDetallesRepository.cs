using BackendBDIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data.Repositories
{
    public interface IProductoDetallesRepository
    {
        Task<IEnumerable<ProductoDetalles>> GetAllProductsDetails();
        Task<bool> InsertProductDetails(ProductoDetalles i_productDetails);
        Task<bool> DeleteProductDetails(ProductoDetalles i_productDetails);
        Task<bool> UpdateProductDetails(ProductoDetalles i_productDetails);
    }
}

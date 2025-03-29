using BackendBDIII.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data.Repositories
{
    public sealed class ProductoDetallesRepository(MySQLConfiguration i_connectionString, MySqlConnection i_connection) : IProductoDetallesRepository
    {
        public async Task<IEnumerable<ProductoDetalles>> GetAllProductsDetails()
        {
            string sql = @"SELECT codigo_producto, descripcion FROM producto_detalles";

            return await m_connection.QueryAsync<ProductoDetalles>(sql, new { });
        }

        public async Task<bool> InsertProductDetails(ProductoDetalles i_productDetails)
        {
            string sql = @"INSERT INTO producto_detalles VALUES(@codigo_producto, @descripcion)";

            return await m_connection.ExecuteAsync(sql, i_productDetails) > 0;
        }

        public async Task<bool> DeleteProductDetails(ProductoDetalles i_productDetails)
        {
            string sql = @"DELETE FROM producto_detalles WHERE codigo_producto = @codigo_producto";

            return await m_connection.ExecuteAsync(sql, new { codigo_producto = i_productDetails.Codigo_Producto }) > 0;
        }

        public async Task<bool> UpdateProductDetails(ProductoDetalles i_productDetails)
        {
            string sql = @"UPDATE producto_detalles SET descripcion = @descripcion WHERE codigo_producto = @codigo_producto";

            return await m_connection.ExecuteAsync(sql, new
            {
                descripcion = i_productDetails.Descripcion,
                codigo_producto = i_productDetails.Codigo_Producto,
            }) > 0;
        }

        private readonly MySQLConfiguration m_connectionString = i_connectionString;
        private readonly MySqlConnection m_connection = i_connection;
    }
}

using BackendBDIII.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data.Repositories
{
    public sealed class ProductoRepository(MySQLConfiguration i_connectionString, MySqlConnection i_connection) : IProductoRepository
    {
        public async Task<IEnumerable<Producto>> GetAllProducts()
        {
            string sql = @"SELECT codigo_producto, nombre_producto, precio_unitario FROM producto";

            return await m_connection.QueryAsync<Producto>(sql, new { });
        }

        public async Task<bool> InsertProduct(Producto i_product)
        {
            string sql = @"INSERT INTO producto VALUES(@codigo_producto, @nombre_producto, @precio_unitario)";

            return await m_connection.ExecuteAsync(sql, i_product) > 0;
        }

        public async Task<bool> DeleteProduct(Producto i_product)
        {
            string sql = @"DELETE FROM producto WHERE codigo_producto = @codigo_producto";

            return await m_connection.ExecuteAsync(sql, new { codigo_producto = i_product.Codigo_Producto }) > 0;
        }

        public async Task<bool> UpdateProduct(Producto i_product)
        {
            string sql = @"UPDATE producto SET nombre_producto = @nombre_producto, precio_unitario = @precio_unitario WHERE codigo_producto = @codigo_producto";

            return await m_connection.ExecuteAsync(sql, new
            {
                nombre_producto = i_product.Nombre_Producto,
                precio_unitario = i_product.Precio_Unitario,
                codigo_producto = i_product.Codigo_Producto,
            }) > 0;
        }

        private readonly MySQLConfiguration m_connectionString = i_connectionString;
        private readonly MySqlConnection m_connection = i_connection;
    }
}

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
    public class StockRepository(MySQLConfiguration i_connectionString, MySqlConnection i_connection) : IStockRepository
    {
        public async Task<IEnumerable<Stock>> GetStock()
        {
            string sql = @"SELECT codigo_producto, nivel_stock, codigo_almacen, codigo_estanteria FROM stock";

            return await m_connection.QueryAsync<Stock>(sql, new { });
        }

        public async Task<bool> InsertStock(Stock i_stock)
        {
            string sql = @"INSERT INTO stock VALUES(@codigo_producto, @nivel_stock, @codigo_almacen, @codigo_estanteria)";

            return await m_connection.ExecuteAsync(sql, i_stock) > 0;
        }

        public async Task<bool> DeleteStock(Stock i_stock)
        {
            string sql = @"DELETE FROM stock WHERE codigo_producto = @codigo_producto AND codigo_almacen = @codigo_almacen";

            return await m_connection.ExecuteAsync(sql, new { codigo_producto = i_stock.Codigo_Producto, codigo_almacen = i_stock.Codigo_Almacen }) > 0;
        }

        public async Task<bool> UpdateStock(Stock i_stock)
        {
            string sql = @"UPDATE stock SET nivel_stock = @nivel_stock, codigo_estanteria = @codigo_estanteria WHERE codigo_producto = @codigo_producto AND codigo_almacen = @codigo_almacen";

            return await m_connection.ExecuteAsync(sql, new
            {
                nivel_stock = i_stock.Nivel_Stock,
                codigo_estanteria = i_stock.Codigo_Estanteria,
                codigo_producto = i_stock.Codigo_Producto,
                codigo_almacen = i_stock.Codigo_Almacen,
            }) > 0;
        }

        private readonly MySQLConfiguration m_connectionString = i_connectionString;
        private readonly MySqlConnection m_connection = i_connection;
    }
}

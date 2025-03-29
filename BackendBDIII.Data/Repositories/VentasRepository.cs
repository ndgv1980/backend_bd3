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
    public class VentasRepository(MySQLConfiguration i_connectionString, MySqlConnection i_connection) : IVentasRepository
    {
        public async Task<IEnumerable<Ventas>> GetAllSales()
        {
            string sql = @"SELECT codigo_venta, codigo_transaccion, fecha_venta, total FROM ventas";

            return await m_connection.QueryAsync<Ventas>(sql, new { });
        }

        public async Task<bool> InsertSale(Ventas i_sale)
        {
            string sql = @"INSERT INTO ventas VALUES(@codigo_venta, @codigo_transaccion, @fecha_venta, @total)";

            return await m_connection.ExecuteAsync(sql, new 
            { 
                codigo_venta = i_sale.Codigo_Venta, 
                codigo_transaccion = i_sale.Codigo_Transaccion, 
                fecha_venta = i_sale.Fecha_Venta, 
                total = i_sale.Total 
            }) > 0;
        }

        private readonly MySQLConfiguration m_connectionString = i_connectionString;
        private readonly MySqlConnection m_connection = i_connection;
    }
}

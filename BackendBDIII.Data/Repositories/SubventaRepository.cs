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
    public sealed class SubventaRepository(MySQLConfiguration i_connectionString, MySqlConnection i_connection) : ISubventaRepository
    {
        public async Task<IEnumerable<Subventa>> GetAllSubsales()
        {
            string sql = @"SELECT codigo_subventa, codigo_venta, codigo_producto, cantidad_vendida, precio_unitario, subtotal FROM subventa";

            return await m_connection.QueryAsync<Subventa>(sql, new { });
        }

        public async Task<bool> InsertSubsale(Subventa i_subsale)
        {
            string sql = @"INSERT INTO subventa VALUES(@codigo_subventa, @codigo_venta, @codigo_producto, @cantidad_vendida, @precio_unitario, @subtotal)";

            return await m_connection.ExecuteAsync(sql, i_subsale) > 0;
        }

        private readonly MySQLConfiguration m_connectionString = i_connectionString;
        private readonly MySqlConnection m_connection = i_connection;
    }
}

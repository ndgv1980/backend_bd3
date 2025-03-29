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
    public sealed class AlmacenRepository(MySQLConfiguration i_connectionString, MySqlConnection i_connection) : IAlmacenRepository
    {
        public async Task<IEnumerable<Almacen>> GetAllStorageLocations()
        {
            string sql = @"SELECT codigo_almacen, ubicacion, nombre FROM almacen";

            return await m_connection.QueryAsync<Almacen>(sql, new { });
        }

        public async Task<bool> InsertStorageLocation(Almacen i_storageLocation)
        {
            string sql = @"INSERT INTO almacen VALUES(@codigo_almacen, @ubicacion, @nombre)";

            return await m_connection.ExecuteAsync(sql, i_storageLocation) > 0;
        }

        public async Task<bool> DeleteStorageLocation(Almacen i_storageLocation)
        {
            string sql = @"DELETE FROM almacen WHERE codigo_almacen = @codigo_almacen";

            return await m_connection.ExecuteAsync(sql, new { codigo_almacen = i_storageLocation.Codigo_Almacen }) > 0;
        }

        public async Task<bool> UpdateStorageLocation(Almacen i_storageLocation)
        {
            string sql = @"UPDATE almacen SET ubicacion = @ubicacion, nombre = @nombre WHERE codigo_almacen = @codigo_almacen";

            return await m_connection.ExecuteAsync(sql, new 
            { 
                ubicacion = i_storageLocation.Ubicacion,
                nombre = i_storageLocation.Nombre,
                codigo_almacen = i_storageLocation.Codigo_Almacen 
            }) > 0;
        }

        private readonly MySQLConfiguration m_connectionString = i_connectionString;
        private readonly MySqlConnection m_connection = i_connection;
    }
}

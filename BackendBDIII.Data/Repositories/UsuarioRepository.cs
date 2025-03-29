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
    public class UsuarioRepository(MySQLConfiguration i_connectionString, MySqlConnection i_connection) : IUsuarioRepository
    {
        public async Task<IEnumerable<Usuario>> GetAllUsers()
        {
            string sql = @"SELECT id, nombre, contra, administrador FROM usuario";

            return await m_connection.QueryAsync<Usuario>(sql, new { });
        }

        private readonly MySQLConfiguration m_connectionString = i_connectionString;
        private readonly MySqlConnection m_connection = i_connection;
    }
}

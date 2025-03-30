using BackendBDIII.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendBDIII.Data.MongoDBRepositories
{
    public class SalesHistoryRepository(MongoClient i_mongoClient) : ISalesHistoryRepository
    {
        public async Task<bool> InsertSaleHistory(Ventas i_sale)
        {
            var collection = m_mongoClient.GetDatabase("backend_data").GetCollection<Ventas>("sales_history");
            //var filter = Builders<Ventas>.Filter.Eq("codigo_venta", 4);
            //var document = collection.Find(filter).First();

            await collection.InsertOneAsync(i_sale);

            return true;
        }

        private readonly MongoClient m_mongoClient = i_mongoClient;
    }
}

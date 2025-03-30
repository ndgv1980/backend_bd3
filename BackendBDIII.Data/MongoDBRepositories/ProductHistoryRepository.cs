using BackendBDIII.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data.MongoDBRepositories
{
    public class ProductHistoryRepository(MongoClient i_mongoClient) : IProductsHistoryRepository
    {
        public async Task<bool> InsertProductHistory(ProductHistory i_product)
        {
            var collection = m_mongoClient.GetDatabase("backend_data").GetCollection<ProductHistory>("products_history");
            await collection.InsertOneAsync(i_product);

            return true;
        }

        private readonly MongoClient m_mongoClient = i_mongoClient;
    }
}

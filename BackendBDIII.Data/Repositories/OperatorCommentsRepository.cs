using BackendBDIII.Data.MongoDBRepositories;
using BackendBDIII.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data.Repositories
{
    public class OperatorCommentsRepository(MongoClient i_mongoClient) : IOperatorCommentsRepository
    {
        public async Task<bool> InsertComment(OperatorComment i_comment)
        {
            var collection = m_mongoClient.GetDatabase("backend_data").GetCollection<OperatorComment>("operator_comments");
            await collection.InsertOneAsync(i_comment);

            return true;
        }

        private readonly MongoClient m_mongoClient = i_mongoClient;
    }
}

using BackendBDIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data.MongoDBRepositories
{
    public interface IOperatorCommentsRepository
    {
        public Task<bool> InsertComment(OperatorComment i_comment);
    }
}
